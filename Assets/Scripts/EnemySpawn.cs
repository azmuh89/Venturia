using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public int maxSpawns;
    public int spawnDelay;

    private Vector3 randomPos;

    void Start()
    {
        randomPos = transform.position + (Random.insideUnitSphere * 3);
        InvokeRepeating("Spawn", 0, 3);
    }
    
    void Spawn()
    {
        if (transform.childCount < maxSpawns)
        {
            Instantiate(enemy, randomPos, Quaternion.identity, gameObject.transform);
            randomPos = transform.position + (Random.insideUnitSphere * 3);
        }
    }
}
