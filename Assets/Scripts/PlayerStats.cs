using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int currentHealth;
    public int currentMana;
    public int currentEnergy;
    public int maxHealth;
    public int maxMana;
    public int maxEnergy;
    //public int maxExp { get; private set; }
    public int level;
    public string profession;
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

    private Healthbar healthbar;
    private Weapon weapon;
    private Armor armor;
    private Accessories acc;
    private PlayerController player;
    private Text deadText;
    private float baseMaxHealth, baseMaxMana, baseMaxEnergy;
    private int _copper, _silver, _gold, _platinum;
    private int _currentExperience;
    public float maxExp = 35;

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
                maxExp *= 1.4f;
                baseMaxHealth *= 1.3f;
                baseMaxMana *= 1.2f;
                baseMaxEnergy *= 1.1f;
                baseDamage *= 1.175f;
                baseDefence *= 1.2f;
                baseMDamage *= 1.2f;
                baseMDefence *= 1.2f;
                baseAim *= 1.175f;
                baseEvasion *= 1.2f;
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
        healthbar = GameObject.Find("HUDCanvas").GetComponentInChildren<Healthbar>();
        deadText = GameObject.Find("HUDCanvas").transform.Find("Text").GetComponent<Text>();
        player = gameObject.GetComponent<PlayerController>();

        //weapon = GetComponentInChildren<Weapon>();
        //weapon = transform.Find("Sword").GetComponent<Weapon>();
        armor = GetComponentInChildren<Armor>();
        acc = GetComponentInChildren<Accessories>();
    }

    void Start()
    {
        baseMaxHealth = 15;
        baseMaxMana = 10;
        baseMaxEnergy = 10;

        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetMaxMana(maxMana);
        healthbar.SetMaxEnergy(maxEnergy);
        
        level = 1;
        karma = 0;
        //_currentExperience = 0;
        //maxExp = 35;

        //baseDamage = 5;
        //baseDefence = 3;
        //baseMDamage = 0;
        //baseMDefence = 0;
        //baseAim = 2;
        //baseEvasion = 1;
        //baseLuck = 1;

        profession = "N/A";
        adventurerRank = "N/A";

        TotalStats();

        currentHealth = maxHealth;
        currentMana = maxMana;
        currentEnergy = maxEnergy;

        if (player != null)
        {
            InvokeRepeating("Running", 0, 1);
            InvokeRepeating("NotRunning", 0, 30);
        }
    }
    
    void Update()
    {
        if (healthbar == null)
        {
            healthbar = GameObject.Find("HUDCanvas").GetComponentInChildren<Healthbar>();
            deadText = GameObject.Find("HUDCanvas").transform.Find("Text").GetComponent<Text>();
        }
        
        TotalStats();

        if (Input.GetKeyDown(KeyCode.F)) // for testing purposes
        {
            currentHealth--;
            healthbar.SetHealth(currentHealth);
        }

        if (Input.GetKeyDown(KeyCode.G)) // for testing purposes
        {
            currentMana--;
            healthbar.SetMana(currentMana);
        }
        
        if (Input.GetKeyDown(KeyCode.M)) // for testing purposes
        {
            Copper += 5;
        }

        if (Input.GetKeyDown(KeyCode.L)) // for testing purposes
        {
            CurrentExp += 1000;
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
        damage = baseDamage;// + weapon.damage;
        defence = baseDefence;// + armor.defence + acc.defence;
        magicDamage = baseMDamage;// + weapon.magicDamage;
        magicDefence = baseMDefence;// + armor.magicDefence + acc.magicDefence;
        aim = baseAim;// + weapon.aim + acc.aim;
        evasion = baseEvasion;// + armor.evasion + acc.evasion;
        luck = baseLuck;// + weapon.luck + armor.luck + acc.luck;
    }

    void Running()
    {
        if (currentEnergy > 0 && player.isRunning && player.movement.magnitude > 0)
        {
            currentEnergy--;
            healthbar.SetEnergy(currentEnergy);
        }
    }

    void NotRunning()
    {
        if (currentEnergy < maxEnergy)
        {
            currentEnergy++;
            healthbar.SetEnergy(currentEnergy);
        }
    }

    void Die()
    {
        deadText.gameObject.SetActive(true);
    }
}
