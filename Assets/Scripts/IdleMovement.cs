using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMovement : MonoBehaviour
{
    public bool moveVertically, moveHorizontally;
    public float waitTime;
    public float distance;
    public float speed;

    private Vector3 positionUp, positionDown, positionRight, positionLeft;
    private Vector3 targetPos;

    void Start()
    {
        positionUp = transform.position + (Vector3.up * distance);
        positionDown = transform.position + (Vector3.down * distance);
        positionRight = transform.position + (Vector3.right * distance);
        positionLeft = transform.position + (Vector3.left * distance);

        if (moveVertically)
        {
            targetPos = positionUp;
        }

        if (moveHorizontally)
        {
            targetPos = positionRight;
        }
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (moveVertically)
        {
            StartCoroutine(MoveUp());
        }
        else if (moveHorizontally)
        {
            StartCoroutine(MoveRight());
        }
    }

    IEnumerator MoveUp()
    {
        targetPos = positionUp;
        
        yield return new WaitForSeconds(waitTime);
        
        StartCoroutine(MoveDown());
    }

    IEnumerator MoveDown()
    {
        targetPos = positionDown;

        yield return new WaitForSeconds(waitTime);

        StartCoroutine(MoveUp());
    }

    IEnumerator MoveRight()
    {
        targetPos = positionRight;

        yield return new WaitForSeconds(waitTime);
        
        StartCoroutine(MoveLeft());
    }

    IEnumerator MoveLeft()
    {
        targetPos = positionLeft;

        yield return new WaitForSeconds(waitTime);
        
        StartCoroutine(MoveRight());
    }
}
