using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject skillsSubButton, spellsSubButton;

    private GameObject player;
    private GameObject[] enemies;
    private GameObject attackButton, skillsButton,
        defendButton, itemsButton, escapeButton;

    private GameObject attackView, skillsView,
        defendView, itemsView, escapeView;

    private bool attacking;
    private bool playerTurn, enemyTurn;
    private Vector3 playerPos;
    private Vector3[] enemyPos;

    void Awake()
    {
        Time.timeScale = 1;

        player = GameObject.Find("CombatPlayer");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Animator>().SetBool("InCombat", true);
        }

        playerPos = player.transform.position;

        enemyPos = new Vector3[enemies.Length];

        for (int i = 0; i < enemies.Length; i++)
        {
            enemyPos[i] = enemies[i].transform.position;
        }

        FindButtons();
        FindMenus();
    }

    void Start()
    {
        playerTurn = true;
        enemyTurn = false;
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

        if (attacking)
        {
            if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player_Combat_Idle"))
            {
                StartCoroutine(SwitchTurns());
            }
        }
        else
        {
            if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player_Combat_Idle"))
            {
                canvas.SetActive(true);
            }
        }
    }

    IEnumerator SwitchTurns()
    {
        yield return new WaitForSeconds(1f);

        if (playerTurn)
        {
            attacking = false;
            playerTurn = false;
            StartCoroutine(EnemyAttack());
        }
        else
        {
            playerTurn = true;
        }
    }

    IEnumerator EnemyAttack()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Animator>().SetTrigger("Attack");
            enemy.GetComponent<EnemyController>().attacking = true;
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(SwitchTurns());
    }

    public void Attack()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyController>().attacking = false;
        }

        player.GetComponent<Animator>().SetTrigger("Attack");
        canvas.SetActive(false);
        attacking = true;
    }

    public void Skills()
    {
        Debug.Log("Skills");
        //Maker later
    }

    public void Defend()
    {
        Debug.Log("Defend");
        //Multiply defence by 1.5
    }

    public void Items()
    {
        Debug.Log("Items");
        //Make later
    }

    public void Escape()
    {
        Debug.Log("Escape");
        //Costs half energy
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

    void SelectedButton(GameObject activeObject)
    {
        attackView.SetActive(false);
        skillsView.SetActive(false);
        defendView.SetActive(false);
        itemsView.SetActive(false);
        escapeView.SetActive(false);

        activeObject.gameObject.SetActive(true);
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
}
