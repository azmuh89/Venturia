using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public int maxSpawns;
    public int spawnDelay;
    public float spacing;

    private Vector3 randomPos;

    void Start()
    {
        InvokeRepeating("Spawn", 0, 3);
    }
    
    void Spawn()
    {
        if (transform.childCount < maxSpawns)
        {
            randomPos = transform.position + (Random.insideUnitSphere * spacing);
            Instantiate(enemy, randomPos, Quaternion.identity, gameObject.transform);
        }
    }
}
