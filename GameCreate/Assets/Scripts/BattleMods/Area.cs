using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Area : MonoBehaviour
{
    //Прогресс бары
    protected Slider playerScoreSlider;
    protected Slider enemyScoreSlider;
    //Очки заработанные командами
    protected float scorePlayer;
    protected float scoreEnemy;
    //количество членов команды в зоне
    protected int team1 = 0;
    protected int team2 = 0;

    private bool isGame = true;


    private void Awake()
    {
        if (GameObject.Find("Slider Player") != null)
        {
            playerScoreSlider = GameObject.Find("Slider Player").GetComponent<Slider>();
        }
        if (GameObject.Find("Slider Enemy") != null) { enemyScoreSlider = GameObject.Find("Slider Enemy").GetComponent<Slider>(); }
    }

    void Update()
    {
        SetScore();
        CheckProgress();        
    }

    protected virtual void SetScore()//начисление очков и обновление шкалы захвата
    {
        if (team1 > 0 && team2 == 0)
        {
            scorePlayer += 10 * Time.deltaTime;
        }
        else if (team2 > 0 && team1 == 0)
        {
            scoreEnemy += 10 * Time.deltaTime;
        }        
    }
    protected void CheckProgress()//проверяет набрано ли нужное для победы число очков захвата
    {
        if (playerScoreSlider != null)        {            playerScoreSlider.value = scorePlayer;        }//обновляет отображение прогресса
        if (enemyScoreSlider != null) { enemyScoreSlider.value = scoreEnemy; }
        team1 = 0;
        team2 = 0;

        if (scorePlayer>=100)
        {
            isGame = false;
            Debug.Log("Player's team win!");
        }
        else if(scoreEnemy >= 100)
        {
            isGame = false;
            Debug.Log("Enemy's team win!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            team1++;
        }
        if (other.CompareTag("Enemy"))
        {
            team2++;
        }
    }
}
