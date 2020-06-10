﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManager : MonoBehaviour
{
    public Toggle swordToggle;
    private GameObject sword;

    void Awake()
    {
        sword = GameObject.FindGameObjectWithTag("Weapon");
        swordToggle.isOn = true;
    }

    public void EquipSword(bool isEquipped)
    {
        if (isEquipped)
        {
            sword.SetActive(true);
        }
        else
        {
            sword.SetActive(false);
        }
    }
}
