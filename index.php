<?php
    // Turn on error reporting
    ini_set('display_errors',1);
    error_reporting(E_ALL);
    
    // Include all the models
    require_once('_models/User.php');
    require_once('_models/Character.php');
    require_once('_models/Backpack.php');
    require_once('_models/Stats.php');
    require_once('_models/MoneyPouch.php');

    // Include the database connection
    require_once('_controllers/db_connection.php');

    // Include the other controllers
    require_once('_controllers/game_controller.php');
    require_once('_controllers/login_controller.php');

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