using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : PlayerController
{
    public BoxCollider2D bc1, bc2, bc3, bc4;
    public int damage, magicDamage, aim, evasion;
    public int cost;

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
            //if (this.gameObject.activeInHierarchy)
            {
                animator.SetTrigger("Attack");
                EnableColliders();
            }

            StartCoroutine("DisableColliders");
        }
    }

    void EnableColliders()
    {
        if (animator.GetBool("MovingDown") == true)
        {
            bc1.enabled = true;
        }
        if (animator.GetBool("MovingLeft") == true)
        {
            bc2.enabled = true;
        }
        if (animator.GetBool("MovingUp") == true)
        {
            bc3.enabled = true;
        }
        if (animator.GetBool("MovingRight") == true)
        {
            bc4.enabled = true;
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
}
