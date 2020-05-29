using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    public float yLimit;

    private Transform player;
    private SpriteRenderer spriteRenderer;
    private int sortingOrder;
    private float Pos;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;
        Pos = this.transform.position.y;
    }
    
    void Update()
    {
        if (player.transform.position.y > Pos + yLimit)
        {
            spriteRenderer.sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }
        else
        {
            spriteRenderer.sortingOrder = sortingOrder;
        }
    }
}
