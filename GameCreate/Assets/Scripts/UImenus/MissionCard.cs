using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//скрипт выбираемой иконки - миссии на карте
public class MissionCard : MonoBehaviour
{
    public string region = "Africa";//Миссии этого региона могут назначаться только на эту кнопку выбора миссии

    [SerializeField] Text missionText;//ссылка на Text отображаемое название на карте
    [SerializeField] GameObject chosenImage; //ссылка на иконку о том что выбрана именно эта миссия
    [SerializeField] GameObject objects; //потомки для безопасного скрытия
    [SerializeField] GameObject[] difficultyIcons;//массивы ссылок на иконки количество которых обозначает сложность миссии
    [SerializeField] GameObject[] durationIcons;//-||- продолжительность

    private bool chosen = false;//выбрана или нет
    private string missionName;//название миссии
        
    void Awake()
    {
        SetState(false);
        missionText.text = "";
        objects.SetActive(false);
    }

    public void SetState(bool state)//выделяет выбранную миссию или снимает выделение в зависимости от state
    {
        chosen = state;
        chosenImage.SetActive(chosen);
    }

    public void SetMission(Mission missionToSet)//назначает параметры, название миссии подписанной на карте (в будущем id)
    {
        if (missionToSet==null)
        {
            SetState(false);
            objects.SetActive(false);
            return;
        }
        objects.SetActive(true);
        missionName = missionToSet.missionName;
        missionText.text = missionName;
        SetIcons(difficultyIcons,missionToSet.difficulty);
        SetIcons(durationIcons, missionToSet.duration/120);
    }

    private void SetIcons(GameObject[] icons,int num) //делает видимыми иконки сложности
    {
        int i = 0;
        while(i<icons.Length)
        {
            icons[i].SetActive(false);
            if (num>i)
            {
                icons[i].SetActive(true);
            }            
            i++;
        }
    }

    private void ChoseMission(string mission) //Назначает выбранную миссию
    {
        foreach (Mission i in MainManager.instanse.missions)
        {
            if (i.missionName == mission)
            {
                Hub.instanse.chosenMission = i;
                break;
            }
        }
    }

    public void OnClick()//клик по этому объекту
    {
        foreach (GameObject mission in GameObject.FindGameObjectsWithTag("MissionCard"))
        {
            mission.GetComponent<MissionCard>().SetState(false);
        }
        ChoseMission(missionName);
        SetState(true);
    }
}
