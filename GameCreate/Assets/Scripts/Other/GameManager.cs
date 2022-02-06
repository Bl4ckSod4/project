using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGame;

    [SerializeField] GameObject results;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
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
