using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Healthbar healthbar;
    public int maxHealth = 10;
    public float speed;
    public float startingDistance;
    public float stoppingDistance;
    
    private Transform target;
    private Vector3 spawnPos;
    private int currentHealth;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        spawnPos = transform.position;
    }
    
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance &&
            Vector2.Distance(transform.position, target.position) < startingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        currentHealth -= SwordController.weaponDamage;
        healthbar.SetHealth(currentHealth);
    }
    
    void Die()
    {
        Destroy(gameObject);
        EnemySpawn.numOfSpawns--;
    }
}
