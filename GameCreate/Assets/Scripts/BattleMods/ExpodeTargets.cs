using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpodeTargets : Area
{
    private int targetsCountStart;//сколько целей было в начале
    private int targetsCountCurrent;//сколько целей осталось

    [SerializeField] GameObject[] targets;//массив целей для уничтожения

    void Start()//по тэгу высчитывается сколько целей нужно уничтожить чтобы победить
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
    protected override void SetScore()//перезаписанный метод, определяет условия победы
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
