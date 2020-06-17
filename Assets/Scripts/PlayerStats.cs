using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
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

    private Healthbar healthbar;
    private Weapon weapon;
    private Armor armor;
    private Accessories acc;
    private int baseMaxHealth, baseMaxMana, baseMaxEnergy;
    private int maxHealth, maxMana, maxEnergy;
    private int currentHealth, currentMana, currentEnergy;
    private int maxCopper, maxSilver, maxGold;
    private int maxExp;
    private int level;
    private string profession;
    private string adventurerRank;

    void Awake()
    {
        healthbar = GameObject.Find("HUDCanvas").GetComponentInChildren<Healthbar>();
        weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
        //armor = GameObject.FindGameObjectWithTag("Armor").GetComponent<Armor>();
        //acc = GameObject.FindGameObjectWithTag("Accessory").GetComponent<Accessories>();
    }

    void Start()
    {
        baseMaxHealth = 15;
        baseMaxMana = 10;
        baseMaxEnergy = 10;

        healthbar.SetMaxHealth(baseMaxHealth);
        healthbar.SetMaxMana(baseMaxMana);
        healthbar.SetMaxEnergy(baseMaxEnergy);

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

        currentHealth = maxHealth;
        currentMana = maxMana;
        currentEnergy = maxEnergy;
    }
    
    void Update()
    {
        TotalStats();
        SetStatsText();

        if (experience >= maxExp)
        {
            LevelUp();
        }
    }

    void TotalStats()
    {
        maxHealth = baseMaxHealth;// + armor.health + acc.health;
        maxMana = baseMaxMana;// + armor.mana + acc.mana;
        maxEnergy = baseMaxEnergy;// + armor.energy + acc.energy;
        damage = baseDamage + weapon.damage;
        defence = baseDefence;// + armor.defence + acc.defence;
        magicDamage = baseMDamage + weapon.magicDamage;
        magicDefence = baseMDefence;// + armor.magicDefence + acc.magicDefence;
        aim = baseAim + weapon.aim;// + acc.aim;
        evasion = baseEvasion;// + armor.evasion + acc.evasion;
    }

    void LevelUp()
    {
        level++;
        experience = 0;
        maxExp += level * 50;
        baseMaxHealth += level * 3;
        baseMaxMana += level * 2;
        baseMaxEnergy += level;
        baseDamage += level * 0.6f;
        baseDefence += level * 0.375f;
        baseMDamage += level; // TODO
        baseMDefence += level; // TODO
        baseAim += level * 0.33f;
        baseEvasion += level * 0.3f;
    }

    void SetStatsText()
    {
        healthText.text = currentHealth + "/" + maxHealth;
        manaText.text = currentMana + "/" + maxMana;
        energyText.text = currentEnergy + "/" + maxEnergy;
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
