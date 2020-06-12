using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public int maxSpawns;
    public int spawnDelay;
    public Vector3 randomPos;

    void Start()
    {
        randomPos = Random.insideUnitSphere * 5;
        InvokeRepeating("Spawn", 0, 3);
    }
    
    void Spawn()
    {
        if (transform.childCount < maxSpawns)
        {
            Instantiate(enemy, Random.insideUnitCircle * 5, Quaternion.identity, gameObject.transform);
        }
    }
}
