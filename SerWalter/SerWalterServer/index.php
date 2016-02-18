<?php

require_once("system/include.php");

$cmd = $_POST["cmd"];
$data = (array)json_decode($_POST["data"]);

$response = [ "success" => false ];

if(isset($cmd) && strlen($cmd) > 0)
{
    switch($cmd)
    {
        case "push":
            $response["success"] = Globals::$query->Push($data);
            break;

        case "pull/members":
            $response["members"] = Globals::$query->Members_Pull();
            $response["success"] = true;
            break;

        case "pull/modifiers":
            $response["modifiers"] = Globals::$query->Modifiers_Pull();
            $response["success"] = true;
            break;

        case "pull/jobs":
            $response["jobs"] = Globals::$query->Jobs_Pull();
            $response["success"] = true;
            break;

        case "pull/banks":
            $response["banks"] = Globals::$query->Banks_Pull();
            $response["success"] = true;
            break;

        case "pull/invoices":
            $response["invoices"] = Globals::$query->Invoices_Pull();
            $response["success"] = true;
            break;

        case "ping":
            $response["success"] = true;
            break;

        default:
            $response["error"] = "INVALID_CMD";
            break;
    }
}

//$response["debug-post"] = $_POST;
$response["debug-db-errors"] = Globals::$db->errors;
$response["debug-db-queries"] = Globals::$db->queries;

ob_clean();
echo json_encode($response);
ob_end_flush();

?>