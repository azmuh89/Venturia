using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public Animator animator;
    public GameObject enemyType;
    [Range(1, 4)]
    public int enemyCount = 1;
    [HideInInspector]
    public string enemyName;
    
    private IdleMovement idleMovement;
    
    void Start()
    {
        idleMovement = GetComponent<IdleMovement>();

        enemyName = this.name;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            instance = this;
            SceneManager.LoadScene("Combat");
        }
    }
}
