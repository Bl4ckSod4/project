using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAttack : Area//наследуем класс битвы за область, перезаписывая основной метод SetScore, для выполнения функций захвата области
{
    private void Update()
    {
        SetScore();
        CheckProgress();
        ResultByTimeOut();
    }
    //начисление очков и обновление шкалы захвата, метод перезаписан, начисляет очки за вытеснение врага и удержание
    
    protected override void SetScore()
    {  
        if (team1 > 0 && team2 == 0)
        {
            scorePlayer += 10 * Time.deltaTime;
        }
    }
 }
