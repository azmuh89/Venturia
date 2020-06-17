using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    private Text healthText, manaText, energyText,
        damageText, defenceText, mDamageText, mDefenceText,
        aimText, evasionText, levelText, experienceText,
        luckText, karmaText, professionText, adventurerRankText,
        copperText, silverText, goldText, platinumText;
    
    private PlayerStats playerStats;

    void Awake()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        InitializeTexts();
    }

    void Update()
    {
        SetStatsText();
    }

    void InitializeTexts()
    {
        healthText = transform.Find("StatsMenu/HealthText/Health").GetComponent<Text>();
        manaText = transform.Find("StatsMenu/ManaText/Mana").GetComponent<Text>();
        energyText = transform.Find("StatsMenu/EnergyText/Energy").GetComponent<Text>();
        damageText = transform.Find("StatsMenu/DamageText/Damage").GetComponent<Text>();
        defenceText = transform.Find("StatsMenu/DefenceText/Defence").GetComponent<Text>();
        mDamageText = transform.Find("StatsMenu/MDamageText/MDamage").GetComponent<Text>();
        mDefenceText = transform.Find("StatsMenu/MDefenceText/MDefence").GetComponent<Text>();
        aimText = transform.Find("StatsMenu/AimText/Aim").GetComponent<Text>();
        evasionText = transform.Find("StatsMenu/EvasionText/Evasion").GetComponent<Text>();
        levelText = transform.Find("StatsMenu/LevelText/Level").GetComponent<Text>();
        experienceText = transform.Find("StatsMenu/ExpText/Experience").GetComponent<Text>();
        luckText = transform.Find("StatsMenu/LuckText/Luck").GetComponent<Text>();
        karmaText = transform.Find("StatsMenu/KarmaText/Karma").GetComponent<Text>();
        professionText = transform.Find("StatsMenu/ProfessionText/Class").GetComponent<Text>();
        adventurerRankText = transform.Find("StatsMenu/RankText/Rank").GetComponent<Text>();
        copperText = transform.Find("StatsMenu/CopperText/Copper").GetComponent<Text>();
        silverText = transform.Find("StatsMenu/SilverText/Silver").GetComponent<Text>();
        goldText = transform.Find("StatsMenu/GoldText/Gold").GetComponent<Text>();
        platinumText = transform.Find("StatsMenu/PlatText/Platinum").GetComponent<Text>();
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
        experienceText.text = playerStats.experience + "/" + playerStats.maxExp;
        luckText.text = playerStats.luck.ToString();
        karmaText.text = playerStats.karma.ToString();
        professionText.text = playerStats.profession;
        adventurerRankText.text = playerStats.adventurerRank;
        copperText.text = playerStats.copper.ToString();
        silverText.text = playerStats.silver.ToString();
        goldText.text = playerStats.gold.ToString();
        platinumText.text = playerStats.platinum.ToString();
    }
}
