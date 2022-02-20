using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//класс описывает миссию, все данные нужные для её загрузки, отображения, наград и тд
[System.Serializable]
public class Mission
{
    public int id = 0;
    public string missionName = "Дезматч";
    public string sceneName = "Deathmatch";
    public string region = "Africa";
    public string note = "Делец черного рынка предлагает заработать. " +
                        "Нужно сразиться с другим отрядом чвк, для развлечения богатых зрителей. " +
                        "Другое тренировочное поле.";

    public int rewardMoney = 1000;
    public int rewardExp = 100;

    public int difficulty = 1;
    public int duration = 120;

    //public string missionName { get; set; }
    //public int rewardMoney { get; set; }    
}
