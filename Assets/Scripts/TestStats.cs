using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStats : MonoBehaviour
{
    public float healthMod,
        damageMod,
        ArmorMod,
        MagicDmgMod,
        MagicResMod,
        AimMod,
        EvasionMod,
        ExpMod;

    private float health,
        damage,
        armor,
        magicDamage,
        magicResist,
        aim,
        evasion,
        maxExp,
        level;

    private void Start()
    {
        level = 1;
        maxExp = 100;
        health = 15;
        damage = 5;
        armor = 3;
        magicDamage = 0;
        magicResist = 0;
        aim = 2;
        evasion = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Level: " + level);
            Debug.Log("Max Health: " + health);
            Debug.Log("Damage: " + damage);
            Debug.Log("Armor: " + armor);
            Debug.Log("Magic Damage: " + magicDamage);
            Debug.Log("Magic Resist: " + magicResist);
            Debug.Log("Aim: " + aim);
            Debug.Log("Evasion: " + evasion);
            Debug.Log("Max Exp: " + maxExp);

            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        maxExp += level * ExpMod;
        health += level * healthMod;
        damage += level * damageMod;
        armor += level * ArmorMod;
        magicDamage += level * MagicDmgMod;
        magicResist += level * MagicResMod;
        aim += level * AimMod;
        evasion += level * EvasionMod;
    }
}
