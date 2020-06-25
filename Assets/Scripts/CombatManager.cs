using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CombatManager : MonoBehaviour
{
    public GameObject attackView, skillsView,
        spellsView, itemsView, escapeView;

    private Button attackButton, skillsButton,
        spellsButton, itemsButton, escapeButton;

    void Awake()
    {
        attackButton = GameObject.Find("Combat Canvas").transform.Find("Choices/AttackButton").GetComponent<Button>();
        skillsButton = GameObject.Find("Combat Canvas").transform.Find("Choices/SkillsButton").GetComponent<Button>();
        spellsButton = GameObject.Find("Combat Canvas").transform.Find("Choices/SpellsButton").GetComponent<Button>();
        itemsButton = GameObject.Find("Combat Canvas").transform.Find("Choices/ItemsButton").GetComponent<Button>();
        escapeButton = GameObject.Find("Combat Canvas").transform.Find("Choices/EscapeButton").GetComponent<Button>();
    }
    
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == attackButton.gameObject)
        {
            SelectedButton(attackView);
        }
        else if (EventSystem.current.currentSelectedGameObject == skillsButton.gameObject)
        {
            SelectedButton(skillsView);
        }
        else if (EventSystem.current.currentSelectedGameObject == spellsButton.gameObject)
        {
            SelectedButton(spellsView);
        }
        else if (EventSystem.current.currentSelectedGameObject == itemsButton.gameObject)
        {
            SelectedButton(itemsView);
        }
        else if (EventSystem.current.currentSelectedGameObject == escapeButton.gameObject)
        {
            SelectedButton(escapeView);
        }
    }

    void SelectedButton(GameObject activeObject)
    {
        attackView.SetActive(false);
        skillsView.SetActive(false);
        spellsView.SetActive(false);
        itemsView.SetActive(false);
        escapeView.SetActive(false);

        activeObject.gameObject.SetActive(true);
    }

    public void Attack()
    {
        Debug.Log("Attack");
    }

    public void Skills()
    {
        Debug.Log("Skills");
    }

    public void Spells()
    {
        Debug.Log("Spells");
    }

    public void Items()
    {
        Debug.Log("Items");
    }

    public void Escape()
    {
        Debug.Log("Escape");
    }
}
