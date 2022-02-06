using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hub : MonoBehaviour
{
    [SerializeField] GameObject[] screens;  //������ ������� ����, �����, �����, ��������� � ��
    public static Hub instanse;
    private string chosenMission;           //��������� ������    
    public Text reward;                     //������ �� ����� ������ �����������  
    public Text chosenMissionDescription;
    List<Mission> missions = new List<Mission>();
    void Awake()
    {
        instanse = this;
    }
    private void Start()
    {
        SetScreen(MainManager.instanse.screen);
    }
    //����� ������ ���� �� ��� ������
    public void SetScreen(int screenNumber)
    {
        foreach (GameObject screen in screens)
        {
            screen.SetActive(false);
            if(screen==screens[screenNumber])
            {
                screen.SetActive(true);
            }
        }
        if (screenNumber==5)
        {
            SetReward();
        }
    }

    //��������� ��������� ������
    public void SetMission(string mission)
    {
        Debug.Log("������� ������: "+mission);
        chosenMission = mission;
        chosenMissionDescription.text += chosenMission;
    }

    //�������� ��������� ������, � ��������� �����������
    public void StartMission()
    {
        SceneManager.LoadScene(chosenMission);
    }
    //����������� ������ �� ����� �� ��� ���� ������ � ����������� �� ���������� (� �������)
    private void SetMissionsSquare()
    {
        missions.Add(new Mission() { missionName = "������������ ����� ���", sceneName = "Deathmatch", rewardMoney = 1000 });
        missions.Add(new Mission() { missionName = "���������� ����� � �������������", sceneName = "ExplodeTargets", rewardMoney = 2000 });

        foreach (GameObject i in GameObject.FindGameObjectsWithTag("MissionSquares"))
        {

        }
    }

    public void SetReward()
    {
        reward.text+= MainManager.instanse.reward;
    }
}
