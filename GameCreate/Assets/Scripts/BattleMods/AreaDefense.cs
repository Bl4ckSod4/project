using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaDefense : Area//��������� ����� ����� �� �������, ������������� �������� ����� SetScore, ��� ���������� ������� ��������� �������
{
    [SerializeField] Text LoseCounter;
    [SerializeField] int timeToLoseMax = 10;//������ �� ���������, ���� � ������� ��� ���������� � ���� ����
    private int timeToLose = 10;
    private bool countDown = true;

    private void Update()
    {
        SetScore();
        CheckProgress();
        ResultByTimeOut();
    }
    protected override void SetScore()//���������� ����� � ���������� ����� �������, ����� �����������, ��������� ���� �� �������� ������ � ��������� ������ ��� �������� ��������� ����������
    {
        if (team1 > 0 && team2 == 0)
        {
            LoseCounter.gameObject.SetActive( false);
            timeToLose = timeToLoseMax;
            scorePlayer += 10 * Time.deltaTime;
        }
        else if (team2 > 0 && team1 == 0 && countDown)
        {
            Invoke("CountDown", 1);
            countDown = false;
            LoseCounter.text = timeToLose.ToString();
            LoseCounter.gameObject.SetActive(true);
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
