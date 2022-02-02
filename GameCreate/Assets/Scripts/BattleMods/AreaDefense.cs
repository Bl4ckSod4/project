using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaDefense : Area//наследуем класс битвы за область, перезаписывая основной метод SetScore, для выполнения функций удержания области
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
    protected override void SetScore()//начисление очков и обновление шкалы захвата, метод перезаписан, начисляет очки за успешную защиту и запускает таймер при успешных действиях противника
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
