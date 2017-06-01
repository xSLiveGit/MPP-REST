<?php
/**
 * Created by PhpStorm.
 * User: Sergiu
 * Date: 6/1/2017
 * Time: 5:08 PM
 */

$ch = curl_init();

$team1 = $_POST["team1"];
$team2 = $_POST["team2"];
$stage = $_POST["stage"];
$price = $_POST["price"];
$tickets = $_POST["tickets"];

$post = [
    'team1' => $_POST["team1"],
    'team2' => $_POST["team2"],
    'stage' => $_POST["stage"],
    'price' => $_POST["price"],
    'tickets' => $_POST["tickets"]
];

$ch = curl_init();
curl_setopt($ch, CURLOPT_URL, 'http://localhost:8080/matches');
curl_setopt($ch, CURLOPT_RETURNTRANSFER, false);
curl_setopt($ch, CURLOPT_HTTPHEADER,
    array("Content-type: application/json"));
curl_setopt($ch, CURLOPT_POST, true);
//curl_setopt($ch, CURLOPT_POSTFIELDS, http_build_Squery($post));
$content = json_encode($post);
curl_setopt($ch, CURLOPT_POSTFIELDS, $content);

$response = curl_exec($ch);
var_export($response);
