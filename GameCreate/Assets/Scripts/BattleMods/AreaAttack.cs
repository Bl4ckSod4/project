using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaAttack : Area//наследуем класс битвы за область, перезаписывая основной метод SetScore, для выполнения функций захвата области
{
    [SerializeField] Text LoseCounter;
    [SerializeField] int timeToLoseMax = 10;//секунд до поражения, если в области нет защитников и есть враг
    private int timeToLose = 10;
    private bool countDown = true;

    private void Update()
    {
        SetScore();
        CheckProgress();
    }
    protected override void SetScore()//начисление очков и обновление шкалы захвата, метод перезаписан, начисляет очки за вытеснение врага и удержание
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

    void CountDown()//вызывается каждую секунду при доминировании вражеской команды, по истечении timeToLoseMax секунд, начисляет победное число очков врагу.
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
