<?php
    if(!isset($_SESSION['is-logged-in'])){
        header('Location: pages/login.php');
        die();
    }
?>
<!-- Left Panel - Game -->
<div class="col-md-9">
    <div id="game-area" class="container-fluid"></div>
    <hr>
    <div id="player-area" class="container-fluid"></div>
</div>
<!-- Right Panel - Character information -->
<div class="col-md-3 outline-content">
    <div id="save-button" style="<?php if(!isset($_SESSION['character'])){echo "display:none;";} ?>">
        <button class="btn btn-primary" onclick="">Save Game</button>
        <hr>
        <p id="character-name"></p>
    </div>
    <div id="new-button" style="<?php if(isset($_SESSION['character'])){echo "display:none;";} ?>">
        <button class="btn btn-primary" id="startnewgame" onclick="StartNewGame()">New Game</button>
        <hr>
        <div id='no-character'>
            You do not have a character. Please start a new game.
        </div>
    </div>
</div>
<!-- Include all the scripts that help with functionality -->
<script>
    var currentSelection = "";
</script>
<script src="_functions/NewGame.js"></script>
<script src="_functions/SaveGame.js"></script>
<script src="_functions/NextStage.js"></script>
<script src="_functions/ShowDescriptions.js"></script>