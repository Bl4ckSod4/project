using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hub : MonoBehaviour
{
    [SerializeField] GameObject[] screens;  //массив экранов Хаба, карта, отряд, настройки и тд
    public static Hub instanse;
    private string chosenMission;           //выбранная миссия    
    public Text reward;                     //ссылка на текст экрана награждения  
    public Text chosenMissionDescription;
    List<Mission> missions = new List<Mission>();
    void Awake()
    {
        instanse = this;
    }
    private void Start()
    {
        SetScreen(MainManager.instanse.screen);
    }
    //выбор экрана хаба по его номеру
    public void SetScreen(int screenNumber)
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
    }

    //Назначает выбранную миссию
    public void SetMission(string mission)
    {
        Debug.Log("Выбрана миссия: "+mission);
        chosenMission = mission;
        chosenMissionDescription.text += chosenMission;
    }

    //начинает выбранную миссию, с заданными параметрами
    public void StartMission()
    {
        SceneManager.LoadScene(chosenMission);
    }
    //Присваивает иконке на карте ту или иную миссию в зависимости от параметров (в будущем)
    private void SetMissionsSquare()
    {
        missions.Add(new Mission() { missionName = "Соревнование между ЧВК", sceneName = "Deathmatch", rewardMoney = 1000 });
        missions.Add(new Mission() { missionName = "Уничтожить ящики с оборудованием", sceneName = "ExplodeTargets", rewardMoney = 2000 });

        foreach (GameObject i in GameObject.FindGameObjectsWithTag("MissionSquares"))
        {

        }
    }

    public void SetReward()
    {
        reward.text+= MainManager.instanse.reward;
    }
}
