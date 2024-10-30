using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;


    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;

    private void Start()
    {
        enemiesLeftToSpawn = baseEnemies;
    }

    private int EnemiesPerWave()
    {
     return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, 0.75f ));
     
    }

}
