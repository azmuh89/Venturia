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
    private Rigidbody2D rb2d;
    private Vector2 direction;
    private int currentHealth;
    private float setDistance;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        setDistance = startingDistance;
    }
    
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance &&
            Vector2.Distance(transform.position, target.position) < startingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
            startingDistance = setDistance * 2;
        }
        else
        {
            startingDistance = setDistance;
        }

        direction = transform.position - target.position;

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
        rb2d.AddForce(direction.normalized * 20, ForceMode2D.Impulse);
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
}
