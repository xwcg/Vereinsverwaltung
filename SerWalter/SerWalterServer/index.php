<?php
require_once("system/include.php");

$command = $_POST["cmd"];
$payload = $_POST["payload"];
$response = [ "success" => false ];


if(isset($command) && isset($payload) && isset($payload["user"]) && isset($payload["pass"]))
{
    if(Globals::$query->CheckUser($payload["user"], $payload["pass"]))
    {
        switch($command)
        {
            default:
                $response["error"] = "INVALID_CMD";
                break;
        }
    }
    else
    {
        $response["error"] = "INVALID_USER";
    }
}
else
{
    $response["error"] = "INCOMPLETE_REQUEST";
}

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