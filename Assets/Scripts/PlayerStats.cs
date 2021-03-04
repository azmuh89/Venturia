using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int currentMana;
    [HideInInspector]
    public int currentEnergy;
    [HideInInspector]
    public int maxHealth;
    [HideInInspector]
    public int maxMana;
    [HideInInspector]
    public int maxEnergy;
    [HideInInspector]
    public int level;
    [HideInInspector]
    public string profession;
    [HideInInspector]
    public string adventurerRank;
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
        baseDamage = 5f,
        baseDefence = 3f,
        baseMDamage = 1f,
        baseMDefence = 2f,
        baseAim = 2f,
        baseEvasion = 1f;

    private int baseLuck = 1;

    private Weapon weapon;
    private Armor armor;
    private Accessories acc;
    private float baseMaxHealth = 15, baseMaxMana = 10, baseMaxEnergy = 10;
    private int _copper, _silver, _gold, _platinum;
    private int _currentExperience;
    public float maxExp = 100;

    public int CurrentExp
    {
        get { return _currentExperience; }
        set
        {
            _currentExperience = value;

            if (_currentExperience >= maxExp)
            {
                _currentExperience -= (int)maxExp;
                level++;
                maxExp += level * 50;
                baseMaxHealth += level * 5.5f;
                baseMaxMana += level * 2f;
                baseMaxEnergy += level;
                baseDamage += level * 0.5f;
                baseDefence += level * 0.4f;
                baseMDamage += 1;
                baseMDefence += level * 0.3f;
                baseAim += level * 0.07f;
                baseEvasion += level * 0.06f;
            }
        }
    }

    public int Copper
    {
        get { return _copper; }
        set
        {
            _copper = value;

            if (_copper >= 100)
            {
                _copper -= 100;
                Silver++;
            }
        }
    }
    public int Silver
    {
        get { return _silver; }
        set
        {
            _silver = value;

            if (_silver >= 100)
            {
                _silver -= 100;
                Gold++;
            }
        }
    }
    public int Gold
    {
        get { return _gold; }
        set
        {
            _gold = value;

            if (_gold >= 100)
            {
                _gold -= 100;
                Platinum++;
            }
        }
    }
    public int Platinum
    {
        get { return _platinum; }
        set { _platinum = value; }
    }

    void Awake()
    {
        //weapon = GetComponentInChildren<Weapon>();
        //weapon = transform.Find("Sword").GetComponent<Weapon>();
        armor = GetComponentInChildren<Armor>();
        acc = GetComponentInChildren<Accessories>();
    }

    void Start()
    {
        level = 1;
        karma = 0;
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

        if (Input.GetKeyDown(KeyCode.F) && currentHealth > 0) // for testing purposes
        {
            currentHealth--;
        }

        if (Input.GetKeyDown(KeyCode.G) && currentMana > 0) // for testing purposes
        {
            currentMana--;
        }
        
        if (Input.GetKeyDown(KeyCode.M)) // for testing purposes
        {
            Copper += 5;
        }

        if (Input.GetKeyDown(KeyCode.L)) // for testing purposes
        {
            CurrentExp = (int)maxExp;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void TotalStats()
    {
        maxExp = (int)maxExp;
        maxHealth = (int)baseMaxHealth;// + armor.health + acc.health;
        maxMana = (int)baseMaxMana;// + armor.mana + acc.mana;
        maxEnergy = (int)baseMaxEnergy;// + armor.energy + acc.energy;
        damage = (int)baseDamage;// + weapon.damage;
        defence = (int)baseDefence;// + armor.defence + acc.defence;
        magicDamage = (int)baseMDamage;// + weapon.magicDamage;
        magicDefence = (int)baseMDefence;// + armor.magicDefence + acc.magicDefence;
        aim = baseAim;// + weapon.aim + acc.aim;
        evasion = baseEvasion;// + armor.evasion + acc.evasion;
        luck = baseLuck;// + weapon.luck + armor.luck + acc.luck;
    }

    void Die()
    {
        Debug.Log("Died");
    }
}
