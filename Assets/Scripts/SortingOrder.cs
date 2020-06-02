using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SortingOrder : MonoBehaviour
{
    public float yLimit;
    public bool Sprite, spriteGroup;
    
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private SortingGroup sortingGroup;
    private int sortingOrder;
    private int playerOrder;
    private float pos;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerOrder = player.GetComponent<SpriteRenderer>().sortingOrder;
        pos = this.transform.position.y;

        if (Sprite)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;
        }
        
        if (spriteGroup)
        {
            sortingGroup = GetComponent<SortingGroup>();
            sortingOrder = GetComponent<SortingGroup>().sortingOrder;
        }
    }
    
    void Update()
    {
        if (player.transform.position.y > pos + yLimit)
        {
            if (Sprite)
            {
                spriteRenderer.sortingOrder = playerOrder + 1;
            }
            else if (spriteGroup)
            {
                sortingGroup.sortingOrder = playerOrder + 1;
            }
        }
        else
        {
            if (Sprite)
            {
                spriteRenderer.sortingOrder = sortingOrder;
            }
            else if (spriteGroup)
            {
                sortingGroup.sortingOrder = sortingOrder;
            }
        }
    }
}
