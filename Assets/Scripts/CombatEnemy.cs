using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemy : MonoBehaviour
{
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
    private EnemyController enemyController;
    private int currentHealth, currentMana;

    void Start()
    {
        enemyController = EnemyController.instance;
        playerStats = FindObjectOfType<PlayerStats>();
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
        enemyController.enemyCount--;
    }
}
