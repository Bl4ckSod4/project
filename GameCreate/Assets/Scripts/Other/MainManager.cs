using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager instanse;

    public string reward = "Награда";
    public int screen = 0;
    // Start is called before the first frame update
    void Start()
    {
        instanse = this;
        if(Hub.instanse!=null)
        {
            Hub.instanse.SetScreen(0);
        }
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void ReturnHub(int screenTemp=5)
    {
        SceneManager.LoadScene("HubScreens");
        screen = screenTemp;
    }
}
