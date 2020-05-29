using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    public Transform player;
    public int sortingOrder;
    public int newOrder;
    public float yLimit;

    SpriteRenderer spriteRenderer;
    float tempPos;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tempPos = this.transform.position.y;
    }
    
    void Update()
    {
        if (player.transform.position.y > tempPos + yLimit)
        {
            spriteRenderer.sortingOrder = newOrder;
        }
        else
        {
            spriteRenderer.sortingOrder = sortingOrder;
        }
    }
}
