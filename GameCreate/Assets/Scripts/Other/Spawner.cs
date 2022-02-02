using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;//точки спавна
    [SerializeField] GameObject spawnObject;//что спавнится
    [SerializeField] int spawnRate=1;//частота спавна в секундах
    [SerializeField] GameObject wayPoint;//точка назначения

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    void Spawn()//клон префаба бойца
    {
        GameObject temp= Instantiate(spawnObject,spawnPoints[Random.Range(0,spawnPoints.Length)].transform.position,spawnObject.transform.rotation);
        temp.GetComponent<AIAgent>().waypoints[0] = wayPoint;
        temp.GetComponent<AIAgent>().waypoints[1] = wayPoint;
    }

}
