using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//–одительский класс дл€ режимов игры, содержит ссылки на элементы интерфейса, данные об очках и услови€х победы. –асшир€етс€ с помощью наследовани€ дл€ других режимов игры.
public class Area : MonoBehaviour
{
    
    [SerializeField] protected int ScoreToWin = 100;
    //„исловое отображение прогресса
    protected Text playerScoreText;
    protected Text enemyScoreText;
    //ѕрогресс бары
    protected Slider playerScoreSlider;
    protected Slider enemyScoreSlider;
    //ќтображение таймера
    protected Text timerText;
    //ќчки заработанные командами
    protected float scorePlayer;
    protected float scoreEnemy;
    //количество членов команды в зоне
    public int team1 = 0;
    public int team2 = 0;
    //врем€ до конца раунда в секундах
    [SerializeField] protected float timeOut=10.0f;
    //бой в процессе или нет (закончен)
    public bool isGame = true;

    private void Awake()
    {
        UpdateSliders();
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        timerText.text = ((int)timeOut).ToString();
    }

    protected void UpdateSliders()//загружает ссылки на элементы интерфейса
    {
        if (GameObject.Find("Slider Player") != null)
        {
            playerScoreSlider = GameObject.Find("Slider Player").GetComponent<Slider>();
            playerScoreSlider.maxValue = ScoreToWin;
        }
        if (GameObject.Find("Slider Enemy") != null)
        {
            enemyScoreSlider = GameObject.Find("Slider Enemy").GetComponent<Slider>();
            enemyScoreSlider.maxValue = ScoreToWin;
        }
        if (GameObject.Find("Counter Player") != null)
        {
            playerScoreText = GameObject.Find("Counter Player").GetComponent<Text>();
        }
        if (GameObject.Find("Counter Enemy") != null)
        {
            enemyScoreText = GameObject.Find("Counter Enemy").GetComponent<Text>();
        }
    }

    void Update()
    {
        SetScore();
        CheckProgress();
        ResultByTimeOut();
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
    protected void CheckProgress()//провер€ет набрано ли нужное дл€ победы число очков захвата
    {
        if(!isGame)
        {
            return;
        }
        if (playerScoreSlider != null){ playerScoreSlider.value = scorePlayer;}//обновл€ет отображение прогресса
        if (enemyScoreSlider != null) { enemyScoreSlider.value = scoreEnemy; }
        if (playerScoreText != null)
        {
            playerScoreText.text = scorePlayer.ToString(); }
        if (enemyScoreText != null)
        {
            enemyScoreText.text = scoreEnemy.ToString();
        }
        team1 = 0;
        team2 = 0;

        if (scorePlayer>= ScoreToWin)
        {
            isGame = false;
            Debug.Log("Player's team win!");
            GameManager.instance.SetGame(isGame);
        }
        else if(scoreEnemy >= ScoreToWin)
        {
            isGame = false;
            Debug.Log("Enemy's team win!");
            GameManager.instance.SetGame(isGame);
        }
        
    }

    protected void ResultByTimeOut()//метод должен вызыватьс€ каждый кадр, считает оставшеес€ врем€ и завершает игру по его истечении
    {        
        if(timeOut<=0)
        {
            isGame = false;
            Debug.Log("Time is Over");
            GameManager.instance.SetGame(isGame);
            return;
        }
        if (isGame)
        {
            timeOut -= Time.deltaTime;
            timerText.text = ((int)timeOut).ToString();
        }
     }
    public virtual void UnitDie(string unitTag)
    {

    }
}
