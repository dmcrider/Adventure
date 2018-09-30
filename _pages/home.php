<?php
    if(!isset($_SESSION['is-logged-in'])){
        header('Location: pages/login.php');
        die();
    }
?>
<!-- Left Panel - Game -->
<div class="col-md-9">
    <p id="game-text"></p>
    <hr>
    <p id="player-text"></p>
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
<script type="text/javascript">
// Start a new game
function StartNewGame(){
    /**
        Set the visibility of the Save button
    */
    var saveButton = document.getElementById("save-button");
    var newButton = document.getElementById("new-button");

    saveButton.style.display = "inline";
    newButton.style.display = "none";

    /**
        Update the Game and Player text.
        PHP takes care of some other things behind the scenes
    */
    $.ajax({
        url: '_controllers/game_controller.php',
        dataType: 'json',
        data: ({function: 'newgame'}),
        success: function(data) {
            $("#game-text").text(data.game);
            $("#player-text").text(data.player);
        }
    });

// This is not currently working
    $.ajax({
        url:'_models/Character.php',
        dataType: 'json',
        data: ({newchar: 'setnew'}),
        success: function(data){
            console.log(data);
            var characterName = document.getElementById("character-name");
            characterName.text = data.name;
        }
    });
}
/* */
</script>