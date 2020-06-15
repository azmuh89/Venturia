using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Healthbar healthbar;
    public Text healthText, manaText, energyText,
        damageText, defenceText, mDamageText, mDefenceText,
        aimText, evasionText, levelText, experienceText,
        luckText, karmaText, professionText, adventurerRankText,
        copperText, silverText, goldText, platinumText;

    [HideInInspector]
    public int copper, silver, gold, platinum;
    [HideInInspector]
    public int experience;
    [HideInInspector]
    public int karma;
    [HideInInspector]
    public int luck;
    [HideInInspector]
    public float
        damage,
        defence,
        magicDamage,
        magicDefence,
        aim,
        evasion;
    
    private float
        baseDamage,
        baseDefence,
        baseMDamage,
        baseMDefence,
        baseAim,
        baseEvasion,
        baseLuck;

    private int baseMaxHealth, baseMaxMana, baseMaxEnergy;
    private int currentHealth, currentMana, currentEnergy;
    private int maxCopper, maxSilver, maxGold;
    private int maxExp;
    private int level;
    private string profession;
    private string adventurerRank;

    void Start()
    {
        healthbar.SetMaxHealth(baseMaxHealth);
        healthbar.SetMaxMana(baseMaxMana);
        healthbar.SetMaxEnergy(baseMaxEnergy);
        currentHealth = baseMaxHealth;
        currentMana = baseMaxMana;
        currentEnergy = baseMaxEnergy;

        damage = 1;
        level = 1;
        karma = 0;
        experience = 0;
        maxExp = 100;

        baseDamage = 5;
        baseDefence = 3;
        baseMDamage = 0;
        baseMDefence = 0;
        baseAim = 2;
        baseEvasion = 1;
        baseLuck = 1;

        profession = "N/A";
        adventurerRank = "N/A";

        TotalStats();
    }
    
    void Update()
    {
        SetStatsText();

        if (experience >= maxExp)
        {
            LevelUp();
        }
    }

    void TotalStats()
    {
        // maxHealth = baseMaxHealth + armor.health;
        // damage = baseDamage + weapon.damage + acc.damage;
        // defence = baseArmor + armor.defence + acc.armor;
        // magicDamage = baseMDamage + magicWeapon.damage + acc.magicDamage;
        // magicDefence = baseMResist + armor.magicResist + acc.magicResist;
        // aim = baseAim + weapon.aim + acc.aim;
        // evasion = baseEvasion + armor.evasion + acc.evasion;
    }

    void LevelUp()
    {
        level++;
        experience = 0;
        maxExp += level * 50;
        baseMaxHealth += level * 3;
        baseDamage += level * 0.6f;
        baseDefence += level * 0.375f;
        baseMDamage += level; // TODO
        baseMDefence += level; // TODO
        baseAim += level * 0.33f;
        baseEvasion += level * 0.3f;
    }

    void SetStatsText()
    {
        healthText.text = currentHealth + "/" + baseMaxHealth;
        manaText.text = currentMana + "/" + baseMaxMana;
        energyText.text = currentEnergy + "/" + baseMaxEnergy;
        damageText.text = damage.ToString("F1");
        defenceText.text = defence.ToString("F1");
        mDamageText.text = magicDamage.ToString("F1");
        mDefenceText.text = magicDefence.ToString("F1");
        aimText.text = aim.ToString("F2");
        evasionText.text = evasion.ToString("F2");
        levelText.text = level.ToString();
        experienceText.text = experience + "/" + maxExp;
        luckText.text = luck.ToString();
        karmaText.text = karma.ToString();
        professionText.text = profession;
        adventurerRankText.text = adventurerRank;
        copperText.text = copper.ToString();
        silverText.text = silver.ToString();
        goldText.text = gold.ToString();
        platinumText.text = platinum.ToString();
    }
}
