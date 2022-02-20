using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instanse;

    public bool isGame=true;

    [SerializeField] GameObject results;

    void Awake()
    {
        instanse = this;
    }

    public void SetGame(bool state)
    {
        isGame = state;
        if(!isGame)
        {
            ShowResults();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

   void ShowResults()
    {
        Instantiate(results);
    }
}
