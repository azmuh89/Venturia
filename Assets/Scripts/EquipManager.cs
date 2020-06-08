using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManager : MonoBehaviour
{
    public Toggle swordToggle;
    public GameObject sword;

    void Awake()
    {
        swordToggle.isOn = false;
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
