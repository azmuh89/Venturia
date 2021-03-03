using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    public GameObject player;
    public GameObject endPanel;
    public GameObject[] enemySpawnPoint;

    public GameObject swordSlash;
    private GameObject swordSlashClone;
    
    private GameObject[] enemies;
    private GameObject buttonChoices;
    private GameObject buttonMenu;
    private Button[] enemyName;
    private Vector3 playerPos;
    private Vector3[] enemyPos;
    private Text expText, itemsText;
    private EnemyController enemy;
    private PlayerStats playerStats;
    private CombatEnemy enemyStats;

    private int enemyChoice;
    private bool attacking;
    private bool playerTurn;
    private bool canvasActive = true;

    void Awake()
    {
        Time.timeScale = 1;

        enemy = EnemyController.instance;
        playerStats = FindObjectOfType<PlayerStats>();

        playerPos = player.transform.position;

        buttonChoices = GameObject.Find("Choices");
        buttonMenu = GameObject.Find("AttackView");

        //System.Array.Reverse(enemies);

        enemies = new GameObject[enemy.enemyCount];
        enemyName = new Button[enemy.enemyCount];
        enemyPos = new Vector3[enemy.enemyCount];

        for (int i = 0; i < enemy.enemyCount; i++)
        {
            enemies[i] = Instantiate(enemy.enemyType, enemySpawnPoint[i].transform.position, Quaternion.identity);

            enemyName[i] = enemySpawnPoint[i].transform.Find("Canvas/NameButton").GetComponent<Button>();
            
            enemies[i].name = enemy.enemyName + " " + (i + 1);

            enemyName[i].GetComponentInChildren<Text>().text = enemies[i].name;

            enemyPos[i] = enemies[i].transform.position;
        }

        enemyStats = FindObjectOfType<CombatEnemy>();
    }

    void Start()
    {
        playerTurn = true;
    }

    void Update()
    {
        if (swordSlashClone != null)
        {
            swordSlashClone.transform.position = Vector3.MoveTowards(swordSlashClone.transform.position, enemySpawnPoint[enemyChoice].transform.position, 50 * Time.deltaTime);
        }

        if (enemy.enemyCount == 0)
        {
            EndCombat();
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                enemyName[i].gameObject.SetActive(false);
            }
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
            if (enemy.enemyCount > 0)
            {
                buttonChoices.SetActive(true);
                buttonMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(GameObject.Find("AttackButton"));
            }
            playerTurn = true;
            attacking = false;
        }
    }

    IEnumerator EnemyAttack()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
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
        }

        StartCoroutine(SwitchTurns());
    }

    public void Attack()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyName[i].gameObject.SetActive(true);
        }

        if (enemies[0] != null)
        {
            EventSystem.current.SetSelectedGameObject(enemyName[0].gameObject);
        }
        else if (enemies[1] != null)
        {
            EventSystem.current.SetSelectedGameObject(enemyName[1].gameObject);
        }
        else if (enemies[2] != null)
        {
            EventSystem.current.SetSelectedGameObject(enemyName[2].gameObject);
        }
        else if (enemies[3] != null)
        {
            EventSystem.current.SetSelectedGameObject(enemyName[3].gameObject);
        }

        buttonChoices.SetActive(false);
        buttonMenu.SetActive(false);
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
        SceneManager.LoadScene("PathToForest");
        playerStats.currentEnergy /= 2;
    }

    void EndCombat()
    {
        StopAllCoroutines();

        endPanel.SetActive(true);

        //playerStats.experience += enemyStats.dropExperience;
        //expText.text = "Gained " + enemyStats.dropExperience + " Experience";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("PathToForest");
        }
    }
}
