using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpodeTargets : Area
{
    private int targetsCountStart;//������� ����� ���� � ������
    private int targetsCountCurrent;//������� ����� ��������

    [SerializeField] GameObject[] targets;//������ ����� ��� �����������

    void Start()//�� ���� ������������� ������� ����� ����� ���������� ����� ��������
    {
        targets = GameObject.FindGameObjectsWithTag("TargetBox");
        targetsCountStart = targets.Length;
        ScoreToWin = targetsCountStart;
        UpdateSliders();
    }
    private void Update()
    {        
        SetScore();
        CheckProgress();
        playerScoreText.text +="/"+ScoreToWin.ToString();
        ResultByTimeOut();
    }
    protected override void SetScore()//�������������� �����, ���������� ������� ������
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
        scorePlayer = targetsCountStart - targetsCountCurrent;
    }
}
