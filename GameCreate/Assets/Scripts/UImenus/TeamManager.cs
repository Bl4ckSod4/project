using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour //настройки отряда
{
    public int teamPositionCurrent;//редактируемое место в отряде
    public PlayerCard soldierGameObject;

    [SerializeField] GameObject soldierCard;
    [SerializeField] GameObject weaponCard;

    [SerializeField] GameObject teamCanvas;//ссылки на канвасы
    [SerializeField] GameObject reserveCanvas;
    [SerializeField] GameObject soldierCanvas;
    [SerializeField] GameObject weaponCanvas;

    [SerializeField] GameObject weaponPlaces;//еще какие-то ссылки
    [SerializeField] GameObject soldiersPlaces;

    
    [SerializeField] Text soldierNote;//ссылки для экрана настроек отдельного бойца
    [SerializeField] WeaponCard soldierWeaponCard;

    
    public void ShowSquad()//показывает бойцов в отряде
    {
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("WeaponCard"))
        {
            Destroy(i);
        }
        Clean();
        teamCanvas.SetActive(true);
        CreateSoldierCards(true);
    }
        
    public void ShowReserve(int pos)//показывает бойцов в запасе
    {
        teamPositionCurrent = pos;
        Clean();
        reserveCanvas.SetActive(true);
        CreateSoldierCards(false);
    }
        
    public void ShowSoldier(PlayerStatsNoMono stats)//показывает экран настройки бойца
    {
        Clean();     
        soldierCanvas.SetActive(true);
        soldierGameObject.SetPlayer(stats);
        soldierGameObject.UpdateSoldier();
        GameObject temp = (Resources.Load("weapon/" + stats.weapon, typeof(GameObject))) as GameObject;
        WeaponNoMono temp2= new WeaponNoMono();
        temp2.Init(temp.GetComponent<Weapon>());
        soldierWeaponCard.SetWeapon(temp2, soldierGameObject);
        soldierNote.text = soldierGameObject.nameFirst;
        soldierNote.text += "\n" + soldierGameObject.currentHealth;
        soldierNote.text += "\n" + soldierGameObject.speed;
    }
        
    public void ShowWeapons()//показывает экран выбора оружия
    {
        Clean();
        weaponCanvas.SetActive(true);
        CreateWeaponCards();
    }

    private void CreateWeaponCards()//создает последовательность карточек оружия которое не экипировано
    {
        float plusX = 500;
        foreach (WeaponNoMono i in MainManager.instanse.weapon)
        {
            if (i.equipped){ continue; }
            GameObject temp = Instantiate(weaponCard,weaponPlaces.transform);
            temp.transform.localPosition += weaponCard.transform.position + new Vector3(plusX, 550, 0);
            temp.GetComponent<WeaponCard>().SetWeapon(i, soldierGameObject);
            plusX += 550;
        }
    }

    private void Clean()
    {
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("PlayerSquare"))
        {
            Destroy(i);
        }
        reserveCanvas.SetActive(false);
        teamCanvas.SetActive(false);
        soldierCanvas.SetActive(false);
        weaponCanvas.SetActive(false);
    }
        
    public void CreateSoldierCards(bool team)//Создает последовательность карточек солдат из отряда, либо из запаса
    {
        float plusX = 1050;
        int num = 0;
        Transform place;
        List<PlayerStatsNoMono> command;        
        if (team)
        {
            place = teamCanvas.transform;
            command = MainManager.instanse.team;
        }
        else
        {
            place = reserveCanvas.transform;
            command = MainManager.instanse.barraks;

        }
        foreach (PlayerStatsNoMono i in command)
        {
            GameObject temp = Instantiate(soldierCard);
            if (team)
            {
                temp.transform.SetParent( place, true);
            }
            else
            {
                temp.transform.SetParent(soldiersPlaces.transform,true);
            }            
            temp.transform.localPosition += soldierCard.transform.position + new Vector3(plusX, 550, -100);            
            temp.GetComponent<PlayerCard>().SetPlayer(i);           
            temp.GetComponent<PlayerCard>().UpdateSoldier();
            temp.GetComponent<PlayerCard>().team = team;
            temp.GetComponent<PlayerCard>().teamPosition = num;
            num++;
            plusX += 250;
        }
    }
}
