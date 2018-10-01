<?php
// TABLE: characters
/**`CharacterID` int(11) NOT NULL, PRIMERY KEY
  `Name` varchar(25) NOT NULL,
  `Race` varchar(25) NOT NULL,
  `CClass` varchar(25) NOT NULL,
  `CLevel` int(3) NOT NULL DEFAULT '1',
  `ExpPoints` int(10) NOT NULL DEFAULT '0',
  `ArmorClass` int(3) NOT NULL,
  `UserID` int(11) NOT NULL, FOREIGN KEY
  `MoneyPouchID` int(11) NOT NULL, FOREIGN KEY
  `StatsID` int(11) NOT NULL, FOREIGN KEY
  `BackpackID` int(11) NOT NULL, FOREIGN KEY
   */
    class Character{
        // Variables
        public $name;
        public $race;
        public $class;
        public $level;
        public $expPoints;
        public $armorClass;
        public $userID;  // Reference to users table
        public $money; // Reference to moneypouch table
        public $stats; // Reference to stats table
        public $backpackID; // Reference to backpack table

        public function __contruct($user, $name, $race, $class, $str, $strmod, $dex, $dexmod, $con, $conmod, $inte, $intmod, $wis, $wismod, $cha, $chamod){
            // Add foreign keys
            $this->userID = $user;
            $this->money = MoneyPouch($class);
            $this->stats = Stats($str, $strmod, $dex, $dexmod, $con, $conmod, $inte, $intmod, $wis, $wismod, $cha, $chamod);
            $this->backpackID = Backpack($class, $dexmod);

            // Set the other values
            $this->name = $name;
            $this->race = $race;
            $this->class = $class;
            $this->level = 1;
            $this->expPoints = 0;
            $this->armorClass = CalculateAC($dexmod, $this->backpackid);
        }

        private function CalculateAC($dexmod, $id){
            $ac = 10 + $dexmod;
            // Find out if any armor gives a bonus
            $db = DB::getInstance();
            $command = "SELECT SUM(ACNumber) FROM items, armor WHERE items.BackpackID=$id AND items.ItemID = armor.ItemID";
            $command->execute();

            $ac += $command->fetch(PDO::FETCH_ASSOC);

            return $ac;
        }

        public function CreateCharacter(){
            return;
        }
    }
?>