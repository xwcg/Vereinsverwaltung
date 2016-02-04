<?php

class Database
{
    private $db;
    private $is_connected = false;

    public $errors = [];
    public $queries = [];
    public $manual_log = [];

    private $debug_stack = false;

    // main functions

    public function Database()
    {
        $this->Connect();
    }

    private function Connect()
    {
        if(!$this->is_connected)
        {
            $this->db = new mysqli(DBHOST, DBUSER, DBPASS, DBNAME);

            if($this->db->connect_errno)
            {
                exit("DBERR (0::" . $this->db->connect_errno . ")");
            }

            $this->is_connected = true;
        }
    }

    public function Disconnect()
    {
        if($this->is_connected)
        {
            $this->db->close();
            $this->is_connected = false;
        }
    }

    // helpers

    public function escape_string($str)
    {
        return $this->db->escape_string($str);
    }

    public function PushError($e)
    {
        $this->errors[] = $e;
    }

    public function GetInsertId()
    {
        return $this->db->insert_id;
    }

    public function GetAffectedRows()
    {
        return $this->db->affected_rows;
    }

    public function Query($query)
    {
        if($this->is_connected)
        {
            if($this->debug_stack === true)
            {
                $stack = debug_backtrace();
                for($i = 0; $i < count($stack); $i++)
                {
                    $name = $stack[$i]["function"];
                    $args = $stack[$i]["args"];

                    for($k = 0; $k < count($args); $k++)
                    {
                        $args[$k] = json_encode( $args[$k] );
                    }

                    $stack[$i] = ["name" => $name, "args" => $args];
                }

                $this->queries[] = ["sql" => $query, "stack" => $stack];
            }
            else
            {
                $this->queries[] = $query;
            }

            $result = $this->db->query($query);

            if($this->db->errno != 0)
            {
                $this->errors[] = ["query" => $query, "id" => $this->db->errno, "msg" => $this->db->error, "timestamp" => time()];
                return ["error" => true, "id" => $this->db->errno, "msg" => $this->db->error];
            }


            return $result;
        }

        return null;
    }

    public function IsError($result)
    {
        if(is_array($result) && $result["error"] === true)
            return true;

        return false;
    }
}

class DatabaseQueries
{

    public function DatabaseQueries()
    {
        if(Globals::$db === null)
            exit("DBERR (1) - No database initialized");
    }

    private function Escape($str)
    {
        return Globals::$db->escape_string($str);
    }

    #region Internal Helpers

    private function Unspool($result, $key_name = "id", $defaultReturn = false)
    {
        $returns = [];
        if(!Globals::$db->IsError($result))
        {
            if($result->num_rows > 0)
            {
                while($row = $result->fetch_assoc())
                {
                    if(is_string($key_name) || is_int($key_name))
                        $returns[$row[$key_name]] = $row;
                    else
                        $returns[] = $row;
                }

                return $returns;
            }
        }

        return $defaultReturn;
    }

    private function BuildInsert($table, $values)
    {
        $query = "INSERT INTO {PREFIX}{TABLE} ({KEYS}) VALUES ({VALUES})";

        $values_bits = [];

        foreach($values as $key => $value)
        {
			if($value !== null)
			{
				if(is_string($value))
					$values_bits[$key] = "'" . $this->Escape($value) . "'";
				else
					$values_bits[$key] = $value;
			}
			else
			{
				$values_bits[$key] = "null";
			}
        }

        $keysString = implode(", ", array_keys($values));
        $valuesString = implode(", ", array_values($values_bits));

        $query = H::FormatArr($query,
            [
                "PREFIX" => DBPREFIX,
                "TABLE" => $table,
                "KEYS" => $keysString,
                "VALUES" => $valuesString
            ]);

        return $query;
    }

    private function BuildUpdate($table, $values, $conditions)
    {
        $query = "UPDATE {PREFIX}{TABLE} SET {VALS} WHERE {CONDS}";

        $valuesString = "";
        $conditionsString = "";

        $values_bits = [];
        $conditions_bits = [];

        foreach($values as $key => $value)
        {
            $valueStr = $value;

            if(is_string($value))
                $valueStr = "'" . $this->Escape($value) . "'";

            $values_bits[] = H::Format("{0} = {1}", $key, $valueStr);
        }

        foreach($conditions as $condition)
        {
            if(is_array($condition))
            {
                $targetStr = $condition["TARGET"];

                if(is_string($targetStr))
                    $targetStr = "'" . $this->Escape($targetStr) . "'";

                $conditions_bits[] = H::Format("{0} {1} {2}", $condition["KEY"], $condition["COMPARISON"], $targetStr);
            }
            else
            {
                $conditions_bits[] = $condition;
            }
        }

        $valuesString = implode(", ", array_values($values_bits));
        $conditionsString = implode(" ", array_values($conditions_bits));

        $query = H::FormatArr($query,
            [
                "PREFIX" => DBPREFIX,
                "TABLE" => $table,
                "VALS" => $valuesString,
                "CONDS" => $conditionsString
            ]);

        return $query;
    }

    #endregion

    public function CheckUser($username, $password)
    {
        $query = H::FormatArr("SELECT * FROM {PREFIX}{TABLE} WHERE username = '{USERNAME}'",
            [
                "PREFIX" => DBPREFIX,
                "TABLE" => TABLE_USERS,
                "USERNAME" => $this->Escape($username)
            ]);

        $result = Globals::$db->Query($query);
        $dbUsers = $this->Unspool($result, null, null);

        if($dbUsers !== null)
        {
            $dbUser = $dbUsers[0];
            $hashedPw = sha1($password . $dbUser["salt"]);

            if($hashedPw == $dbUser["password"])
                return true;
        }

        return false;
    }
}

?>