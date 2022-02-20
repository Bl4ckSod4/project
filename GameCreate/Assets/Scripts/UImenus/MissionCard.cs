using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//������ ���������� ������ - ������ �� �����
public class MissionCard : MonoBehaviour
{
    public string region = "Africa";//������ ����� ������� ����� ����������� ������ �� ��� ������ ������ ������

    [SerializeField] Text missionText;//������ �� Text ������������ �������� �� �����
    [SerializeField] GameObject chosenImage; //������ �� ������ � ��� ��� ������� ������ ��� ������
    [SerializeField] GameObject objects; //������� ��� ����������� �������
    [SerializeField] GameObject[] difficultyIcons;//������� ������ �� ������ ���������� ������� ���������� ��������� ������
    [SerializeField] GameObject[] durationIcons;//-||- �����������������

    private bool chosen = false;//������� ��� ���
    private string missionName;//�������� ������
        
    void Awake()
    {
        SetState(false);
        missionText.text = "";
        objects.SetActive(false);
    }

    public void SetState(bool state)//�������� ��������� ������ ��� ������� ��������� � ����������� �� state
    {
        chosen = state;
        chosenImage.SetActive(chosen);
    }

    public void SetMission(Mission missionToSet)//��������� ���������, �������� ������ ����������� �� ����� (� ������� id)
    {
        if (missionToSet==null)
        {
            SetState(false);
            objects.SetActive(false);
            return;
        }
        objects.SetActive(true);
        missionName = missionToSet.missionName;
        missionText.text = missionName;
        SetIcons(difficultyIcons,missionToSet.difficulty);
        SetIcons(durationIcons, missionToSet.duration/120);
    }

    private void SetIcons(GameObject[] icons,int num) //������ �������� ������ ���������
    {
        int i = 0;
        while(i<icons.Length)
        {
            icons[i].SetActive(false);
            if (num>i)
            {
                icons[i].SetActive(true);
            }            
            i++;
        }
    }

    private void ChoseMission(string mission) //��������� ��������� ������
    {
        foreach (Mission i in MainManager.instanse.missions)
        {
            if (i.missionName == mission)
            {
                Hub.instanse.chosenMission = i;
                break;
            }
        }
    }

    public void OnClick()//���� �� ����� �������
    {
        foreach (GameObject mission in GameObject.FindGameObjectsWithTag("MissionCard"))
        {
            mission.GetComponent<MissionCard>().SetState(false);
        }
        ChoseMission(missionName);
        SetState(true);
    }
}
