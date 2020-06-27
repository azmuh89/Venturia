using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float moveSpeed = 5f;

    [HideInInspector]
    public bool isRunning;
    [HideInInspector]
    public Vector2 movement;

    private static PlayerController instance;
    private PlayerStats stats;
    private Scene currentScene;

    void Awake()
    {
        stats = gameObject.GetComponent<PlayerStats>();
        currentScene = SceneManager.GetActiveScene();
        
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Combat" ||
            SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(gameObject);
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Direction();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (stats.currentEnergy > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!isRunning)
                {
                    moveSpeed = 12f;
                    isRunning = true;
                }
                else
                {
                    moveSpeed = 5f;
                    isRunning = false;
                }
            }
        }
        else
        {
            moveSpeed = 5f;
            isRunning = false;
        }
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Combat");
        }
    }
    
    void Direction()
    {
        if (movement.x != 0)
        {
            movement.y = 0;
        }
        else if (movement.y != 0)
        {
            movement.x = 0;
        }

        if (movement.x > 0)
        {
            animator.SetBool("MovingRight", true);
            animator.SetBool("MovingLeft", false);
            animator.SetBool("MovingUp", false);
            animator.SetBool("MovingDown", false);
        }
        else if (movement.x < 0)
        {
            animator.SetBool("MovingLeft", true);
            animator.SetBool("MovingUp", false);
            animator.SetBool("MovingDown", false);
            animator.SetBool("MovingRight", false);
        }
        else if (movement.y > 0)
        {
            animator.SetBool("MovingUp", true);
            animator.SetBool("MovingLeft", false);
            animator.SetBool("MovingDown", false);
            animator.SetBool("MovingRight", false);
        }
        else if (movement.y < 0)
        {
            animator.SetBool("MovingDown", true);
            animator.SetBool("MovingRight", false);
            animator.SetBool("MovingLeft", false);
            animator.SetBool("MovingUp", false);
        }
    }
}
