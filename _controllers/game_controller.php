<?php

    if(isset($_GET['function'])){
        $dothis = $_GET['function'];
        switch($dothis){
            case 'newgame':
                NewGame();
                break;
            case 'save':
                SaveGame();
                break;
        }
    }

    /**
     * Start a new game
     */
    function NewGame(){
        // Set the game text
        $returnArray = array(
            "game" => "Cannot start a new game yet.",
            "player" => "Welcome new player!",
        );
        echo json_encode($returnArray);
    }

    /**
     * Save the game
     */
    function SaveGame(){
        try{
            $db = DB::getInstance();
            $command = "INSERT INTO games(LoginName, CharacterName, CurrentStage) VALUES (:loginname, :charname, :currentstage)";
            $query = $command->execute(array(
                ':loginname' => $_SESSION['current-user']->username,
                ':charname' => $_SESSION['character']->characterid,
                ':currentstage' => $_SESSION['current-stage']
            ));
            $result = $command->fetch(PDO::FETCH_ASSOC);
        }catch(PDOException $e){
            // That's an error
        }
    }
?>