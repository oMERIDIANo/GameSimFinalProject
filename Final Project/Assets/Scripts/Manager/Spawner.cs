using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] spawnPoints;
    public int enemyCount;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount < 4)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int random = Random.Range(0, 3);

        GameObject enemy = Instantiate(prefab, spawnPoints[random].transform.position, Quaternion.identity);

        enemyCount += 1;

        agent = enemy.GetComponent<NavMeshAgent>();

        int randomSpeed = Random.Range(4, 7);

        agent.speed = randomSpeed;   
    }
}
