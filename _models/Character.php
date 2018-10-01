<?php
/*
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
*/

/**
 * TABLE characters:
 * CharacterID      int(11)
 * UserID           int(11)    Foreign key to users table
 * Name             varchar(50)
 * Race             varchar(50)
 * Class            varchar(50)
 * CLevel           varchar(50)
 * ExpPoints        int(11)
 * Strength         tinyint(3)
 * Dexterity        tinyint(3)
 * Constitution     tinyint(3)
 * Intelligence     tinyint(3)
 * Wisdom           tinyint(3)
 * Charisma         tinyint(3)
 * ArmorClass       tinyint(3)
 * BackpackID       int(11)     Foreign key to backpacks table
 * SpellBookID      int(11)     Foreign key to spellbooks table
 */
    class Character{
        // Variables
        public $userID;
        public $name;
        public $race;
        public $class;
        public $level;
        public $expPoints;
        public $strength;
        public $dexterity;
        public $constitution;
        public $intelligence;
        public $wisdom;
        public $charisma;
        public $armorClass;
        public $backpackID;
        public $spellbookID;

        public function __contruct($user){
            $this->userID = $user;
            $this->level = 0;
            $this->expPoints = 0;
        }

        public function CreateCharacter(){
            return;
        }
    }
?>