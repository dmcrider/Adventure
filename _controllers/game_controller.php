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
            case 'nextstage':
                NextStage();
                break;
            case 'race':
                SaveRace();
                break;
        }
    }

    /**
     * Move to the next stage
     */
    function NextStage(){
        $currentStage = $_GET['current'];
        $newStage = "";
        $title = "";

        switch($currentStage){
            case 'select-race':
                $newStage = 'select-class';
                $title = 'Select Your Class';
                break;
        }

        $returnArray = array(
            "stage" => $newStage,
            "title" => $title,
        );

        echo json_encode($returnArray);
    }

    /**
     * Start a new game
     */
    function NewGame(){
        // Create an empty Character
        
        $gameHTML = "
            <div class='row'>
                <div class='col-md-4'>
                    <div class='row'>
                        <!-- Race Options go here -->
                        <div class='col-md-6'>
                            <button class='btn btn-primary options' onclick='ShowDescription(\"dwarf\")'>Dwarf</button>
                            
                            <button class='btn btn-primary options' onclick='ShowDescription(\"elf\")'>Elf</button>
                            <br>
                            <button class='btn btn-primary options' onclick='ShowDescription(\"halfling\")'>Halfling</button>
                            
                            <button class='btn btn-primary options' onclick='ShowDescription(\"human\")'>Human</button>
                        </div>
                    </div>
                </div>
                <!-- Race Descriptions go here -->
                <div class='col-md-8'>
                    <p id='description'></p>
                </div>
            </div>
        ";
        $playerHTML = "<button class='btn btn-primary' onclick='MoveToNextStage()'>Save &amp; Select Class</button>";
        // Set the game text
        $returnArray = array(
            "game" => $gameHTML,
            "player" => $playerHTML,
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