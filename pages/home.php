<?php
    if(!isset($_SESSION['is-logged-in'])){
        header('Location: pages/login.php');
        die();
    }
    echo "You'll be able to see the homepage soon enough!";
    echo $_SESSION['current-user'];
    die();
?>