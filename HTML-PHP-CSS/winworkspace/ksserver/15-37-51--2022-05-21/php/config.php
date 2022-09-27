<?php
	define('DB_SERVER', 'localhost');
	define('DB_USERNAME', 'w3b');
	define('DB_PASSWORD', 'WebTest');
	define('DB_NAME', 'webtest');
	
	$mysqli = new mysqli(DB_SERVER, DB_USERNAME, DB_PASSWORD, DB_NAME);
	
	if(!$mysqli){
		die("ERROR: No se pudo conectar. " . $mysqli->connect_error);
	}
?>