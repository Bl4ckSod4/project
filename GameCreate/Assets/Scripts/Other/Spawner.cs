using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour//������ ������� ����� ������ 
{
    [SerializeField] GameObject[] spawnPoints;  //����� ������
    [SerializeField] GameObject spawnObject;    //��� ���������
    [SerializeField] GameObject wayPoint;       //����� ����������    
    [SerializeField] Area area;                 //������ �� ������ ���������� ����� �������� ������
    [SerializeField] string spawnTag;           //��� �������������� � ������� ������������ �����
    [SerializeField] int soldiersInTeamMax=4;   //�������� ������ � �������
    //[SerializeField] int spawnRate = 1;         //������� ������ � ��������

    private GameObject[] team;                  //����� � ������

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
    //����� �����
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
