using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //класс с параметрами солдата
    [Header("Characteristics")]
    public int id=0;
    public string nameFirst;
    public string weapon = "MP5_black";
    public bool whiteskin;
    [SerializeField] GameObject skin;
    public float speed=5.0f;//скорость ходьбы
    //public float maxHealth = 100.0f;//максимальное здоровье
    //public float minHealth = 0.0f;//минимальное здоровье
    public float currentHealth = 100.0f;//текущее здоровье
    //public float aimness;//разброс
    //public float damage = 10.0f;//урон
    public bool freedomless;//послушание
    public bool isDead = false;//флаг, показывающий что текущая цель уничтожена и возврат в Idle

    public void TakeDamage(float Damage)//наносит урон здоровью при попадании в текущего бойца
    {
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            isDead = true;
            Die();
        }
    }
    public void Die()
    {
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            i.GetComponent<Spawner>().EnemyDie(id, gameObject.tag);
        }
        gameObject.tag = "Finish";//меняем тэг чтобы убрать из массива целей
                                  //enabled = false;
        Destroy(gameObject);
    }

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
    public virtual void UpdateSoldier()
    {
        ChangeSkin();
        //ChangeWeapon();
    }
    private void ChangeSkin()
    {        
        if (!whiteskin)
        {
            Material skinMaterial=Instantiate(Resources.Load("skin/"+"blackface1", typeof(Material)), gameObject.transform, true) as Material;
            skin.GetComponent<Renderer>().material = skinMaterial;
        }
    }
    //private void ChangeWeapon()
    //{
    //    GameObject[] weapons = Resources.FindObjectsOfTypeAll<GameObject>();
    //    foreach (GameObject weaponRes in weapons)
    //    {
    //        if (weaponRes.name.Contains(weapon))
    //        {
    //            skin.GetComponent<Renderer>().material = weaponRes;
    //            break;
    //        }
    //    }
    //}
}
