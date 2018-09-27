<?php
    // require_once all the models
    require_once('_models/User.php');
    /*
    require_once('_models/Character.php');
    require_once('_models/Backpack.php');
    require_once('_models/Item.php');
    require_once('_models/Spell.php');
    require_once('_models/SpellBook.php');
    require_once('_models/Enemy.php');
    */

    // Include the database connection
    require_once('_controllers/connection.php');

    // Start a session
    session_start();

    if(!isset($_SESSION['is-logged-in'])){
        if(isset($_GET['action'])){
            $action = $_GET['action'];
            if($action != 'login' and $action != 'register'){
                $action = 'login';
            }
        }else{
            $action = "login";
        }
    }else{
        if(isset($_GET['action'])){
            $action = $_GET['action'];
        }else{
            $action = 'logout';
        }
    }
    
    require_once('layout.php');
?>