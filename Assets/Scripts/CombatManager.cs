﻿using System.Collections;
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
    private Button[] enemyName;
    private Vector3 playerPos;
    private Vector3[] enemyPos;

    private Button attackButton, skillsButton,
        defendButton, itemsButton, escapeButton;

    private GameObject attackView, skillsView,
        defendView, itemsView, escapeView;

    private bool attacking;
    private bool playerTurn;
    private bool canvasActive = true;
    private string baseName;

    void Awake()
    {
        Time.timeScale = 1;

        playerPos = player.transform.position;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        baseName = enemies[enemies.Length - 1].name;

        System.Array.Reverse(enemies);

        enemyName = new Button[enemies.Length];
        enemyPos = new Vector3[enemies.Length];

        for (int i = 0; i < enemies.Length; i++)
        {
            enemyName[i] = enemySpawnPoint[i].transform.Find("Canvas/NameButton").GetComponent<Button>();

            enemies[i].GetComponent<Animator>().SetBool("InCombat", true);
            enemies[i].name = baseName + " " + (i + 1);

            enemyName[i].GetComponentInChildren<Text>().text = enemies[i].name;
            enemyName[i].gameObject.SetActive(false);

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

        if (player.transform.position == playerPos)
        {
            if (!canvasActive)
            {
                canvas.SetActive(true);

                EventSystem.current.SetSelectedGameObject(attackButton.gameObject);
                canvasActive = true;
            }
        }
    }

    IEnumerator SwitchTurns()
    {
        yield return new WaitForSeconds(0.5f);

        if (playerTurn)
        {
            playerTurn = false;
            StartCoroutine(EnemyAttack());
        }
        else
        {
            playerTurn = true;
            player.transform.position = playerPos;
        }
    }

    IEnumerator EnemyAttack()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.position = new Vector3(-3, 0);
            enemies[i].GetComponent<EnemyController>().attacking = true;
            yield return new WaitForSeconds(1f);
            enemies[i].transform.position = enemyPos[i];
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
            enemies[i].GetComponent<EnemyController>().attacking = false;
            enemyName[i].gameObject.SetActive(false);
        }

        player.transform.position = new Vector3(3, 0);

        if (enemy == 1)
        {
            enemies[0].transform.position = new Vector3(-3, 0);
        }
        else if (enemy == 2)
        {
            enemies[1].transform.position = new Vector3(-3, 0);
        }
        else if (enemy == 3)
        {
            enemies[2].transform.position = new Vector3(-3, 0);
        }
        else if (enemy == 4)
        {
            enemies[3].transform.position = new Vector3(-3, 0);
        }
        
        player.GetComponent<Animator>().SetTrigger("Attack");
        canvasActive = false;

        StartCoroutine(EndAttack());
    }

    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(2);

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.position = enemyPos[i];
        }

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
