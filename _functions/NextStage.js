function MoveToNextStage(){

    /**
        Update the Current Stage and Title.
    */
   $.ajax({
    url: '_controllers/game_controller.php',
    dataType: 'json',
    data: ({function: 'nextstage',current: $("#current-stage").text}),
    success: function(data) {
        $("#current-stage").text(data.stage);
        $("#stage-title").text(data.title);
    }
});
}