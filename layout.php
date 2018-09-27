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
        <div class="col-md-4 brand"><!-- Logo goes here --></div>
        <div class="col-md-4 header">
            <h1>Adventure</h1>
        </div>
        <?php  // Only show the naviagation menu if the user is logged in ?>
        <?php if(isset($_SESSION['current-user'])) : ?>
            <div class="col-md-4 user">
                <button type="button" class="btn btn-primary outline dropdown-toggle" data-toggle="dropdown">
                    <img src="_assets/img/glyph-user.png">
                    <?php echo $_SESSION['current-user']->firstname ?>
                </button>
                <ul class="dropdown-menu">
                    <?php if(isset($_GET['action'])) : ?>
                        <?php if($_GET['action'] != '') :  ?>
                            <li class="dropdown-item"><a href="index.php?action=home"><img src="_assets/img/glyph-home.png"> Home</a></li>
                        <?php endif; ?>
                    <?php endif; ?>
                    <li class="dropdown-item"><a href="index.php?action=account"><img src="_assets/img/glyph-vcard.png"> My Account</a></li>
                    <li class="dropdown-item"><a href="index.php?action=logout"><img src="_assets/img/glyph-logout.png"> Logout</a></li>
                </ul>
            </div>
        <?php else : ?>
            <div class="col-md-4"></div>
        <?php endif; ?>
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