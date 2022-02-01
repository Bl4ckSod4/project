using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleForArea : MonoBehaviour
{
    [SerializeField] Slider playerScoreSlider;
    [SerializeField] Slider enemyScoreSlider;
    private float scorePlayer;
    private float scoreEnemy;

    private bool isGame=true;

    int team1 = 0;
    int team2 = 0;

    // Update is called once per frame
    void Update()
    {
        SetScore();
        CheckProgress();

        team1 = 0;
        team2 = 0;

    }

    private void SetScore()//начисление очков и обновление шкалы захвата
    {
        if (team1 > 0 && team2 == 0)
        {
            scorePlayer += 10 * Time.deltaTime;
        }
        else if (team2 > 0 && team1 == 0)
        {
            scoreEnemy += 10 * Time.deltaTime;
        }

        playerScoreSlider.value = scorePlayer;
        enemyScoreSlider.value = scoreEnemy;
    }
    void CheckProgress()//проверяет набрано ли нужное для победы число очков захвата
    {
        if(scorePlayer>100)
        {
            isGame = false;
            Debug.Log("Player's team win!");
        }
        else if(scoreEnemy > 100)
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
