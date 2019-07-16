<?php
class DB{
	private static $instance = NULL;
	private static $user = "DBUSER";
	private static $password = "DBPASSWORD";
	private static $conn = "mysql:host=DBHOST;dbname=DBNAME;";
	private function __construct(){}
	private function __clone(){}
	public static function getInstance(){
		if(!self::$instance){
			self::$instance = new PDO(self::$conn, self::$user, self::$password);
			self::$instance->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
		}
		return self::$instance;
	}
}
?>
