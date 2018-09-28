<?php
    if(isset($_POST['new-game'])){
        echo "Starting new game";
    }
?>
<div class="col-md-4 brand">
<h1>Adventure</h1>
</div>
<div class="col-md-4">
    
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
                <?php if($_GET['action'] != 'home') :  ?>
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