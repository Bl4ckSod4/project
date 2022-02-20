using UnityEngine;

[System.Serializable]
public class PlayerStatsNoMono
{
    //класс с параметрами солдата
    [Header("Characteristics")]
    public int id=0;
    public string nameFirst;
    public string weapon = "MP5_black";
    public bool whiteskin=true;
    [SerializeField] GameObject skin;
    public float speed=5.0f;//скорость ходьбы
    //public float maxHealth = 100.0f;//максимальное здоровье
    //public float minHealth = 0.0f;//минимальное здоровье
    public float currentHealth = 100.0f;//текущее здоровье
    //public float aimness;//разброс
    //public float damage = 10.0f;//урон
    public bool freedomless;//послушание
    public bool isDead = false;//флаг, показывающий что текущая цель уничтожена и возврат в Idle

    public void Init(PlayerStatsNoMono data)
    {
         id= data.id;
         nameFirst=data.nameFirst;
         weapon = data.weapon;
         whiteskin= data.whiteskin;
         speed = data.speed;
         currentHealth = data.currentHealth;
         freedomless= data.freedomless;
         isDead = data.isDead;
}

    public void Init(PlayerStats data)
    {
        id = data.id;
        nameFirst = data.nameFirst;
        weapon = data.weapon;
        whiteskin = data.whiteskin;
        speed = data.speed;
        currentHealth = data.currentHealth;
        freedomless = data.freedomless;
        isDead = data.isDead;
    }
    public void UpdateSoldier()
    {
        ChangeSkin();
    }
    private void ChangeSkin()
    {        
        if (!whiteskin)
        {
            Material[] materials = Resources.FindObjectsOfTypeAll<Material>();
            foreach (Material skinMaterial in materials)
            {
                if (skinMaterial.name.Contains("blackface"))
                {
                    skin.GetComponent<Renderer>().material = skinMaterial;
                    break;
                }
            }
        }
    }
}
