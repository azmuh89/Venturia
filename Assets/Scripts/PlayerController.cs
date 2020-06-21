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
    public Vector2 movement;
    [HideInInspector]
    public bool isRunning;

    private static PlayerController instance;
    private PlayerStats stats;
    private Scene scene;
    private bool swordActive;

    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        stats = gameObject.GetComponent<PlayerStats>();

        if (scene.name == "MainMenu")
        {
            Destroy(gameObject);
        }

        if (this.gameObject.name == "Player")
        {
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
    }

    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!swordActive && animator.GetLayerWeight(1) == 1f)
            {
                swordActive = true;
                animator.SetLayerWeight(2, 1f);
            }
            else
            {
                swordActive = false;
                animator.SetLayerWeight(2, 0f);
            }
        }
    }
    
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void Direction()
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
