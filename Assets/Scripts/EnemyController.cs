using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public Healthbar healthbar;

    public int maxHealth, maxMana;
    public int dropExperience;
    public int damage;
    public int defence;
    public int magicDamage;
    public int magicDefence;
    public float aim;
    public float evasion;
    
    private PlayerStats playerStats;
    private IdleMovement idleMovement;
    private int currentHealth, currentMana;

    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        idleMovement = GetComponent<IdleMovement>();

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }
    
    void Die()
    {
        Destroy(gameObject);
        playerStats.experience += dropExperience;
    }
}
