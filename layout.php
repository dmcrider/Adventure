<!DOCTYPE html lang="en">
<html>
<head>
    <title>Adventure</title>
    <link rel="stylesheet" href="_assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="_assets/css/custom.css">
    <script src="_assets/js/jquery.min.js"></script>
    <script src="_assets/js/popper.min.js"></script>
    <script src="_assets/js/bootstrap.min.js"></script>
</head>
<body class="container-fluid">
    <!-- Header -->
    <div class="row top-row">
        <?php require_once('_pages/nav.php'); ?>
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