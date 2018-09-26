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

    public static function login($db, $command){
        try{
            $stmt = $db->prepare($command);
            $query = $stmt->execute(array($_POST['email']));
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
            if($result !== FALSE){
                $storedPassword = $result['password'];
                $hash = password_verify($_POST['password'], $storedPassword);

                if($hash){
                    // Successfull login
                    // Return the fields common to all users as well as the $result from the query
                    // so that the Agent and Client classes can get the other values unique to them
                    if($result['profile'] === NULL){
                        $result['profile'] = '_public/img/profile/default_profile.jpeg';
                    }

                    return array(array($result['id'], $result['firstname'], $result['lastname'], $result['email'], $result['username']), $result);
                }else{
                    $_SESSION['login_error'] = "Invalid password";
                    return FALSE;
                }
            }else{
                $_SESSION['login_error'] = "Invalid email";
                return FALSE;
            }
        } catch(PDOException $e){
            // Database error
            $_SESSION['db_error'] = "PDO Error: " . $e;
            return FALSE;
        } 
    }

}
?>