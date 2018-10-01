<?php

class Stats{
    public function __construct(){
        try{
            $db = DB::getInstance();
            $command = "INSERT INTO stats(StatsID) VALUES (NULL)";
            $db->exec($command);
            return $db->lastInsertId();
        }catch(PDOException $e){
            $_SESSION['error-message'] = $e;
        }        
    }
}
?>