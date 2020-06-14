using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider manaSlider;
    public Slider energySlider;
    
    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    public void SetMaxMana(int mana)
    {
        if (manaSlider != null)
        {
            manaSlider.maxValue = mana;
            manaSlider.value = mana;
        }
    }

    public void SetMana(int mana)
    {
        if (manaSlider != null)
        {
            manaSlider.value = mana;
        }
    }

    public void SetMaxEnergy(int energy)
    {
        if (energySlider != null)
        {
            energySlider.maxValue = energy;
            energySlider.value = energy;
        }
    }

    public void SetEnergy(int energy)
    {
        if (energySlider != null)
        {
            energySlider.value = energy;
        }
    }
}
