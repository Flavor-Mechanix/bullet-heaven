using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject[] enemies;
    public GameObject player;
    public GameObject tickManagement;

    [Header("Spawn Parameters")]
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;
    [SerializeField] private float spawnRate;
    //public float gameLength = 0;
    
    [Header("Phase Timers")]
    public int timeToPhase1 = 70;
    public int timeToPhase2 = 70;

    private int stage = 0;
    // Start is called before the first frame update
    void Start()
    {
        tickManagement.GetComponent<TickManager>().OnTickIncrease += StageEnemies;
        InvokeRepeating("Spawner", 0f, spawnRate);
    }

    void Spawner()
    {
        SpawnEnemy(enemies[0]);

        if (stage == 1)
        {
            //TODO: also check if individual enemy spawn time has accrued
            SpawnEnemy(enemies[1]);
        }
        if (stage == 2)
        {
            //TODO: also check if individual enemy spawn time has accrued
            SpawnEnemy(enemies[2]);
        }
    }

    void StageEnemies(object sender, System.EventArgs e)
    {
        int currentTick = tickManagement.GetComponent<TickManager>().tickCount;

        if (currentTick > timeToPhase1 & currentTick < timeToPhase2)
        {
            stage = 1;
        }
        else if (currentTick >= timeToPhase2)
        {
            stage = 2;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, player.transform.position + new Vector3(Random.Range(-Mathf.Abs(maxDistance), maxDistance), Random.Range(-Mathf.Abs(maxDistance), maxDistance)), Quaternion.identity);
    }
}