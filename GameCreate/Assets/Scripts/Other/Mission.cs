using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����� ��������� ������, ��� ������ ������ ��� � ��������, �����������, ������ � ��
[System.Serializable]
public class Mission
{
    public int id = 0;
    public string missionName = "�������";
    public string sceneName = "Deathmatch";
    public string region = "Africa";
    public string note = "����� ������� ����� ���������� ����������. " +
                        "����� ��������� � ������ ������� ���, ��� ����������� ������� ��������. " +
                        "������ ������������� ����.";

    public int rewardMoney = 1000;
    public int rewardExp = 100;

    public int difficulty = 1;
    public int duration = 120;

    //public string missionName { get; set; }
    //public int rewardMoney { get; set; }    
}
