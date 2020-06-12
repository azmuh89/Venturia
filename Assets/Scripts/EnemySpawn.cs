using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public int maxSpawns;
    public int spawnDelay;

    void Start()
    {
        InvokeRepeating("Spawn", 0, 3);
    }
    
    void Spawn()
    {
        if (transform.childCount < maxSpawns)
        {
            Instantiate(enemy, transform.position, Quaternion.identity, gameObject.transform);
        }
    }
}
