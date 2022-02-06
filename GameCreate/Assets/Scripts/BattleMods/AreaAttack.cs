using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAttack : Area//��������� ����� ����� �� �������, ������������� �������� ����� SetScore, ��� ���������� ������� ������� �������
{
    private void Update()
    {
        SetScore();
        CheckProgress();
        ResultByTimeOut();
    }
    //���������� ����� � ���������� ����� �������, ����� �����������, ��������� ���� �� ���������� ����� � ���������
    
    protected override void SetScore()
    {  
        if (team1 > 0 && team2 == 0)
        {
            scorePlayer += 10 * Time.deltaTime;
        }
    }
 }
