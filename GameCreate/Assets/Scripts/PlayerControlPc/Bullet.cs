using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;//скорость пули
    private GameObject player;//ссылка на объект Игрок

    void Start()
    {        
        player = GameObject.Find("Player");//назначаю игрока
        transform.rotation = player.transform.rotation;//поворачиваю пулю в сторону куда смотрит игрок
        Invoke("DestroySelf",3);//запускаю таймер на 3 секунды, чтобы на сцене не копились пули
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);//перемещение пули вперёд, каждый кадр
    }

    void DestroySelf()//уничтожение пули
    {
        Destroy(gameObject);
    }
}
