using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : PlayerStats
{
    public int teamPosition;//порядковый номер в отряде, либо в резерве
    public bool team = true;//находится ли боец в отряде, либо в резерве
    public PlayerStatsNoMono player; //параметры бойца

    [SerializeField] PlayerStats soldierModel;// ссылка на модель бойца, для изменения внешности
    [SerializeField] Text noteText; //текст над бойцом - его имя    

    private TeamManager teamManager;//скрипт казарм, настройки отряда

    private void Start()
    {
        if (GameObject.Find("Barraks Canvas") != null)
        {
            teamManager = GameObject.Find("Barraks Canvas").GetComponent<TeamManager>();
        }
    }
       
    public void SetToTeam() //Назначаем бойца из запаса в отряд, соответственно боец из отряда попадает в запас
    {
        PlayerStatsNoMono temp1 = MainManager.instanse.team[teamManager.teamPositionCurrent];
        PlayerStatsNoMono temp2 = player;
        MainManager.instanse.team[teamManager.teamPositionCurrent] = temp2;
        MainManager.instanse.barraks[teamPosition]=temp1;
        teamManager.ShowSquad();
    }
        
    public void ChangeInTeam()//Замена этого бойца в отряде на бойца из резерва на выбор
    {
        teamManager.ShowReserve(teamPosition);
    }
        
    public void PushChange()//Разный функционал кнопки "Заменить" для отряда и резерва
    {
        if (team)
        {
            ChangeInTeam();
        }
        else
        {
            SetToTeam();
        }
    }
        
    public void SetPlayer(PlayerStatsNoMono playerLocal)//Назначение конкретного бойца (экземпляр класса PlayerStats), в данную карточку
    {
        player = playerLocal;
        Init(player);
        noteText.text = player.nameFirst;
        noteText.text += "\n Здоровье: " + player.currentHealth;
        noteText.text += "\n Скорость: " + player.speed;
        noteText.text += "\n Цвет кожи: " + player.whiteskin;
    }

    public override void UpdateSoldier()//обновляет модель солдата, кожу, в будущем оружие и прочее
    {
        soldierModel.Init(player);
        soldierModel.UpdateSoldier();
    }
        
    public void OnMouseDown()//При клике по модели солдата, запускает его экипировку
    {
        teamManager.ShowSoldier(player);
    }
    
}
