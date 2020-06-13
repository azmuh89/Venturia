using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Healthbar healthbar;
    public float maxHealth;

    [HideInInspector]
    public int experience;
    [HideInInspector]
    public int karma;
    [HideInInspector]
    public float
        damage,
        armor,
        magicDamage,
        magicResist,
        aim,
        evasion,
        luck;

    private int baseMaxHealth;
    private int baseMaxMana;
    private int baseMaxEnergy;

    private float
        baseDamage,
        baseArmor,
        baseMDamage,
        baseMResist,
        baseAim,
        baseEvasion,
        baseLuck;

    private int currentHealth, currentMana, currentEnergy;
    private int maxExp;
    private int level;
    private string profession;

    void Start()
    {
        healthbar.SetMaxHealth(baseMaxHealth);
        currentHealth = baseMaxHealth;
        currentMana = baseMaxMana;
        currentEnergy = baseMaxEnergy;

        level = 1;
        karma = 0;
        experience = 0;
        maxExp = 100;

        baseDamage = 5;
        baseArmor = 3;
        baseMDamage = 0;
        baseMResist = 0;
        baseAim = 2;
        baseEvasion = 1;
        baseLuck = 1;

        Stats();
    }
    
    void Update()
    {
        
    }

    void Stats()
    {
        // maxHealth = baseMaxHealth + armor.health;
        // damage = baseDamage + weapon.damage;
        // armor = baseArmor + armor.defence;
        // magicDamage = baseMDamage + magicWeapon.damage;
        // magicResist = baseMResist + armor.magicResist;
        // aim = baseAim + weapon.aim;
        // evasion = baseEvasion + armor.evasion;
    }

    void LevelUp()
    {
        level++;
        experience = 0;
        maxExp += level * 50;
        baseMaxHealth += level * 3;
        baseDamage += level * 0.6f;
        baseArmor += level * 0.375f;
        baseMDamage += level; // TODO
        baseMResist += level; // TODO
        baseAim += level * 0.33f;
        baseEvasion += level * 0.3f;
    }
}
