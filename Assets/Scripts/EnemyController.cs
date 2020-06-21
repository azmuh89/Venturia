using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public Healthbar healthbar;
    public float speed;
    public float startingDistance;
    public float stoppingDistance;

    public int maxHealth, maxMana;
    public int dropExperience;
    public float damage;
    public float defence;
    public float magicDamage;
    public float magicDefence;
    public float aim;
    public float evasion;
    
    private Transform target;
    private Rigidbody2D rb2d;
    private Vector2 direction;
    private Vector3 startPos;
    private PlayerStats playerStats;
    private int currentHealth;
    private int currentMana;
    private float setDistance;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

        currentHealth = maxHealth;
        currentMana = maxMana;
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
        else if (Vector2.Distance(transform.position, target.position) > startingDistance)
        {
            startingDistance = setDistance;
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }

        direction = transform.position - target.position;

        if (transform.position == transform.parent.position)
        {
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        if (playerStats.aim >= evasion && playerStats.aim <= (evasion * 2))
        {
            currentHealth -= (int)playerStats.damage;
            healthbar.SetHealth(currentHealth);
            rb2d.AddForce(direction.normalized * 20, ForceMode2D.Impulse);
        }
        else if (playerStats.aim > (evasion * 2))
        {
            currentHealth -= (int)(playerStats.damage * 2);
            healthbar.SetHealth(currentHealth);
            rb2d.AddForce(direction.normalized * 20, ForceMode2D.Impulse);
        }
        else if (playerStats.aim < evasion)
        {
            currentHealth -= (int)(playerStats.damage / 2);
            healthbar.SetHealth(currentHealth);
            rb2d.AddForce(direction.normalized * 20, ForceMode2D.Impulse);
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
        playerStats.experience += dropExperience;
    }
}
