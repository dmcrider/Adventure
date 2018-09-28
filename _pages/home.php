<?php
    if(!isset($_SESSION['is-logged-in'])){
        header('Location: pages/login.php');
        die();
    }
?>
<!-- Left Panel - Game -->
<div class="col-md-9">
</div>
<!-- Right Panel - Character information -->
<div class="col-md-3 outline-content">
    <?php if(isset($_SESSION['character'])) : ?>

        <hr>
        <button class="btn btn-primary" onclick="">Save Game</button>
    <?php else : ?>
        <div id='no-character'>
            You do not have a character. Please start a new game.
        </div>
        <hr>
        <button class="btn btn-primary" onclick="">New Game</button>
    <?php endif; ?>
</div>