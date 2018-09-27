<?php
    if(!isset($_SESSION['is-logged-in'])){
        header('Location: pages/login.php');
        die();
    }
?>
<!DOCTYPE html lang="en">
<html>
<head>
    <title>Adventure</title>
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/custom.css">
</head>
<body class="container-fluid">
    <!-- Header -->
    <div class="row top-row">
        <div class="col-md-12" style="text-align:center;">
            <p>Adventure</p>
        </div>
    </div>
    <!-- Body -->
    <div class="row">
        <?php require_once('routes.php'); ?>
    </div>
    <!-- Footer -->
    <div class="row">
        <footer>
            <p class="text-muted">Copyright &copy 2018 Daylon Crider</p>
        </footer>
    </div>
</body>
</html>