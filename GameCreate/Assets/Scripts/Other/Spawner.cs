using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour//скрипт создает новых бойцов 
{
    [Header ("Links")]
    [SerializeField] GameObject[] spawnPoints;  //точки спавна
    [SerializeField] GameObject spawnObject;    //префаб бойца
    [SerializeField] GameObject wayPoint;       //точка назначения    
    [SerializeField] Area area;                 //ссылка на объект содержащий скрип игрового режима

    [Header("Parameters")]
    [SerializeField] string spawnTag;           //Тэг принадлежности к команде создаваемого бойца
    [SerializeField] int soldiersInTeamMax=3;   //максимум бойцов в команде
    [SerializeField] int spawnRate = 3;         //задержка перед спавном в секундах
    [SerializeField] AIStateID currentState;    //стартовое поведение

    void Start()
    {
        List<PlayerStatsNoMono> squad;
        if (spawnTag == "Player")
        {
            squad = MainManager.instanse.team;
        }
        else
        {
            squad = MainManager.instanse.teamEnemy;
        }
        int i=0;
        foreach (PlayerStatsNoMono soldier in squad)
        {
            if (i<soldiersInTeamMax)
            {
                i++;
                Spawn(soldier.id);
            }            
        }
    }

     IEnumerator SpawnCoroutine(int id)//спавн бойца после задержки
    {
        yield return new WaitForSeconds(spawnRate);
        Spawn(id);
    }

    void Spawn(int id)//спавн бойца
    {
        GameObject temp = Instantiate(spawnObject, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, spawnObject.transform.rotation);
        temp.tag = spawnTag;
        temp.name = spawnTag;
        List<PlayerStatsNoMono> squad;
        if (spawnTag == "Player")
        {
            squad = MainManager.instanse.team;
            temp.GetComponent<AIAgent>().tagOpponent = "Enemy";
        }
        else
        {
            squad = MainManager.instanse.teamEnemy;
            temp.GetComponent<AIAgent>().tagOpponent = "Player";
        }
        temp.GetComponent<AIAgent>().initialState=currentState;
        temp.GetComponent<AIAgent>().waypoints[0] = wayPoint;
        temp.GetComponent<AIAgent>().waypoints[1] = wayPoint;
        temp.GetComponent<AIAgent>().waypoints[2] = wayPoint;
        temp.GetComponent<AIAgent>().waypoints[3] = wayPoint;
        foreach (PlayerStatsNoMono soldier in squad)
        {
            if (id == soldier.id)
            {
                temp.GetComponent<PlayerStats>().Init(soldier);
                temp.GetComponent<PlayerStats>().UpdateSoldier();
                break;
            }
        }
    }
       
    public void EnemyDie(int id,string tagDie)
    {
        if (tagDie == spawnTag&&GameManager.instanse.isGame)
        {
            area.UnitDie(tagDie);
            StartCoroutine(SpawnCoroutine(id));
        }
    }

}
