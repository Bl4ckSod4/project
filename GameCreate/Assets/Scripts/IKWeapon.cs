using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IKWeapon : MonoBehaviour
{
    //public WeaponStats weaponStats;
    [Header("Weapon_Params")]
    public float damage = 10f;//урон для текущего оружия
    public int shootRange = 50;//расстояние, с которого максимум можно стрелять с текущего оружия
    public float aimness = 0.01f;//разброс пуль
    public float fireRate = 1.0f;//скорострельность
    //private float timer = 0f;//вспосогательный таймер для скорострельности
    //private float nextTimeToFire = 1f;//таймер для выстрела
    public int bulletsPerMag = 7;//патроны в обойме
    [Space(10)]
    public GameObject muzzleFlash;//ссылка на префаб для дульной вспышки
    public Transform muzzle;//точка спавна для дульной вспышки
    public AIAgent agent;//ссылка на солдата
    public Transform targetTransform;//положение текущей цели
    public Transform aimTransform;//положение конца оружия(вектор направлен вперед)
    public Vector3 targetOffset;//смещение прицела солдата на врага в районе туловища(без этого смещения он целится в пивот поин текущей цели, а она внизу у ног)
    public Transform bone;//кость спины, поворачивается к цели исходя из расчетов разницы угла между aimTransform и targetTransform
    public GameObject impactEffect;//префаб эффекта искр, куда попадает пуля
    public int iterations = 10;//количество итераций метода AimAtTarget должно быть несколько для более точных расчетов прицеливания
    [Range(0,1)]
    public float weight = 1.0f;
    public float angleLimit = 90.0f;
    public float distanceLimit = 1.5f;

    void Start()
    { 
        //offsetShoot = new Vector3(0, Random.Range(-aimness,aimness), Random.Range(-aimness,aimness));
        //Instantiate(muzzleFlash, aimTransform.transform.position, Quaternion.identity);
        if(targetTransform == null)
        {
            targetTransform = agent.currentTarget;//agent.currentTarget.Find("Target");
        }
    }
    Vector3 GetTargetPosition()
    {
        Vector3 targetDirection = (targetTransform.position + targetOffset) - aimTransform.position; 
        Vector3 aimDirection = aimTransform.forward;
        float blendOut = 0.0f;
        float targetAngle = Vector3.Angle(targetDirection, aimDirection);
        if(targetAngle > angleLimit)
        {
            blendOut += (targetAngle - angleLimit) / 50.0f;
        }
        Vector3 Direction = Vector3.Slerp(targetDirection, aimDirection, blendOut);
        return aimTransform.position + Direction;

    }

    // Update is called once per frame
    void LateUpdate()
    {
       /* if(aimTransform == null)
        {
            return;
        }

        if(targetTransform == null)
        {
            return;
        }*/
        
        targetTransform = agent.currentTarget;
        Vector3 targetPosition = GetTargetPosition();
        for (int i = 0; i < iterations; i++)
        {
            AimAtTarget(bone, targetPosition, weight);
        }
        //Vector3 aimPosition = aimTransform.position;
    }

    private void AimAtTarget(Transform bone, Vector3 targetPosition, float weight)
    {
        Vector3 aimDirection = aimTransform.forward;
        Vector3 targetDirection = targetPosition - aimTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        bone.rotation = aimTowards * bone.rotation;
        //bone.rotation = Quaternion.Euler(bone.transform.rotation.x, bone.transform.rotation.y, 0);

    }
    
    public void Fire()
    {
        //muzzle.SetActive(true);
        float timer = 0.1f;
        timer -= Time.deltaTime;
        //agent.animator.SetBool("Fire", true);
        Vector3 offsetShoot = new Vector3(0, Random.Range(-aimness,aimness), Random.Range(-aimness,aimness));
        //Debug.Log("PredFired");
        GameObject MF = Instantiate(muzzleFlash, muzzle.position, Quaternion.identity);//Quaternion.identity);
        Destroy(MF,0.5f);
        //if(timer <= 0)
        //{
           // muzzle.SetActive(false);
        //}
        //muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(aimTransform.transform.position, aimTransform.transform.forward + offsetShoot, out hit, shootRange))
        {
            Debug.Log(hit.transform.name);
            PlayerStats1 enemyStats = hit.transform.GetComponent<PlayerStats1>();
            if(enemyStats != null)
            {
                enemyStats.TakeDamage(damage);
            }
            else
            {
                //enemyStats.isDead = false;

            }
            
            GameObject GO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(GO, 2.0f);
            //Debug.Log("RAYCAST");

        }
        //Debug.Log("FIREEED");


    }

     /* 
        {
            RaycastHit hit;
            if(Physics.Raycast(aimTransform.transform.position, aimTransform.forward, out hit, 100f))
            {
                GameObject go = Instantiate(bulletPrefab, hit.normal, Quaternion.identity);  
            };
        }*/
    /*public void SetTargetTransform(Transform target)
    {
        targetTransform = target;
    }

    public void SetAimTransform(Transform target)
    {
        aimTransform = target;
    }*/
}
