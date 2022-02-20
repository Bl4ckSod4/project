using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : PlayerStats
{
    public int teamPosition;//���������� ����� � ������, ���� � �������
    public bool team = true;//��������� �� ���� � ������, ���� � �������
    public PlayerStatsNoMono player; //��������� �����

    [SerializeField] PlayerStats soldierModel;// ������ �� ������ �����, ��� ��������� ���������
    [SerializeField] Text noteText; //����� ��� ������ - ��� ���    

    private TeamManager teamManager;//������ ������, ��������� ������

    private void Start()
    {
        if (GameObject.Find("Barraks Canvas") != null)
        {
            teamManager = GameObject.Find("Barraks Canvas").GetComponent<TeamManager>();
        }
    }
       
    public void SetToTeam() //��������� ����� �� ������ � �����, �������������� ���� �� ������ �������� � �����
    {
        PlayerStatsNoMono temp1 = MainManager.instanse.team[teamManager.teamPositionCurrent];
        PlayerStatsNoMono temp2 = player;
        MainManager.instanse.team[teamManager.teamPositionCurrent] = temp2;
        MainManager.instanse.barraks[teamPosition]=temp1;
        teamManager.ShowSquad();
    }
        
    public void ChangeInTeam()//������ ����� ����� � ������ �� ����� �� ������� �� �����
    {
        teamManager.ShowReserve(teamPosition);
    }
        
    public void PushChange()//������ ���������� ������ "��������" ��� ������ � �������
    {
        if (team)
        {
            ChangeInTeam();
        }
        else
        {
            SetToTeam();
        }
    }
        
    public void SetPlayer(PlayerStatsNoMono playerLocal)//���������� ����������� ����� (��������� ������ PlayerStats), � ������ ��������
    {
        player = playerLocal;
        Init(player);
        noteText.text = player.nameFirst;
        noteText.text += "\n ��������: " + player.currentHealth;
        noteText.text += "\n ��������: " + player.speed;
        noteText.text += "\n ���� ����: " + player.whiteskin;
    }

    public override void UpdateSoldier()//��������� ������ �������, ����, � ������� ������ � ������
    {
        soldierModel.Init(player);
        soldierModel.UpdateSoldier();
    }
        
    public void OnMouseDown()//��� ����� �� ������ �������, ��������� ��� ����������
    {
        teamManager.ShowSoldier(player);
    }
    
}
