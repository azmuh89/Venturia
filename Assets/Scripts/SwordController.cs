using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : PlayerController
{
    public BoxCollider2D bc1, bc2, bc3, bc4;
    private PlayerController playerController;

    void Awake()
    {
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Direction();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (playerController.animator.GetLayerWeight(2) == 1f && Time.timeScale > 0)
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
