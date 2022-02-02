using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaAttack : Area//��������� ����� ����� �� �������, ������������� �������� ����� SetScore, ��� ���������� ������� ������� �������
{
    [SerializeField] Text LoseCounter;
    [SerializeField] int timeToLoseMax = 10;//������ �� ���������, ���� � ������� ��� ���������� � ���� ����
    private int timeToLose = 10;
    private bool countDown = true;

    private void Update()
    {
        SetScore();
        CheckProgress();
    }
    protected override void SetScore()//���������� ����� � ���������� ����� �������, ����� �����������, ��������� ���� �� ���������� ����� � ���������
    {
        if (team1 > 0 && team2 == 0)
        {
           // LoseCounter.gameObject.SetActive( false);
            scorePlayer += 10 * Time.deltaTime;
        }
        else if (team2 > 0 && team1 == 0)
        {
        }
    }

    void CountDown()//���������� ������ ������� ��� ������������� ��������� �������, �� ��������� timeToLoseMax ������, ��������� �������� ����� ����� �����.
    {
        timeToLose--;
        LoseCounter.text = timeToLose.ToString();
        if (timeToLose<1)
        {
            scoreEnemy = 100;
            return;
        }
        countDown = true;
    }
}
