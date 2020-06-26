using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CombatManager : MonoBehaviour
{
    public Button skillsSubButton, spellsSubButton;

    private GameObject player;
    private GameObject[] enemy;
    private Button attackButton, skillsButton,
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
            if (EventSystem.current.currentSelectedGameObject == skillsSubButton.gameObject ||
            EventSystem.current.currentSelectedGameObject == spellsSubButton.gameObject)
            {
                EventSystem.current.SetSelectedGameObject(skillsButton.gameObject);
            }
        }

        NavigationView();
    }

    void NavigationView()
    {
        if (EventSystem.current.currentSelectedGameObject == attackButton.gameObject)
        {
            SelectedButton(attackView);
        }
        else if (EventSystem.current.currentSelectedGameObject == skillsButton.gameObject)
        {
            SelectedButton(skillsView);
        }
        else if (EventSystem.current.currentSelectedGameObject == defendButton.gameObject)
        {
            SelectedButton(defendView);
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

    void FindButtons()
    {
        attackButton = GameObject.Find("Combat Canvas").transform.Find("Choices/AttackButton").GetComponent<Button>();
        skillsButton = GameObject.Find("Combat Canvas").transform.Find("Choices/SkillsButton").GetComponent<Button>();
        defendButton = GameObject.Find("Combat Canvas").transform.Find("Choices/DefendButton").GetComponent<Button>();
        itemsButton = GameObject.Find("Combat Canvas").transform.Find("Choices/ItemsButton").GetComponent<Button>();
        escapeButton = GameObject.Find("Combat Canvas").transform.Find("Choices/EscapeButton").GetComponent<Button>();
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
