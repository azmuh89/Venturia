using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CombatManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject skillsSubButton, spellsSubButton;

    private GameObject player;
    private GameObject[] enemy;
    private GameObject attackButton, skillsButton,
        defendButton, itemsButton, escapeButton;

    private GameObject attackView, skillsView,
        defendView, itemsView, escapeView;

    private bool attacking;

    void Awake()
    {
        player = GameObject.Find("CombatPlayer");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemies in enemy)
        {
            enemies.GetComponent<Animator>().SetBool("InCombat", true);
        }

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

        if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player_Combat_Idle"))
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }

        foreach (GameObject enemies in enemy)
        {
            if (enemies.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                canvas.SetActive(false);
            }
            else
            {
                canvas.SetActive(true);
            }
        }
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
        attackButton = canvas.transform.Find("Choices/AttackButton").gameObject;
        skillsButton = canvas.transform.Find("Choices/SkillsButton").gameObject;
        defendButton = canvas.transform.Find("Choices/DefendButton").gameObject;
        itemsButton = canvas.transform.Find("Choices/ItemsButton").gameObject;
        escapeButton = canvas.transform.Find("Choices/EscapeButton").gameObject;
    }

    void FindMenus()
    {
        attackView = canvas.transform.Find("AttackView").gameObject;
        skillsView = canvas.transform.Find("SkillsView").gameObject;
        defendView = canvas.transform.Find("DefendView").gameObject;
        itemsView = canvas.transform.Find("ItemsView").gameObject;
        escapeView = canvas.transform.Find("EscapeView").gameObject;
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
        player.GetComponent<Animator>().SetTrigger("Attack");
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
