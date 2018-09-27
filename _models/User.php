<?php

class User{
    private $id;
    private $firstname;
    private $lastname;
    private $email;
    private $username;

    public funtion __construct($id, $firstname, $lastname, $email, $username){
        $this->id = $id;
        $this->firstname = $fname;
        $this->lastname = $lname;
        $this->email = $email;
        $this->username = $username;
    }

    public static function Login(){
        try{
            // Set up the Database connection
            $db = DB::getInstance();
            $stmt = $db->prepare("SELECT * FROM users WHERE LoginName = ?");
            $query = $stmt->execute(array($_POST['loginname']));
            $result = $stmt->fetch(PDO::FETCH_ASSOC);

            // Determine if the login was succesfull
            if($result !== FALSE){
                $storedPassword = $result['password'];
                $hash = password_verify($_POST['password'], $storedPassword);

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
            $_SESSION['db-error'] = "PDO Error: " . $e;
            return FALSE;
        } 
    }

}
?>