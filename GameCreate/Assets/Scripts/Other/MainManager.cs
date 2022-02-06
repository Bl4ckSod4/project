using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager instanse;
    //Переменная для информации о награде
    public string reward = "Награда";
    //Текущий экран хаба
    public int screen = 0;
    public int money = 0;

    //Дает доступ из любого места кода, по MainManager.instanse.
    void Start()
    {
        instanse = this;
        if(Hub.instanse!=null)
        {
            Hub.instanse.SetScreen(0);
        }
    }
    //Позволяет существовать в единственном экземпляре и независимо от загрузки сцен
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    //метод загружает сцену Хаб, принимает целое число в качестве номера подменю хаба 0 - выбор миссии 1- отряд и т.д.
    public void ReturnHub(int screenTemp=5)
    {
        SceneManager.LoadScene("Hub Screen");
        screen = screenTemp;
    }
}
