using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float bonds = 20;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.1f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector3 randomPos = new Vector3(Random.Range(-bonds,bonds), enemyPrefab.transform.position.y, Random.Range(-bonds, bonds));
        Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
    }
}
