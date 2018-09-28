<?php
    class GameController{
        /**
         * Start a new game
         */
        public function NewGame(){

        }

        /**
         * Save the game
         */
        public function SaveGame(){
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
    }
?>