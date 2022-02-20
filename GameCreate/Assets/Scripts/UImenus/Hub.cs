using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hub : MonoBehaviour
{
    public static Hub instanse;
    public Mission chosenMission;          //выбранная миссия

    [SerializeField] GameObject[] screens;   //массив экранов Хаба, карта, отряд, настройки и тд
    [SerializeField] Text moneyText;

    [SerializeField] Text missionRewardText;
    [SerializeField] Text missionNoteText;
    [SerializeField] Text missionResultText;          //ссылка на текст экрана награждения  

    void Awake()
    {        
        instanse = this;
    }

    private void Start()
    {
        SetScreen(MainManager.instanse.screen);
        chosenMission = MainManager.instanse.chosenMission;
        moneyText.text = "Деньги: " + MainManager.instanse.account.money;
    }

    private void OnDestroy()
    {
        MainManager.instanse.chosenMission = chosenMission;
    }
        
    public void SetScreen(int screenNumber)//выбор экрана хаба по его номеру
    {
        foreach (GameObject screen in screens)
        {
            screen.SetActive(false);
            if(screen==screens[screenNumber])
            {
                screen.SetActive(true);
            }
        }
        if (screenNumber==5)
        {
            SetReward();
        }
        SetMissionsSquare();
    }
           
    private void SetMissionsSquare()//Присваивает иконке на карте ту или иную миссию в зависимости от региона и параметров аккаунта, а так же взятых миссий
    {
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("MissionCard"))
        {
            i.GetComponent<MissionCard>().SetMission(null);
            foreach (Mission j in MainManager.instanse.missions)
            {     
                if(i.GetComponent<MissionCard>().region==j.region)
                {
                    i.GetComponent<MissionCard>().SetMission(j);
                    break;
                }
            }
        }
    }

    public void ShowTeam()//показать отряд
    {
        SetScreen(1);
        GameObject.Find("Barraks Canvas").GetComponent<TeamManager>().ShowSquad();
    }

    public void PrepareMission() //Показывает экран с подробным описание миссии и кнопкой отправиться.
    {
        missionRewardText.text = "Награда:\n " + chosenMission.rewardMoney + " G";
        missionRewardText.text += "\n" + chosenMission.rewardExp + " EXP";
        missionNoteText.text = "Описание: \n " + chosenMission.note +
                               "\n Продолжительнсоть: " + chosenMission.duration +
                               "\n Сложность: " + chosenMission.difficulty;
        SetScreen(6);
    }

    public void StartMission()//начинает выбранную миссию, с заданными параметрами
    {
        MainManager.instanse.SaveData();
        MainManager.instanse.chosenMission = chosenMission;
        SceneManager.LoadScene(chosenMission.sceneName);
    }
    private void SetReward()//выплата награды после миссии (необходимо расширить, чтобы учитывать победа или поражение и бонус)
    {
        missionResultText.text = "Награда:\n " + MainManager.instanse.chosenMission.rewardMoney + " G";
        missionResultText.text += "\n" + MainManager.instanse.chosenMission.rewardExp + " EXP";
        moneyText.text = "Деньги: " + MainManager.instanse.account.money;
        MainManager.instanse.account.money += MainManager.instanse.chosenMission.rewardMoney;
        MainManager.instanse.account.exp += MainManager.instanse.chosenMission.rewardExp;
    }
}
