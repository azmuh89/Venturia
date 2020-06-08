using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject sword;
    public float moveSpeed = 5f;

    private static PlayerMovement instance;
    private Vector2 movement;
    private bool isRunning = false;

    private void Awake()
    {
        if (this.transform.name == "Player")
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

        Movement();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!isRunning)
            {
                animator.speed = 2;
                moveSpeed = 12f;
                isRunning = true;
            }
            else
            {
                animator.speed = 1;
                moveSpeed = 5f;
                isRunning = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (sword.activeInHierarchy && Time.timeScale > 0)
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Movement()
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
