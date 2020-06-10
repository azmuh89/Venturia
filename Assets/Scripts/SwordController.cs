using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : PlayerController
{
    public BoxCollider2D bc1, bc2, bc3, bc4;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Direction();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

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

        if (Input.GetMouseButtonDown(0))
        {
            if (this.gameObject.activeInHierarchy && Time.timeScale > 0)
            {
                Attack();
            }

            StartCoroutine("DisableColliders");
        }
    }

    void Attack()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (mousePosition.x > transform.position.x && mousePosition.y > transform.position.y - 3 && mousePosition.y < transform.position.y + 3)
        {
            animator.SetTrigger("AttackRight");
            bc4.enabled = true;
        }
        else if (mousePosition.x < transform.position.x && mousePosition.y > transform.position.y - 3 && mousePosition.y < transform.position.y + 3)
        {
            animator.SetTrigger("AttackLeft");
            bc2.enabled = true;
        }
        else if (mousePosition.y > transform.position.y)
        {
            animator.SetTrigger("AttackUp");
            bc3.enabled = true;
        }
        else if (mousePosition.y < transform.position.y)
        {
            animator.SetTrigger("AttackDown");
            bc1.enabled = true;
        }
    }

    IEnumerator DisableColliders()
    {
        yield return new WaitForSeconds(0.2f);

        bc1.enabled = false;
        bc2.enabled = false;
        bc3.enabled = false;
        bc4.enabled = false;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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
