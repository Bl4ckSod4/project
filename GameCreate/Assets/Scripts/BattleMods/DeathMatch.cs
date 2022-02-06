using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMatch : Area 
{
    void Update()
    {
        CheckProgress();
        ResultByTimeOut();
    }

    public override void UnitDie(string unitTag)//��������� ��� ������������� �����, ��������� ���� ��������������� �������
    {
        if(unitTag=="Player")
        {
            scoreEnemy++;
        }
        else if (unitTag == "Enemy")
        {
            scorePlayer++;
        }
    }
}
