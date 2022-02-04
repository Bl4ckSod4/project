using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hub : MonoBehaviour
{
    public static Hub instanse;
    private string chosenMission;
    [SerializeField] GameObject[] screens;
    // Start is called before the first frame update
    void Start()
    {
        instanse = this;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
    public void SetMission(string mission)
    {
        chosenMission = mission;
    }

    public void StartMission()
    {
        SceneManager.LoadScene(chosenMission);
    }
}
