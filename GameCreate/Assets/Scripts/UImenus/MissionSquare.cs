using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//������ ���������� ������ - ������ �� �����
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
    //�������� ��������� ������ ��� ������� ��������� � ����������� �� state
    public void SetState(bool state)
    {
        chosen = state;
        chosenImage.SetActive(chosen);
    }
    //��������� ���������, �������� ������ ����������� �� ����� (� ������� id)
    public void SetMission(Mission missionToSet)
    {
        mission = missionToSet.missionName;
        missinText.text = mission;

    }
}
