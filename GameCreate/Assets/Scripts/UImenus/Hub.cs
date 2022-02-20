using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hub : MonoBehaviour
{
    public static Hub instanse;
    public Mission chosenMission;          //��������� ������

    [SerializeField] GameObject[] screens;   //������ ������� ����, �����, �����, ��������� � ��
    [SerializeField] Text moneyText;

    [SerializeField] Text missionRewardText;
    [SerializeField] Text missionNoteText;
    [SerializeField] Text missionResultText;          //������ �� ����� ������ �����������  

    void Awake()
    {        
        instanse = this;
    }

    private void Start()
    {
        SetScreen(MainManager.instanse.screen);
        chosenMission = MainManager.instanse.chosenMission;
        moneyText.text = "������: " + MainManager.instanse.account.money;
    }

    private void OnDestroy()
    {
        MainManager.instanse.chosenMission = chosenMission;
    }
        
    public void SetScreen(int screenNumber)//����� ������ ���� �� ��� ������
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
        SetMissionsSquare();
    }
           
    private void SetMissionsSquare()//����������� ������ �� ����� �� ��� ���� ������ � ����������� �� ������� � ���������� ��������, � ��� �� ������ ������
    {
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("MissionCard"))
        {
            i.GetComponent<MissionCard>().SetMission(null);
            foreach (Mission j in MainManager.instanse.missions)
            {     
                if(i.GetComponent<MissionCard>().region==j.region)
                {
                    i.GetComponent<MissionCard>().SetMission(j);
                    break;
                }
            }
        }
    }

    public void ShowTeam()//�������� �����
    {
        SetScreen(1);
        GameObject.Find("Barraks Canvas").GetComponent<TeamManager>().ShowSquad();
    }

    public void PrepareMission() //���������� ����� � ��������� �������� ������ � ������� �����������.
    {
        missionRewardText.text = "�������:\n " + chosenMission.rewardMoney + " G";
        missionRewardText.text += "\n" + chosenMission.rewardExp + " EXP";
        missionNoteText.text = "��������: \n " + chosenMission.note +
                               "\n �����������������: " + chosenMission.duration +
                               "\n ���������: " + chosenMission.difficulty;
        SetScreen(6);
    }

    public void StartMission()//�������� ��������� ������, � ��������� �����������
    {
        MainManager.instanse.SaveData();
        MainManager.instanse.chosenMission = chosenMission;
        SceneManager.LoadScene(chosenMission.sceneName);
    }
    private void SetReward()//������� ������� ����� ������ (���������� ���������, ����� ��������� ������ ��� ��������� � �����)
    {
        missionResultText.text = "�������:\n " + MainManager.instanse.chosenMission.rewardMoney + " G";
        missionResultText.text += "\n" + MainManager.instanse.chosenMission.rewardExp + " EXP";
        moneyText.text = "������: " + MainManager.instanse.account.money;
        MainManager.instanse.account.money += MainManager.instanse.chosenMission.rewardMoney;
        MainManager.instanse.account.exp += MainManager.instanse.chosenMission.rewardExp;
    }
}
