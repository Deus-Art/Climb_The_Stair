using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject powerUpsPanel, losePanel, winPanel;
    public TextMeshProUGUI money_txt, scoreboard_txt, 
    stamina_cost_txt, income_cost_txt, speed_cost_txt,
    stamina_leveltxt, income_leveltxt, speed_leveltxt;
    public float level_one, scoreboard_value;


    [SerializeField] GameData data;
    PlayerController _playerController;
    

    void Start() 
    {
        level_one = -100f;
        scoreboard_value = level_one;
        _playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    void Update() 
    {
        
        MoneyTXT();
        ScoreboardTXT();
        PowerUpTexts();
        LosePanelActivate();
        HidePowerUps();

    }

    void MoneyTXT()
    {
        money_txt.text = " " + data.money_value.ToString("F0");
    }

    void ScoreboardTXT()
    {
        scoreboard_txt.text = "m " + scoreboard_value.ToString("F0");
    }

    void PowerUpTexts()
    {
        stamina_cost_txt.text = " " + data.stamina_base.ToString("F0");
        stamina_leveltxt.text = "LEVEL " + data.stamina_level.ToString();

        income_cost_txt.text = " " + data.income_base.ToString("F0");
        income_leveltxt.text = "LEVEL " + data.income_level.ToString();

        speed_cost_txt.text = " " + data.speed_base.ToString("F0");
        speed_leveltxt.text = "LEVEL " + data.speed_level.ToString();
    }

    public void StaminaPowerUpButton()
    {

        if(data.money_value >= data.stamina_base)
        {
            data.money_value -= data.income_base;
            data.stamina_base += data.stamina_increase;
            data.stamina_level += 1;
            data.maxStamina_value += 2;
            data.stamina_value = data.maxStamina_value;
        }
        SaveManager.SaveData(data);

    }

    public void IncomePowerUpButton()
    {
        if(data.money_value >= data.income_base)
        {
            data.money_value -= data.income_base;
            data.income_base += data.income_increase;
            data.income_level += 1;
            data.income_value += 0.5f;
        }
        SaveManager.SaveData(data);
    }

    public void SpeedPowerUpButton()
    {
        if(data.money_value >= data.speed_base)
        {
            data.money_value -= data.speed_base;
            data.speed_base += data.speed_increase;
            data.speed_level += 1;
            data.speed_value += 0.2f;
        }
        SaveManager.SaveData(data);

    }

    void HidePowerUps()
    {
        if(_playerController._isPlayerActing == true)
        {
            powerUpsPanel.SetActive(false);
        }
    }

    void LosePanelActivate()
    {
        if(data.stamina_value == 0)
        {
            losePanel.SetActive(true);
        }
    }

    public void WinPanelActivate()
    {
        winPanel.SetActive(true);
        _playerController.PlayerOnFinish();
    }

    

}
