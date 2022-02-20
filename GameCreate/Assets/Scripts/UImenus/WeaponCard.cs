using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCard : Weapon //карточка оружия, используется при покупке и экипировке
{
    public PlayerStats currentSoldier;
    public WeaponNoMono weapon;
    public Transform weaponPlace;

    [SerializeField] Text weaponDescription;
    [SerializeField] Text weaponPrice;

    private TeamManager teamManager;//ссылка на скрипт казарм, настройки отряда

    private void Start()
    {
        if (GameObject.Find("Barraks Canvas") != null)
        {
            teamManager = GameObject.Find("Barraks Canvas").GetComponent<TeamManager>();
        }
    }

    public void SetToSoldier()//замена оружия у солдата
    {
        foreach (WeaponNoMono i in MainManager.instanse.weapon)//оружие солдата попадает на склад
        {
            if (i.weaponName ==currentSoldier.weapon && i.equipped)
            {
                i.equipped = false;
                break;
            }
        }
        foreach (WeaponNoMono i in MainManager.instanse.weapon)//оружие со склада экипируется солдату
        {
            if (i.weaponName == weaponName && !i.equipped)
            {
                i.equipped = true;
                break;
            }
        }
        currentSoldier.weapon = weaponName;
        teamManager.soldierGameObject.weapon= weaponName;
        foreach(PlayerStatsNoMono i in MainManager.instanse.team)
        {
            if(i.id==currentSoldier.id)
            {
                i.Init(currentSoldier);
                break;
            }
        }
        teamManager.ShowSquad();
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("WeaponCard"))
        {
            Destroy(i);
        }
    }

    public void SetWeapon(WeaponNoMono weaponLocal, PlayerStats soldier)
    {
        Clean();
        weapon.Init(weaponLocal);
        currentSoldier = soldier;
        weaponColor = weaponLocal.weaponColor;
        weaponName = weaponLocal.weaponName;
        weaponId = weaponLocal.weaponId;
        GameObject temp = Instantiate(Resources.Load("weapon/"+ weapon.weaponName, typeof(GameObject)), weaponPlace.transform, true) as GameObject;
        temp.transform.localPosition = new Vector3(0, 0, 0);
        weaponDescription.text = weapon.weaponName;
        weaponPrice.text = weapon.price.ToString();
    }

    public void SetWeapon(GameObject weaponLocalGO)
    {
        Clean();
        Weapon weaponLocal = weaponLocalGO.GetComponent<Weapon>();
        weapon.Init(weaponLocal);
        weaponColor = weaponLocal.weaponColor;
        weaponName = weaponLocal.weaponName;
        weaponId = weaponLocal.weaponId;
        GameObject temp = Instantiate(Resources.Load("weapon/" + weapon.weaponName, typeof(GameObject)), weaponPlace.transform, true) as GameObject;
        temp.transform.localPosition = new Vector3(0, 0, 0);
        weaponDescription.text = weapon.weaponName;
        weaponPrice.text = weapon.price.ToString();
    }

    public void BuyWeapon()
    {
        if (weapon!=null && MainManager.instanse.account.money>=weapon.price)
        {            
            MainManager.instanse.weapon.Add(weapon);
            MainManager.instanse.account.money -= weapon.price;
            Debug.Log("Buy: "+ weapon.weaponName);            
            Clean();
            weapon = null;
            
        }        
    }

    private void Clean()
    {        
        if (weaponPlace.childCount > 0)
        {
            weapon = new WeaponNoMono();
            weaponDescription.text = "";
            weaponPrice.text = "";
            Destroy(weaponPlace.GetChild(0).gameObject);
        }
    }
}
