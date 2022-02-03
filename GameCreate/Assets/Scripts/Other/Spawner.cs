using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour//скрипт создает новых бойцов 
{
    [SerializeField] GameObject[] spawnPoints;//точки спавна
    [SerializeField] GameObject spawnObject;//что спавнится
    [SerializeField] int spawnRate=1;//частота спавна в секундах
    [SerializeField] GameObject wayPoint;//точка назначения
    private GameObject[] team;
    [SerializeField] string spawnTag;
    private bool spawnBlock=false;
    [SerializeField] Area area;
    [SerializeField] int soldiersInTeamMax=4;

    void Start()
    {
        for (int i = 0; i < soldiersInTeamMax+1; i++)
        {
            Spawn();
        }
        team = GameObject.FindGameObjectsWithTag(spawnTag);
    }
    private void Update()
    {
        if (!area.isGame) { return; }
        team = GameObject.FindGameObjectsWithTag(spawnTag);
        if (team.Length< soldiersInTeamMax)
        {
            area.UnitDie(spawnTag);
            Spawn();
        }                  
    }

    void Spawn()//спавн бойца
    {
        GameObject temp= Instantiate(spawnObject,spawnPoints[Random.Range(0,spawnPoints.Length)].transform.position,spawnObject.transform.rotation);
        temp.tag = spawnTag;
        temp.name = spawnTag;
        temp.GetComponent<AIAgent>().waypoints[0] = wayPoint;
        temp.GetComponent<AIAgent>().waypoints[1] = wayPoint;
        temp.GetComponent<AIAgent>().waypoints[3] = wayPoint;
        temp.GetComponent<AIAgent>().waypoints[4] = wayPoint;
    }

}
