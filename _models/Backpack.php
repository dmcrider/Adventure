<?php

class Backpack{
    public function __construct($class, $dexmod){
        try{
            $db = DB::getInstance();
            $command = "INSERT INTO backpack(BackpackID) VALUES (NULL)";
            $db->exec($command);
            $backpackid = $db->lastInsertId();
            FillBackpack($class, $backpackid, $dexmod);
            return $backpackid;
        }catch(PDOException $e){
            $_SESSION['error-message'] = $e;
        }        
    }

    public function GetCurrentWeight(){
        // Add all the weights for each item in the backpack
        return;
    }

    private function FillBackpack($class, $id, $dexmod){
        // Figure out which default items to add
        switch($class){
            case 'fighter':
                AddItem($id, 'Chain Mail', 'Made of interlocking metal rings, Chain Mail helps reduce the impact of direct blows.', 55, 75, 16, NULL, 'Heavy', 13, false, NULL, NULL);
                AddItem($id, 'Shortsword', 'A bit longer than a dagger, a bit shorter than a longsword.', 2, 10, NULL, NULL, NULL, NULL, NULL, 6, 1);
                AddItem($id, 'Shield', 'Made of sturdy wood to help deflect attacks.', 6, 10, 2, NULL, 'Shield', 0, NULL, NULL, NULL);
                AddItem($id, 'Light Crossbow', 'A crossbow that can be wielded with one hand.', 5, 25, NULL, NULL, NULL, NULL, NULL, 8, 1);
                AddItem($id, 'Explorers Pack', 'Includes backpack, bedroll, mess kit, tinderbox, and 10 days of rations.', 59, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
                break;
            case 'ranger':
                AddItem($id, 'Leather', 'This armor is made of hard leather that has been stiffened by boiled oil.', 10, 10, 11, $dexmod, 'Light', 0, NULL, NULL, NULL);
                AddItem($id, 'Shortsword', 'A bit longer than a dagger, a bit shorter than a longsword.', 2, 10, NULL, NULL, NULL, NULL, NULL, 6, 1);
                AddItem($id, 'Shortsword', 'A bit longer than a dagger, a bit shorter than a longsword.', 2, 10, NULL, NULL, NULL, NULL, NULL, 6, 1);
                AddItem($id, 'Longbow', 'A slim, tall bow that is good for ranged attacks.', 2, 50, NULL, NULL, NULL, NULL, NULL, 8, 1);
                AddItem($id, 'Explorers Pack', 'Includes backpack, bedroll, mess kit, tinderbox, and 10 days of rations.', 59, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
                break;
            case 'rogue':
                AddItem($id, 'Shortsword', 'A bit longer than a dagger, a bit shorter than a longsword.', 2, 10, NULL, NULL, NULL, NULL, NULL, 6, 1);
                AddItem($id, 'Shortbow', 'A slim, short bow that is good for ranged attacks.', 2, 25, NULL, NULL, NULL, NULL, NULL, 6, 1);
                AddItem($id, 'Leather', 'This armor is made of hard leather that has been stiffened by boiled oil.', 10, 10, 11, $dexmod, 'Light', 0, NULL, NULL, NULL);
                AddItem($id, 'Dagger', 'A short, pointy sword, good for close-ranged attacks.', 1, 2, NULL, NULL, NULL, NULL, NULL, 4, 1);
                AddItem($id, 'Dagger', 'A short, pointy sword, good for close-ranged attacks.', 1, 2, NULL, NULL, NULL, NULL, NULL, 4, 1);
                AddItem($id, 'Explorers Pack', 'Includes backpack, bedroll, mess kit, tinderbox, and 10 days of rations.', 59, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
                break;
            case 'wizard':
                AddItem($id, 'Quarterstaff', 'Some might call it a walking stick with magical properties.', 4, .2, NULL, NULL, NULL, NULL, NULL, 6, 1);
                AddItem($id, 'Arcane Focus', 'A special item used to help channel the power of arcane spells.', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
                AddItem($id, 'Explorers Pack', 'Includes backpack, bedroll, mess kit, tinderbox, and 10 days of rations.', 59, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
                CreateSpellbook($id);
                break;
        }
    }

    private function CreateSpellbook($backpackid){
        try{
            AddSpell($backpackid,'Burning Hands','A thin flame shoots forth from your outstretched fingertips.',3,6);
            AddSpell($backpackid,'Magic Missile','Three darts of magical force shoot from your hand.',3,4);
            AddSpell($backpackid,'Ice Knife','A shard of ice appears in your hand.',2,6);
            AddSpell($backpackid,'Thunderwave','A wave of thunderous force sweeps out from you.',2,8);
            AddSpell($backpackid,'Shocking Grasp','Often mistaken for a static shock, this spell is a little more powerful.',1,8);
            AddSpell($backpackid,'Frostbite','A numbing cold takes over the enemy nearest you.',1,6);
        }catch(PDOException $e){
            $_SESSION['error-message'] = $e;
        }
    }

    private function AddSpell($id, $name, $description, $diecount, $dietype){
        try{
            $db = DB::getInstance();
            $command = "INSERT INTO spells(BackpackID, SpellName, Description, DieCount, DieType) VALUES (:id, :spellname, :description, :diecount, :dietype)";
            $query = $db->prepare($command);
    
            $results = $query->execute(array(
                ':id' => $id,
                ':spellname' => $name,
                ':description' => $acmod,
                ':dieCount' => $diecount,
                ':dieType' => $dietype
            ));
        }catch(PDOException $e){
            $_SESSION['error-message'] = $e;
        }
    }

    private function AddItem($id, $name, $description, $weight, $value, $acnumber, $acmod, $category, $minstr, $stealth, $dietype, $diecount){
        try{
            $db = DB::getInstance();
            $command = "INSERT INTO items(BackpackID, ItemName, Description, Weight, Value) VALUES (:backpackid, :itemname, :description, :weight, :value)";
            $query = $db->prepare($command);
    
            $results = $query->execute(array(
                ':backpackid' => $id,
                ':itemname' => $name,
                ':description' => $description,
                ':weight' => $weight,
                ':value' => $value
            ));
            $itemid = $db->lastInsertId();
            if($acnumber !== NULL){
                AddArmor($itemid, $acnumber, $acmod, $category, $minstr, $stealth);
            }
            if($dietype !== NULL){
                AddWeapon($itemid, $diecount, $dietype);
            }
        }catch(PDOException $e){
            $_SESSION['error-message'] = $e;
        }
    }

    private function AddArmor($id, $acnumber, $acmod, $category, $minstr, $stealth){
        try{
            $db = DB::getInstance();
            $command = "INSERT INTO armor(ItemID, ACNumber, ACMod, Category, MinSTR, Stealth) VALUES (:id, :acnumb, :acmod, :cat, :minstr, :stealth)";
            $query = $db->prepare($command);
    
            $results = $query->execute(array(
                ':id' => $id,
                ':acnumb' => $acnumber,
                ':acmod' => $acmod,
                ':cat' => $category,
                ':minstr' => $minstr,
                ':stealth' => $stealth
            ));
        }catch(PDOException $e){
            $_SESSION['error-message'] = $e;
        }
    }

    private function AddWeapon($id, $diecount, $dietype){
        try{
            $db = DB::getInstance();
            $command = "INSERT INTO weapon(ItemID, DieCount, DieType) VALUES (:id, :dieCount, :dieType)";
            $query = $db->prepare($command);
    
            $results = $query->execute(array(
                ':id' => $id,
                ':dieCount' => $diecount,
                ':dieType' => $dietype
            ));
        }catch(PDOException $e){
            $_SESSION['error-message'] = $e;
        }
    }
}
?>