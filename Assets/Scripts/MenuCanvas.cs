﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    public Text healthText, manaText, energyText,
        damageText, defenceText, mDamageText, mDefenceText,
        aimText, evasionText, levelText, experienceText,
        luckText, karmaText, professionText, adventurerRankText,
        copperText, silverText, goldText, platinumText;

    private PlayerStats playerStats;
    private Button firstSelectedButton;
    private bool isFullscreen = true;

    void Awake()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        firstSelectedButton = transform.Find("Choices/StatsButton").GetComponent<Button>();
    }

    void Update()
    {
        SetStatsText(); // maybe change later

        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.activeInHierarchy)
        {
            if (EventSystem.current.currentSelectedGameObject == GameObject.Find("QuestsButton"))
            {
                gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (isFullscreen)
            {
                Screen.SetResolution(1600, 900, false);
                isFullscreen = false;
            }
            else
            {
                Screen.SetResolution(1920, 1080, true);
                isFullscreen = true;
            }
        }
    }

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstSelectedButton.gameObject);
        firstSelectedButton.OnSelect(new BaseEventData(EventSystem.current));
    }

    void SetStatsText()
    {
        healthText.text = playerStats.currentHealth + "/" + playerStats.maxHealth;
        manaText.text = playerStats.currentMana + "/" + playerStats.maxMana;
        energyText.text = playerStats.currentEnergy + "/" + playerStats.maxEnergy;
        damageText.text = playerStats.damage.ToString("F1");
        defenceText.text = playerStats.defence.ToString("F1");
        mDamageText.text = playerStats.magicDamage.ToString("F1");
        mDefenceText.text = playerStats.magicDefence.ToString("F1");
        aimText.text = playerStats.aim.ToString("F2");
        evasionText.text = playerStats.evasion.ToString("F2");
        levelText.text = playerStats.level.ToString();
        experienceText.text = playerStats.CurrentExp + "/" + playerStats.maxExp;
        luckText.text = playerStats.luck.ToString();
        karmaText.text = playerStats.karma.ToString();
        professionText.text = playerStats.profession;
        adventurerRankText.text = playerStats.adventurerRank;
        copperText.text = playerStats.Copper.ToString();
        silverText.text = playerStats.Silver.ToString();
        goldText.text = playerStats.Gold.ToString();
        platinumText.text = playerStats.Platinum.ToString();
    }


    public void LoadScene(string sceneID)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneID);
        SceneFade.instance.Fade();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
