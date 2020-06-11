using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public int maxSpawns;
    public int spawnDelay;
    public static int numOfSpawns;

    private Vector3 spawnPos;

    void Start()
    {
        numOfSpawns = 0;
        spawnPos = transform.position;

        InvokeRepeating("Spawn", 0, 3);
    }

    void Update()
    {
    }

    void Spawn()
    {
        if (numOfSpawns < maxSpawns)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
            numOfSpawns++;
        }
    }
}
