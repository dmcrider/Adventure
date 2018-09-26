<?php
    if(!isset($_SESSION['logged-in'])){
        header('Location: /pages/login.php');
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
</body>
</html>