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
    
    require_once('layout.php');
?>