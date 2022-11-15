using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "GameData")]
public class GameData : ScriptableObject
{
    [Header("Power Ups Base Money")] //STARTING COST
    public float stamina_base; 
    public float income_base;
    public float speed_base;

    [Header("Power Ups Increase Money")] //COST INCREASE
    public float stamina_increase; 
    public float income_increase;
    public float speed_increase;

    [Header("Power Ups Level Counts")]

    public float stamina_level;
    public float income_level;
    public float speed_level;


    [Header("In-Game Updates")] //INGAME EARNING VALUES

    public float money_value;
    public float maxStamina_value;
    public float stamina_value;
    public float income_value;
    public float speed_value;

        
}
