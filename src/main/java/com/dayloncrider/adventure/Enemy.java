//package com.dayloncrider.adventure;
import java.io.FileReader;
import java.util.Iterator;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;

public class Enemy{
    // Instance variables
    private int health;
    private int attack;
    private int exp;
    private String type;

    public Enemy(String type, int hp, int atk, int exp){
        this.type = type;
        this.health = hp;
        this.attack = atk;
        this.exp = exp;
    }

    public void setHealth(int newHealthValue){
        this.health = newHealthValue;
    }

    public int getExperience(){
        return this.exp;
    }

    public int attack(){
        return this.attack;
    }

    public static Enemy CreateEnemy(String enemyType, String currentLevel){
        // Using example from https://stackoverflow.com/questions/10926353/how-to-read-json-file-into-java-with-simple-json-library
        JSONParser parser = new JSONParser();
        int health = 0;
        int attack = 0;
        int exp = 0;

        try{
            JSONArray jsonArray = (JSONArray) parser.parse(new FileReader("enemy.json"));

            for(Object obj : jsonArray){
                JSONObject level = (JSONObject) obj;
                System.out.println(level + "");
            }

        } catch (Exception e){
            e.printStackTrace();
        }
    }
}