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

    public GameObject swordSlash;
    private GameObject swordSlashClone;
    
    private GameObject[] enemies;
    private Button[] enemyName;
    private Vector3 playerPos;
    private Vector3[] enemyPos;
    private EnemyController enemy;

    private Button attackButton, skillsButton,
        defendButton, itemsButton, escapeButton;

    private GameObject attackView, skillsView,
        defendView, itemsView, escapeView;

    private int enemyChoice;
    private bool attacking;
    private bool playerTurn;
    private bool canvasActive = true;

    void Awake()
    {
        Time.timeScale = 1;

        enemy = EnemyController.instance;

        playerPos = player.transform.position;

        //System.Array.Reverse(enemies);

        enemies = new GameObject[enemy.enemyCount];
        enemyName = new Button[enemy.enemyCount];
        enemyPos = new Vector3[enemy.enemyCount];

        for (int i = 0; i < enemy.enemyCount; i++)
        {
            enemies[i] = Instantiate(enemy.enemyType, enemySpawnPoint[i].transform.position, Quaternion.identity);

            enemyName[i] = enemySpawnPoint[i].transform.Find("Canvas/NameButton").GetComponent<Button>();

            enemies[i].GetComponent<Animator>().SetBool("InCombat", true);
            enemies[i].name = enemy.enemyName + " " + (i + 1);

            enemyName[i].GetComponentInChildren<Text>().text = enemies[i].name;

            enemyPos[i] = enemies[i].transform.position;
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

            for (int i = 0; i < enemies.Length; i++)
            {
                if (EventSystem.current.currentSelectedGameObject == enemyName[i].gameObject)
                {
                    for (int j = 0; j < enemies.Length; j++)
                    {
                        enemyName[j].gameObject.SetActive(false);
                    }

                    canvas.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(attackButton.gameObject);
                }
            }
        }

        NavigationView();

        if (!attacking)
        {
            if (!canvasActive)
            {
                canvas.SetActive(true);

                EventSystem.current.SetSelectedGameObject(attackButton.gameObject);
                canvasActive = true;
            }
        }

        if (swordSlashClone != null)
        {
            swordSlashClone.transform.position = Vector3.MoveTowards(swordSlashClone.transform.position, enemySpawnPoint[enemyChoice].transform.position, 50 * Time.deltaTime);
        }
    }

    IEnumerator SwitchTurns()
    {
        yield return new WaitForSeconds(1f);

        if (playerTurn)
        {
            playerTurn = false;
            StartCoroutine(EnemyAttack());
        }
        else
        {
            playerTurn = true;
            attacking = false;
        }
    }

    IEnumerator EnemyAttack()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.position = playerPos + (Vector3.left * 2);
            enemies[i].GetComponent<BoxCollider2D>().enabled = true;
            yield return new WaitForSeconds(0.3f);
            enemies[i].GetComponent<Animator>().SetTrigger("Attack");
            yield return new WaitForSeconds(1f);
            enemies[i].transform.position = enemyPos[i];
            enemies[i].GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(0.2f);
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

    public void AttackEnemy(int enemy)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyName[i].gameObject.SetActive(false);
        }

        enemies[enemy].GetComponent<BoxCollider2D>().enabled = true;

        player.GetComponent<Animator>().SetTrigger("Attack");

        swordSlashClone = Instantiate(swordSlash, playerPos, Quaternion.identity);
        enemyChoice = enemy;
        attacking = true;
        canvasActive = false;

        StartCoroutine(SwitchTurns());
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
