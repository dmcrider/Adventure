<?php
    if(isset($_GET['newchar'])){
        $dothis = $_GET['newchar'];
        switch($dothis){
            case 'setnew':
                CreateNewCharacter();
                break;
        }
    }

    function CreateNewCharacter(){
        $character = new Character("Unknown");
        echo json_encode($character->name);
    }

    class Character{
        // Variables
        public $name;

        public function __contruct($newName){
            $this->name = $newName;
        }
    }
?>