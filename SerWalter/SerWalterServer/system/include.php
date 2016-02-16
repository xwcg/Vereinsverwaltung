<?php

if(!ob_start("ob_gzhandler")) ob_start(); else header("Content-Encoding: gzip");
session_start();

define("ROOT_PATH", substr(__DIR__, 0, -7)); // Get Root path for unified paths

//[SETTINGS:START]

define("DBHOST", "localhost");
define("DBUSER", "root");
define("DBPASS", "");
define("DBNAME", "verein");
define("DBPREFIX", "");

define("MEMBERSHIP_COST", 30.00);

//[SETTINGS:END]

require_once("system_includes.php");

?>
