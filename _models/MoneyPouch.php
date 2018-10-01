<?php

class MoneyPouch{

    public $gold;
    public $silver;
    public $copper;

    public function __construct($class){
        try{
            $gold = 0;
            switch($class){
                case 'fighter':
                    //5d4 x 10
                    $gold = Sum(5,4,10);
                    break;
                case 'ranger':
                    // 5d4 x 10
                    $gold = Sum(5,4,10);
                    break;
                case 'rogue':
                    //4d4 x 10
                    $gold = Sum(4,4,10);
                    break;
                case 'wizard':
                    // 4d4 x 10
                    $gold = Sum(4,4,10);
                    break;
            }
            $db = DB::getInstance();
            $command = "INSERT INTO moneypouch(Gold) VALUES ($gold)";
            $db->exec($command);
            return $db->lastInsertId();
        }catch(PDOException $e){
            $_SESSION['error-message'] = $e;
        }        
    }

    private function Sum($count, $sides, $multiplier){
        $tempCount = 0;
        $sum = 0;
        while($tempCount < $count){
            $sum += rand(1,$sides);
        }
        $sum *= $multiplier;

        return $sum;
    }

    public function AddMoney($pouchid, $amount, $type){
        try{
            $db = DB::getInstance();
            $command = "UPDATE moneypouch SET $type=$amount WHERE PouchID=$pouchid";
            $db->exec($command);
        }catch(PDOException $e){
            $_SESSION['error-message'] = $e;
        }
    }
}
?>