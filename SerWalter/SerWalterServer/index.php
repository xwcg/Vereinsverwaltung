<?php

require_once("system/include.php");

$cmd = $_POST["cmd"];
$data = json_decode($_POST["data"]);

$response = [ "success" => false ];

if(isset($cmd) && strlen($cmd) > 0)
{
    switch($cmd)
    {
        case "push":
            break;

        default:
            $response["error"] = "INVALID_CMD";
            break;
    }
}

ob_clean();
echo json_encode($response);
ob_end_flush();

?>