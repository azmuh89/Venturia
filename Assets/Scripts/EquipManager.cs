using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManager : MonoBehaviour
{
    public Toggle swordToggle;
    private GameObject sword;
    private PlayerController playerController;

    void Awake()
    {
        sword = GameObject.Find("Player").transform.Find("Sword").gameObject;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        swordToggle.isOn = false;
    }

    public void EquipSword(bool isEquipped)
    {
        if (isEquipped)
        {
            sword.SetActive(true);
            playerController.animator.SetLayerWeight(1, 1f);
        }
        else
        {
            sword.SetActive(false);
            playerController.animator.SetLayerWeight(1, 0f);
        }
    }
}
