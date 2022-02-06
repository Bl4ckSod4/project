using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//������������ ����� ��� ������� ����, �������� ������ �� �������� ����������, ������ �� ����� � �������� ������. ����������� � ������� ������������ ��� ������ ������� ����.
public class Area : MonoBehaviour
{
    
    [SerializeField] protected int ScoreToWin = 100;
    //�������� ����������� ���������
    protected Text playerScoreText;
    protected Text enemyScoreText;
    //�������� ����
    protected Slider playerScoreSlider;
    protected Slider enemyScoreSlider;
    //����������� �������
    protected Text timerText;
    //���� ������������ ���������
    protected float scorePlayer;
    protected float scoreEnemy;
    //���������� ������ ������� � ����
    public int team1 = 0;
    public int team2 = 0;
    //����� �� ����� ������ � ��������
    [SerializeField] protected float timeOut=10.0f;
    //��� � �������� ��� ��� (��������)
    public bool isGame = true;

    private void Awake()
    {
        UpdateSliders();
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        timerText.text = ((int)timeOut).ToString();
    }

    protected void UpdateSliders()//��������� ������ �� �������� ����������
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

    protected virtual void SetScore()//���������� ����� � ���������� ����� �������
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
    protected void CheckProgress()//��������� ������� �� ������ ��� ������ ����� ����� �������
    {
        if(!isGame)
        {
            return;
        }
        if (playerScoreSlider != null){ playerScoreSlider.value = scorePlayer;}//��������� ����������� ���������
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

    protected void ResultByTimeOut()//����� ������ ���������� ������ ����, ������� ���������� ����� � ��������� ���� �� ��� ���������
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
