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
            $this->queries[] = $query;

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

    private function Check_JobType($id)
    {   
        $query = H::FormatArr("SELECT * FROM {PREFIX}{TABLE} WHERE id = '{ID}' LIMIT 1",
            [
                "PREFIX" => DBPREFIX,
                "TABLE" => TABLE_JOBS,
                "ID" => $this->Escape($id)
            ]);

        $result = Globals::$db->Query($query);
        $rows = $this->Unspool($result, null, []);
       
        return count($rows) > 0;
    }

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


    public function Modifiers_Pull()
    {
        $query = H::FormatArr("SELECT * FROM {PREFIX}{TABLE}",
            [
                "PREFIX" => DBPREFIX,
                "TABLE" => TABLE_MODIFIERS
            ]);

        $result = Globals::$db->Query($query);
        return $this->Unspool($result, null, []);
    }

    public function Jobs_Pull()
    {
        $query = H::FormatArr("SELECT * FROM {PREFIX}{TABLE}",
            [
                "PREFIX" => DBPREFIX,
                "TABLE" => TABLE_JOBS
            ]);

        $result = Globals::$db->Query($query);
        return $this->Unspool($result, null, []);
    }


    public function Members_Pull()
    {
        $query = H::FormatArr("SELECT * FROM {PREFIX}{TABLE}",
            [
                "PREFIX" => DBPREFIX,
                "TABLE" => TABLE_MEMBERS
            ]);

        $result = Globals::$db->Query($query);
        return $this->Unspool($result, null, []);
    }

    public function Banks_Pull()
    {
        $query = H::FormatArr("SELECT * FROM {PREFIX}{TABLE}",
            [
                "PREFIX" => DBPREFIX,
                "TABLE" => TABLE_BANKS
            ]);

        $result = Globals::$db->Query($query);
        return $this->Unspool($result, null, []);
    }

    private function FilterData($data, $ignoreFields)
    {
        $outData = [];

        foreach($data as $key => $value)
        {
            if(in_array($key, $ignoreFields))
                continue;

            $outData[$key] = $value;
        }

        return $outData;
    }

    public function Push($data)
    {
        $ignoreFields = ["id", "objectType"];
        $filteredData = $this->FilterData($data, $ignoreFields);

        $tableName = null;
        switch($data["objectType"])
        {
            case "Member":
                $tableName = TABLE_MEMBERS;
                break;
            case "BankAccount":
                $tableName = TABLE_BANKS;
                break;
        }

        if($tableName !== null)
        {
            if($data["id"] == -1)
            {
                $query = $this->BuildInsert($tableName, $filteredData);
            }
            else
            {
                $query = $this->BuildUpdate($tableName, $filteredData, [ ["KEY" => "id", "COMPARISON" => "=", "TARGET" => $data["id"] ] ]);
            }
                
            $result = Globals::$db->Query($query);
            if(!Globals::$db->IsError($result))
            {
                return Globals::$db->GetAffectedRows() > 0;
            }
        }

        return false;
    }
}

?>