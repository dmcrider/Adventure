<?php

class User{
    public $id;
    public $firstname;
    public $lastname;
    public $email;
    public $username;

    public function __construct($id, $firstname, $lastname, $email, $username){
        $this->id = $id;
        $this->firstname = $firstname;
        $this->lastname = $lastname;
        $this->email = $email;
        $this->username = $username;
    }

    public static function Login($name, $pass){
        try{
            // Set up the Database connection
            $db = DB::getInstance();
            $stmt = $db->prepare("SELECT * FROM users WHERE LoginName = ?");
            $query = $stmt->execute(array($name));
            $result = $stmt->fetch(PDO::FETCH_ASSOC);

            // Determine if the login was succesfull
            if($result !== FALSE){
                $storedPassword = $result['UPassword'];
                $hash = password_verify($pass, $storedPassword);

                if($hash){
                    // Successfull login
                    // Set the session variables we need
                    $_SESSION['current-user'] = new User($result['UserID'], $result['FirstName'], $result['LastName'], $result['Email'], $result['LoginName']);

                    return TRUE;

                }else{
                    $_SESSION['login-error'] = "Invalid email or password.";
                    return FALSE;
                }
            }else{
                $_SESSION['login-error'] = "Invalid email or password. Do you need to register?";
                return FALSE;
            }
        } catch(PDOException $e){
            // Database error
            $_SESSION['login-error'] = "PDO Error: " . $e;
            return FALSE;
        } 
    }

}
?>