using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hub : MonoBehaviour
{
    public static Hub instanse;
    private string chosenMission;
    [SerializeField] GameObject[] screens;
    //����� �������
    public Text reward;
    // Start is called before the first frame update
    void Awake()
    {
        instanse = this;
    }
    private void Start()
    {
        SetScreen(MainManager.instanse.screen);
    }
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
    public void SetMission(string mission)
    {
        Debug.Log("������� ������: "+mission);
        chosenMission = mission;
    }

    //�������� ��������� ������, � ��������� �����������
    public void StartMission()
    {
        SceneManager.LoadScene(chosenMission);
    }
    public void SetReward()
    {
        reward.text+= MainManager.instanse.reward;
    }
}
