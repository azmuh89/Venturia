using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public Animator animator;
    public Healthbar healthbar;
    public GameObject enemyType;
    [Range(1, 4)]
    public int enemyCount = 1;
    [HideInInspector]
    public string enemyName;
    
    public int maxHealth, maxMana;
    public int dropExperience;
    //public int damage;
    //public int defence;
    //public int magicDamage;
    //public int magicDefence;
    //public float aim;
    //public float evasion;
    
    private PlayerStats playerStats;
    private IdleMovement idleMovement;
    private int currentHealth, currentMana;
    
    void Start()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
        idleMovement = GetComponent<IdleMovement>();

        enemyName = this.name;

        currentHealth = maxHealth;
        currentMana = maxMana;
    }
    
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            instance = this;
            SceneManager.LoadScene("Combat");
        }

        if (collision.gameObject.tag == "Attack")
        {
            Destroy(collision.gameObject);
            currentHealth -= (int)playerStats.damage;
            Debug.Log(name + " Health: " + currentHealth);
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
        playerStats.experience += dropExperience;
    }
}
