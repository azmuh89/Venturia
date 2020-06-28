using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    public GameObject skillsSubButton, spellsSubButton;
    public GameObject[] enemySpawnPoint;

    private GameObject[] enemies;
    private Button attackButton, skillsButton,
        defendButton, itemsButton, escapeButton;

    private GameObject attackView, skillsView,
        defendView, itemsView, escapeView;

    private bool attacking;
    private bool playerTurn;
    private bool buttonHighlighted = true;
    private string baseName;
    private Button[] enemyName;

    void Awake()
    {
        Time.timeScale = 1;
        
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        baseName = enemies[enemies.Length - 1].name;

        System.Array.Reverse(enemies);

        enemyName = new Button[enemies.Length];

        for (int i = 0; i < enemies.Length; i++)
        {
            enemyName[i] = enemySpawnPoint[i].transform.Find("Canvas/NameButton").GetComponent<Button>();
            enemies[i].GetComponent<Animator>().SetBool("InCombat", true);
            enemies[i].name = baseName + " " + (i + 1);
            enemyName[i].GetComponentInChildren<Text>().text = enemies[i].name;
            enemyName[i].gameObject.SetActive(false);
        }
        
        FindButtons();
        FindMenus();
    }

    void Start()
    {
        playerTurn = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EventSystem.current.currentSelectedGameObject == skillsSubButton ||
            EventSystem.current.currentSelectedGameObject == spellsSubButton)
            {
                EventSystem.current.SetSelectedGameObject(skillsButton.gameObject);
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
        else if (!attacking && playerTurn)
        {
            if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Player_Combat_Idle"))
            {
                if (!buttonHighlighted)
                {
                    canvas.SetActive(true);

                    EventSystem.current.SetSelectedGameObject(attackButton.gameObject);
                    attackButton.OnSelect(new BaseEventData(EventSystem.current));
                    buttonHighlighted = true;
                }
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
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyName[i].gameObject.SetActive(true);
        }

        canvas.SetActive(false);
    }

    public void ChooseEnemy()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyController>().attacking = false;
            enemyName[i].gameObject.SetActive(false);
        }

        player.GetComponent<Animator>().SetTrigger("Attack");
        attacking = true;
        buttonHighlighted = false;
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
        attackButton = canvas.transform.Find("Choices/AttackButton").GetComponent<Button>();
        skillsButton = canvas.transform.Find("Choices/SkillsButton").GetComponent<Button>();
        defendButton = canvas.transform.Find("Choices/DefendButton").GetComponent<Button>();
        itemsButton = canvas.transform.Find("Choices/ItemsButton").GetComponent<Button>();
        escapeButton = canvas.transform.Find("Choices/EscapeButton").GetComponent<Button>();
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
