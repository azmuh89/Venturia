using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float startingDistance;
    public float stoppingDistance;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance &&
            Vector2.Distance(transform.position, target.position) < startingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
