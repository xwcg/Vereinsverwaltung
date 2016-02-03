<?php

define("TABLE_BANKS", "bank_accounts");
define("TABLE_JOBS", "job_type");
define("TABLE_MEMBERS", "member");
define("TABLE_MODIFIERS", "modifier");
define("TABLE_INVOICES", "invoices");
define("TABLE_PAYMENTS", "payments");

require_once("classes/helper.class.php"); // Load Helper Class
require_once("classes/db.class.php"); // Load Database Class

class Globals
{                            
    public static $db;      // Database
    public static $query;   // Queries
    
    public static function Init()
    {
        self::$db = new Database();
        self::$query = new DatabaseQueries();
    }
}

Globals::Init();

define("LOADED_DEPENDENCIES", true);

header("X-Clacks-Overhead: GNU Terry Pratchett");

?>