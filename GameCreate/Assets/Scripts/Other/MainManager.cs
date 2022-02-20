using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager instanse;
    //Текущий экран хаба
    public string testName = "";
    public int screen = 0;
    public Account account=new Account();
    public Mission chosenMission;

    public List<Mission> missions;

    public List<PlayerStatsNoMono> team; 
    public List<PlayerStatsNoMono> barraks;
    public List<WeaponNoMono> weapon;
    public List<PlayerStatsNoMono> teamEnemy; 

    void Start()
    {
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
            return;
        }
        DontDestroyOnLoad(this.gameObject);
 
        if(!LoadData())
        {
            SetTestData();
        }
        
        instanse = this;    //Дает доступ из любого места кода, по MainManager.instanse.

    }

    //метод загружает сцену Хаб, принимает целое число в качестве номера подменю хаба 0 - выбор миссии 1- отряд и т.д.
    public void ReturnHub(int screenTemp=5)
    {
        screen = screenTemp;
        SceneManager.LoadScene("Hub Screen");        
    }



    public void SetTestData()
    {
        missions = new List<Mission>();
        team = new List<PlayerStatsNoMono>();
        barraks = new List<PlayerStatsNoMono>();
        weapon = new List<WeaponNoMono>();
        teamEnemy = new List<PlayerStatsNoMono>();

        missions.Add(new Mission() { missionName = "Соревнование между ЧВК", sceneName = "Deathmatch", rewardMoney = 1000, region = "Europe",difficulty=1,duration=120,note="Дружественный отряд предлагает устроить тренировочный бой. Стрельбище. Нелетальные боеприпасы." });
        missions.Add(new Mission() { missionName = "Уничтожить ящики с оборудованием", sceneName = "ExplodeTargets", rewardMoney = 2000, region = "Africa", difficulty = 1, duration = 240, note ="Террористы перевозят устаревшие ПЗРК, которые представляют опасность, но не представляют ценности. Необходимо уничтожить ящики с оружием." });
        missions.Add(new Mission() { missionName = "Уничтожить склад ГСМ", sceneName = "ExplodeTargets", rewardMoney = 3000, region = "South America", difficulty = 2, duration = 120, note = "В тылу врага склад ГСМ. Нужно уничтожить топливо и запчасти." });

        team.Add(new PlayerStatsNoMono() { id = 1, nameFirst = "Ivan", whiteskin = false, weapon = "MP5_white" });
        team.Add(new PlayerStatsNoMono() { id = 2, nameFirst = "John", whiteskin = true, weapon = "MP5_black" });
        team.Add(new PlayerStatsNoMono() { id = 3, nameFirst = "Hans", whiteskin = false, weapon = "MP5_white" });

        barraks.Add(new PlayerStatsNoMono() { id = 4, nameFirst = "Ivan1", whiteskin = false, weapon = "MP5_white" });
        barraks.Add(new PlayerStatsNoMono() { id = 5, nameFirst = "John1", whiteskin = false, weapon = "MP5_white" }) ;
        barraks.Add(new PlayerStatsNoMono() { id = 6, nameFirst = "Hans1", whiteskin = true, weapon = "MP5_white" });
        barraks.Add(new PlayerStatsNoMono() { id = 7, nameFirst = "Ivan2", whiteskin = false, weapon = "MP5_white" });
        barraks.Add(new PlayerStatsNoMono() { id = 8, nameFirst = "John2", whiteskin = true, weapon = "MP5_white" });
        barraks.Add(new PlayerStatsNoMono() { id = 9, nameFirst = "Hans2", whiteskin = false, weapon = "MP5_white" });

        weapon.Add(new WeaponNoMono() {weaponName= "MP5_white",   weaponColor="white",equipped=true  });
        weapon.Add(new WeaponNoMono() { weaponName = "MP5_gray", weaponColor = "gray", equipped = true });
        weapon.Add(new WeaponNoMono() { weaponName = "MP5_black", weaponColor = "black", equipped = true });
        weapon.Add(new WeaponNoMono() { weaponName = "MP5_white", weaponColor = "white" });
        weapon.Add(new WeaponNoMono() { weaponName = "MP5_black", weaponColor = "black" });
        weapon.Add(new WeaponNoMono() { weaponName = "MP5_black", weaponColor = "gray" });

        teamEnemy.Add(new PlayerStatsNoMono() { id = 1, nameFirst = "Chung Chang", whiteskin = false, weapon = "MP5_white" });
        teamEnemy.Add(new PlayerStatsNoMono() { id = 2, nameFirst = "Chi Mihn", whiteskin = true, weapon = "MP5_white" });
        teamEnemy.Add(new PlayerStatsNoMono() { id = 3, nameFirst = "Lao Pan Van", whiteskin = false, weapon = "MP5_white" });
    }

    public void SaveData()
    {
        account.barraks=barraks;
        account.team=team;
        account.missions=missions;
        account.teamEnemy=teamEnemy;
        account.weapon=weapon;
        string json = JsonUtility.ToJson(account);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    bool LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Account accountLoad = JsonUtility.FromJson<Account>(json);

            account = accountLoad;
            barraks = account.barraks;
            team = account.team;
            missions = account.missions;
            teamEnemy = account.teamEnemy;
            weapon = account.weapon;

            return true;
        }
        return false;
    }


    public class Account
    {
        public int id = 0;
        public int exp = 0;
        public int money = 10000;
        public List<PlayerStatsNoMono> team;
        public List<PlayerStatsNoMono> barraks;
        public List<WeaponNoMono> weapon;
        public List<PlayerStatsNoMono> teamEnemy;
        public List<Mission> missions;
    }
    [System.Serializable] private class Data
    {
        public List<Account> data;
    }

}
