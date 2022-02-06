using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour//скрипт создает новых бойцов 
{
    [SerializeField] GameObject[] spawnPoints;  //точки спавна
    [SerializeField] GameObject spawnObject;    //что спавнится
    [SerializeField] GameObject wayPoint;       //точка назначения    
    [SerializeField] Area area;                 //ссылка на объект содержащий скрип игрового режима
    [SerializeField] string spawnTag;           //Тэг принадлежности к команде создаваемого бойца
    [SerializeField] int soldiersInTeamMax=4;   //максимум бойцов в команде
    //[SerializeField] int spawnRate = 1;         //частота спавна в секундах

    private GameObject[] team;                  //бойцы в отряде

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
    //спавн бойца
    void Spawn()
    {
        GameObject temp= Instantiate(spawnObject,spawnPoints[Random.Range(0,spawnPoints.Length)].transform.position,spawnObject.transform.rotation);
        temp.tag = spawnTag;
        temp.name = spawnTag;
        temp.GetComponent<AIAgent>().waypoints[0] = wayPoint;
        temp.GetComponent<AIAgent>().waypoints[1] = wayPoint;
        temp.GetComponent<AIAgent>().waypoints[2] = wayPoint;
        temp.GetComponent<AIAgent>().waypoints[3] = wayPoint;
        
    }
}
