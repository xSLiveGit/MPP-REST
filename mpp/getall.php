<?php
/**
 * Created by PhpStorm.
 * User: Sergiu
 * Date: 6/1/2017
 * Time: 3:37 PM
 */

    $ch = curl_init("http://localhost:8080/matches/"); // such as http://example.com/example.xml
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($ch, CURLOPT_HEADER, 0);
    $list = curl_exec($ch);
    curl_close($ch);

    echo $list;
