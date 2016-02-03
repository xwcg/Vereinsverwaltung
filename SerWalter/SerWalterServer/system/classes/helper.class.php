<?php

class H
{
    public static function ReadFile($path)
    {
        $FILE_CONTENT = "";
        $FILE_PATH = $path;
        
        $FILE_HANDLE = fopen($FILE_PATH, "r");
        if(!$FILE_HANDLE) return null;
        
        $FILE_CONTENT = fread($FILE_HANDLE, filesize($FILE_PATH));
        fclose($FILE_HANDLE);
               
        return $FILE_CONTENT;
    }
    
    public static function ReadJSONFile($path)
    {
        return json_decode(H::ReadFile($path));
    }
    
    public static function RndString($size)
    {
        $characters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_-";
        $randomString = "";
        for ($i = 0; $i < $size; $i++) 
        {
            $randomString .= $characters[rand(0, strlen($characters) - 1)];
        }
        return $randomString;
    }
    
    public static function Mail($to, $subject = '(No subject)', $message = '', $from = '') 
    {		
	    $header = "MIME-Version: 1.0\n";
	    $header .= "Content-type: text/html; charset=utf-8 \n";
	    $header .= "Content-Transfer-Encoding: 8bit\n";

	    $header .= H::Format("From: {0}\n", $from);
            			
	    mail($to, $subject, $message, $header, H::Format("-f {0}", $from));
    }

    public static function Number($val)
    {
        return str_replace(",", ".", $val);
    }
    
    public static function UnNumber($val)
    {
        if($val === null)
            return null;
            
        return str_replace(".", ",", $val);
    }
    
    public static function Extract($key_what, &$from)
    {
        $return = $from[$key_what];
        
        $newArr = [];
        
        foreach($from as $key => $value)
        {
            if($key != $key_what)
                $newArr[$key] = $value;
        }
        
        $from = $newArr;
        return $return;
    }

    /**
     * C# Style String Formatting
     *
     * <code>
     * echo H::Format("{0} World!", "Hello"); // Hello World!
     * </code>
     *
     * @author Michael Schwarz <mschwarz@soft-evolution.com>
     *
     * @param string $string The string that is to be formatted
     * @param string $args,... Replace arguments
     * @return string Formatted string
     */
    public static function Format()
    {
        $argLength = func_num_args();
        if($argLength == 0)
            return;
        else if ($argLength == 1)
            return func_get_arg(0);

        $argList = func_get_args();

        $string = (string)$argList[0];
        $replStrings = array_slice($argList, 1);

        for($i = 0; $i < count($replStrings); $i++)
        {
            $string = str_replace("{" . $i . "}", (string)$replStrings[$i], $string);
        }

        return $string;
    }

    public static function FormatArr($str, $arr)
    {
        if(!is_array($arr) || count($arr) == 0)
            return $str;

        $string = $str;
        
        foreach($arr as $key => $value)
        {
            $string = str_replace("{" . $key . "}", $value, $string);
        }
        
        return $string;
    }
    
    public static function Contains($needle, $haystack)
    {
        return stripos($haystack, $needle) !== false;
    }
    
    public static function StartsWith($needle, $haystack)
    {
        return $needle === "" || strpos($haystack, $needle) === 0;
    }
    public static function EndsWith($needle, $haystack)
    {
        return $needle === "" || substr($haystack, -strlen($needle)) === $needle;
    }

    #region Is

    public static function IsBoolean($e)
    {
        if($e === true || $e === false)
            return true;

        return false;
    }

    public static function IsString($e)
    {
        return is_string($e);
    }

    /**
     * Finds whether the given array is associative. Null if not array.
     * @param $e Array to be tested
     * @return bool|null true|false if parameter is array, null if not
     */
    public static function IsAssociative($e)
    {
        if(!is_array($e))
            return null;

        if(count(array_filter(array_keys($e), "is_string")) == count($e))
            return true;

        return false;
    }

    #endregion
    
    public static function ToTimestamp($e)
    {
        // 2014-04-17 16:23:38
        
        $split_datetime = explode(" ", (string)$e);
        if(count($split_datetime) !== 2)
            return null;
            
        $split_date = explode("-", $split_datetime[0]);
        if(count($split_date) !== 3)
            return null;
            
        $split_time = explode(":", $split_datetime[1]);
        if(count($split_time) !== 3)
            return null;
    
        $year = $split_date[0];
        $month = $split_date[1];
        $day = $split_date[2];
        
        $hour = $split_time[0];
        $minute = $split_time[1];
        $second = $split_time[2];
        
        return (int)mktime($hour, $minute, $second, $month, $day, $year);
    }

    public static function ToStringOrNull($e, $nullIfEmpty = true)
    {
        if($nullIfEmpty !== true && $nullIfEmpty !== false)
            throw new InvalidArgumentException("nullIfEmpty argument MUST be boolean true|false");

        if($e === null)
            return null;

        $value = (string)$e;

        if(strlen($value) == 0 && $nullIfEmpty === true)
            return null;

        return $value;
    }

    public static function ToString($e)
    {
        return (string)$e;
    }

    public static function ToIntOrNull($e, $nullIfEmpty = true)
    {
        if($nullIfEmpty !== true && $nullIfEmpty !== false)
            throw new InvalidArgumentException("nullIfEmpty argument MUST be boolean true|false");

        if($e === null)
            return null;

        $value = (int)$e;

        if(strlen((string)$e) == 0 && $nullIfEmpty === true)
            return null;

        return $value;
    }

    public static function ToInt($e)
    {
        return (int)$e;
    }

    public static function ToFloatOrNull($e, $nullIfEmpty = true)
    {
        if($nullIfEmpty !== true && $nullIfEmpty !== false)
            throw new InvalidArgumentException("nullIfEmpty argument MUST be boolean true|false");

        if($e === null)
            return null;

        $value = (float)$e;

        if(strlen((string)$e) == 0 && $nullIfEmpty === true)
            return null;

        return $value;
    }

    public static function ToFloat($e)
    {
        return (float)$e;
    }

    public static function ToDoubleOrNull($e, $nullIfEmpty = true)
    {
        return H::ToFloatOrNull($e, $nullIfEmpty);
    }

    public static function ToDouble($e)
    {
        return H::ToFloat($e);
    }

    public static function ToBoolean($e, $defaultIfEmptyOrNull = false)
    {
        if(!H::IsBoolean($defaultIfEmptyOrNull))
            throw new InvalidArgumentException("defaultIfEmptyOrNull argument MUST be boolean true|false");

        if(H::IsBoolean($e))
            return $e;

        $strVal = (string)$e;
        $intVal = (int)$e;
        $floatVal = (float)$e;

        if($strVal == "true" || $strVal == "1")
            return true;

        if($strVal == "false" || $strVal == "0")
            return false;

        $isNullOrEmpty = ($e === null) || (strlen($strVal) == 0) || ($intVal == 0) || ($floatVal == 0.0);

        if($isNullOrEmpty) return $defaultIfEmptyOrNull;
        else return !$defaultIfEmptyOrNull;
    }

    public static function Clamp($val, $min, $max)
    {
        return (int)(max((int)$val, min((int)$min, (int)$val)));
    }
}

class CDate
{
    private $_TS;

    public function __construct($timestamp = null)
    {
        if($timestamp === null)
            $this->_TS = time();
        else
            if(is_int($timestamp))
                $this->_TS = (int)$timestamp;
            else
                throw new InvalidArgumentException("Argument is not a valid timestamp!");
    }

    public function __toString()
    {
        return date("Y-m-d H:i:s", $this->_TS);
    }
}

/**
 * C# Like array object
 *
 * @author Michael Schwarz <mschwarz@soft-evolution.com>
 *
 * @property-read int $count Number of elements in the array
 * @property-read int $length Number of elements in the array
 * @property-read bool $isAssociative Whether the array is associative or not
 */
class CArray
{
    private $arr = [];

    /**
     * Summary of __construct
     * @param $initialValues,... (Optional) Initial array of values or arguments for array elements
     */
    public function __construct($initialValues = null)
    {
        $argLength = func_num_args();
        if($argLength == 0)
        {
            return;
        }
        else if ($argLength == 1)
        {
            $this->arr = $initialValues;
        }
        else
        {
            $args = func_get_args();
            for($i = 0; $i < count($args); $i++)
                $this->arr[] = $args[$i];
        }
    }

    public function __get($name)
    {
        switch($name)
        {
            case "length":
            case "count":
                return count($this->arr);
            case "isAssociative":
                return H::IsAssociative($this->arr);
        }
    }

    /**
     * Gets values.
     *
     * - No param or 1st param is null:  returns the array
     * - One parameter: Returns value at array key
     * - Multiple parameters: returns first value that is found with given keys
     *
     * @param $key
     * @return mixed
     */
    public function get($key = null)
    {
        if($key === null)
            return $this->arr;

        $argLength = func_num_args();

        if($argLength == 1)
            return $this->arr[$key];

        $args = func_get_args();
        for($i = 0; $i < count($args); $i++)
            if($this->hasKey($args[$i])) return $this->arr[$args[$i]];

        return null;
    }

    public function set($newarr, $key = null)
    {
        if($key === null)
        {
            if(is_array($newarr))
                $this->arr = $newarr;
        }
        else
        {
            $this->arr[$key] = $newarr;
        }
    }

    /**
     * Appends an item to the end of the array
     * @param $item item to add
     */
    public function push($item)
    {
        $this->arr[] = $item;
    }

    /**
     * Pop an element off the end of the array and return it
     * @return last element in the array
     */
    public function pop()
    {
        return array_pop($this->arr);
    }

    /**
     * Returns string of the value of all elements in the array
     * @param $delimiter Delimiter to use. (Default: ";")
     */
    public function join($delimiter = ";")
    {
        return implode($delimiter, $this->arr);
    }

    /**
     * Checks if array contains $value
     * @param mixed $value Value to look for
     * @param bool $strict If true will search for identical objects (Default: false)
     * @return bool
     */
    public function has($value, $strict = false)
    {
        return (array_search($value, $this->arr, $strict) === false ? false : true);
    }

    /**
     * Checks if array contains the key $key
     * @param mixed $key Key to look for
     * @return bool
     */
    public function hasKey($key)
    {
        return array_key_exists($key, $this->arr);
    }

    /**
     * Checks if the given keys in the arguments exist
     * @param $args,... One argument with an array of keys to check or multiple arguments with keys
     * @return bool true or false
     */
    public function hasKeys($arg0)
    {
        $argLength = func_num_args();
        $argArr = [];

        if($argLength == 1)
        {
            if(is_array($arg0))
                $argArr = $arg0;
            else
                $argArr = [$arg0];
        }
        else
        {
            $args = func_get_args();
            for($i = 0; $i < count($args); $i++)
                $argArr[] = $args[$i];
        }

        foreach($argArr as $key)
            if(!$this->hasKey($key))
                return false;

        return true;
    }

    public function keysToUpper()
    {
        $newArr = [];

        foreach($this->arr as $key => $value)
        {
            if(is_string($key))
                $newArr[strtoupper($key)] = $value;
            else
                $newArr[$key] = $value;
        }

        $this->arr = $newArr;
    }

    public function keysToLower()
    {
        $newArr = [];

        foreach($this->arr as $key => $value)
        {
            if(is_string($key))
                $newArr[strtolower($key)] = $value;
            else
                $newArr[$key] = $value;
        }

        $this->arr = $newArr;
    }
}