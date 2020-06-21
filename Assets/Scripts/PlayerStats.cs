﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text deadText;
    public int currentHealth { get; private set; }
    public int currentMana { get; private set; }
    public int currentEnergy { get; private set; }
    public int maxHealth { get; private set; }
    public int maxMana { get; private set; }
    public int maxEnergy { get; private set; }
    public int maxExp { get; private set; }
    public int level { get; private set; }
    public string profession { get; private set; }
    public string adventurerRank { get; private set; }

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
    private EnemyController enemy;
    private PlayerController player;
    private int baseMaxHealth, baseMaxMana, baseMaxEnergy;
    private int maxCopper, maxSilver, maxGold;

    void Awake()
    {
        healthbar = GameObject.Find("HUDCanvas").GetComponentInChildren<Healthbar>();
        player = gameObject.GetComponent<PlayerController>();

        if (GameObject.FindGameObjectWithTag("Weapon") == null)
        {
            weapon = null;
        }
        else
        {
            weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
        }

        if (GameObject.FindGameObjectWithTag("Armor") == null)
        {
            armor = null;
        }
        else
        {
            armor = GameObject.FindGameObjectWithTag("Armor").GetComponent<Armor>();
        }

        if (GameObject.FindGameObjectWithTag("Accessory") == null)
        {
            acc = null;
        }
        else
        {
            acc = GameObject.FindGameObjectWithTag("Accessory").GetComponent<Accessories>();
        }
    }

    void Start()
    {
        baseMaxHealth = 15;
        baseMaxMana = 10;
        baseMaxEnergy = 10;

        healthbar.SetMaxHealth(baseMaxHealth);
        healthbar.SetMaxMana(baseMaxMana);
        healthbar.SetMaxEnergy(baseMaxEnergy);
        
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

        InvokeRepeating("Running", 0, 1);
        InvokeRepeating("NotRunning", 0, 30);
    }
    
    void Update()
    {
        if (healthbar == null)
        {
            healthbar = GameObject.Find("HUDCanvas").GetComponentInChildren<Healthbar>();
        }

        FindEnemy();
        TotalStats();

        if (experience >= maxExp)
        {
            LevelUp();
        }

        if (player.isRunning)
        {
        }
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHealth -= enemy.damage;
            healthbar.SetHealth(currentHealth);
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

    void FindEnemy()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        }
        else
        {
            enemy = null;
        }
    }

    void Running()
    {
        if (currentEnergy > 0 && player.isRunning && player.movement.magnitude > 0)
        {
            currentEnergy--;
            Debug.Log("Energy - 1");
            healthbar.SetEnergy(currentEnergy);
        }
    }

    void NotRunning()
    {
        if (currentEnergy < maxEnergy)
        {
            currentEnergy++;
            Debug.Log("Energy + 1");
            healthbar.SetEnergy(currentEnergy);
        }
    }

    void Die()
    {
        deadText.gameObject.SetActive(true);
    }
}
