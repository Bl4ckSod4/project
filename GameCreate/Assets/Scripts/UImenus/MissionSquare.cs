using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//скрипт выбираемой иконки - миссии на карте
public class MissionSquare : MonoBehaviour
{
    [SerializeField] string mission="default";
    [SerializeField] Text missinText;
    [SerializeField] GameObject chosenImage;
    private bool chosen = false;
    void Start()
    {
        SetState(false);
        missinText.text = mission;
    }
    private void OnMouseDown()
    {
        foreach (GameObject square in GameObject.FindGameObjectsWithTag("MissionSquare"))
        {
            square.GetComponent<MissionSquare>().SetState(false);
        }
        Hub.instanse.SetMission(mission);
        SetState(true);
    }
    //выделяет выбранную миссию или снимает выделение в зависимости от state
    public void SetState(bool state)
    {
        chosen = state;
        chosenImage.SetActive(chosen);
    }
    //назначает параметры, название миссии подписанной на карте (в будущем id)
    public void SetMission(Mission missionToSet)
    {
        mission = missionToSet.missionName;
        missinText.text = mission;

    }
}
