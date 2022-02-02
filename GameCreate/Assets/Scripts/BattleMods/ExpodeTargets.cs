using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpodeTargets : Area
{
    private int targetsCountStart;//������� ����� ���� � ������
    private int targetsCountCurrent;//������� ����� ��������

    [SerializeField] GameObject[] targets;//������ ����� ��� �����������

    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("TargetBox");
        targetsCountStart = targets.Length;
    }
    private void Update()
    {        
        SetScore();
        CheckProgress();
    }
    protected override void SetScore()//�������������� �����, ���������� ������� ������, ����� ��� ���� ���������� ���� ������� ������ ���������� 101
    {
        CheckTargets();
        scorePlayer = 101 - (100/ targetsCountStart) * targetsCountCurrent;
    }
    private void CheckTargets()//��������� ������� �������� ����� ��� �����������
    {
        int temp = 0;
        foreach (GameObject target in targets)
        {
            if (target == null)
            {
                temp++;
            }
        }
        targetsCountCurrent = targetsCountStart - temp;
    }

}
