<?php
/**
 * Created by PhpStorm.
 * User: Sergiu
 * Date: 6/1/2017
 * Time: 4:48 PM
 */

try{

    $ch = curl_init();
    $id = $_GET['id'];
    curl_setopt($ch, CURLOPT_URL,"http://localhost:8080/matches/$id");
    curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "DELETE");
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, false);
//curl_setopt($ch, CURLOPT_HTTPHEADER,
//    array("Content-type: application/json"));
//$del =['id' => $_GET["id"]];
//$content = json_encode($del);
//curl_setopt($ch, CURLOPT_POSTFIELDS, $content);

    $response = curl_exec($ch);
    curl_close($ch);
    var_export($response);

}
catch (Exception $e){
}