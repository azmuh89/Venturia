using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CombatManager : MonoBehaviour
{
    public GameObject skillsSubButton, spellsSubButton;

    private GameObject player;
    private GameObject[] enemy;
    private GameObject attackButton, skillsButton,
        defendButton, itemsButton, escapeButton;

    private GameObject attackView, skillsView,
        defendView, itemsView, escapeView;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        FindButtons();
        FindMenus();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EventSystem.current.currentSelectedGameObject == skillsSubButton ||
            EventSystem.current.currentSelectedGameObject == spellsSubButton)
            {
                EventSystem.current.SetSelectedGameObject(skillsButton);
            }
        }

        NavigationView();
    }

    void NavigationView()
    {
        if (EventSystem.current.currentSelectedGameObject == attackButton)
        {
            SelectedButton(attackView);
        }
        else if (EventSystem.current.currentSelectedGameObject == skillsButton)
        {
            SelectedButton(skillsView);
        }
        else if (EventSystem.current.currentSelectedGameObject == defendButton)
        {
            SelectedButton(defendView);
        }
        else if (EventSystem.current.currentSelectedGameObject == itemsButton)
        {
            SelectedButton(itemsView);
        }
        else if (EventSystem.current.currentSelectedGameObject == escapeButton)
        {
            SelectedButton(escapeView);
        }
    }

    void FindButtons()
    {
        attackButton = GameObject.Find("Combat Canvas").transform.Find("Choices/AttackButton").gameObject;
        skillsButton = GameObject.Find("Combat Canvas").transform.Find("Choices/SkillsButton").gameObject;
        defendButton = GameObject.Find("Combat Canvas").transform.Find("Choices/DefendButton").gameObject;
        itemsButton = GameObject.Find("Combat Canvas").transform.Find("Choices/ItemsButton").gameObject;
        escapeButton = GameObject.Find("Combat Canvas").transform.Find("Choices/EscapeButton").gameObject;
    }

    void FindMenus()
    {
        attackView = GameObject.Find("Combat Canvas").transform.Find("AttackView").gameObject;
        skillsView = GameObject.Find("Combat Canvas").transform.Find("SkillsView").gameObject;
        defendView = GameObject.Find("Combat Canvas").transform.Find("DefendView").gameObject;
        itemsView = GameObject.Find("Combat Canvas").transform.Find("ItemsView").gameObject;
        escapeView = GameObject.Find("Combat Canvas").transform.Find("EscapeView").gameObject;
    }

    void SelectedButton(GameObject activeObject)
    {
        attackView.SetActive(false);
        skillsView.SetActive(false);
        defendView.SetActive(false);
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
