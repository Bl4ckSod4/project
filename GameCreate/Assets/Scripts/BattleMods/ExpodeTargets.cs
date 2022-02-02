using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpodeTargets : Area
{
    private int targetsCountStart;//сколько целей было в начале
    private int targetsCountCurrent;//сколько целей осталось

    [SerializeField] GameObject[] targets;//массив целей для уничтожения

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
    protected override void SetScore()//перезаписанный метод, определяет условия победы, когда все цели уничтожены счёт команды игрока становится 101
    {
        CheckTargets();
        scorePlayer = 101 - (100/ targetsCountStart) * targetsCountCurrent;
    }
    private void CheckTargets()//проверяет сколько осталось целей для уничтожения
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
