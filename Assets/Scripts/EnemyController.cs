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

    [HideInInspector]
    public bool attacking;

    private PlayerStats playerStats;
    private IdleMovement idleMovement;
    private int currentHealth, currentMana;

    void Start()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.name == "CombatPlayer")
        //{
        //    if (!attacking)
        //    {
        //        currentHealth -= (int)playerStats.damage;
        //        animator.SetTrigger("TakeDamage");
        //        Debug.Log("Enemy Health: " + currentHealth);
        //    }
        //}

        if (collision.gameObject.tag == "Attack")
        {
            Destroy(collision.gameObject);
            currentHealth -= (int)playerStats.damage;
            Debug.Log("Enemy Health: " + currentHealth);
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
        playerStats.experience += dropExperience;
    }
}
