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
            $("#game-area").html(data.game);
            $("#player-area").html(data.player);
            $("#stage-title").text("Select Your Race");
            $("#current-stage").text("select-race");
        }
    });
}