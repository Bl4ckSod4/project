using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackPlayerState : AIState
{
    public float timer = 0f;//таймер задержки между выстрелами
    public float nextTimeToFire = 0;
    private int bulletsPerMag;//патроны в магазине
    
    AIAgent agent;//ссылка на солдата, у которого проигрываем этот стэйт в стэйт машин
    
    public void Enter(AIAgent agent)
    {
        nextTimeToFire = agent.weapon.fireRate;//переменная отвечает за скорострельность и равна показателю скорострельности у текущего оружия солдата
        bulletsPerMag = agent.weapon.bulletsPerMag;//количество патронов в магазине равно количеству патронов в магазине у текущего оружия солдата
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AIStateID GetID()
    {
        return AIStateID.Attack;
    }

    public void Update(AIAgent agent)
    {
        Vector3 targetDirection = agent.currentTarget.position - agent.transform.position;//получаем направление к цели
        if(targetDirection.magnitude > agent.config.maxSightDistance)//если солдат покинул максимальное поле зрения для врагов
        {
            agent.stateMachine.ChangeState(AIStateID.ChasePlayer);//стэйт машин меняет стэйт на преследование(и уже там преследует последнюю видимую позицию врага)
        }
        PlayerStats1 enemyStats = agent.currentTarget.GetComponent<PlayerStats1>();//получаем скрипт с параметрами солдата у текущей цели
        timer += Time.deltaTime;//запускаем таймер
        
       if(timer > nextTimeToFire && agent.inSight) //если таймер больше показателя скорострельности и враг в поле зрения
       {
        
            if(bulletsPerMag > 0)//если патронов в магазине больше 0
            {
                agent.animator.SetBool("Reload", false);
                agent.animator.SetBool("Fire", true);
                agent.transform.LookAt(agent.currentTarget);
                agent.weapon.Fire();
                timer = 0f;
                bulletsPerMag--;

                
           
                if(enemyStats.isDead)//если текущая цель уничтожена
                {
                    agent.animator.SetBool("Fire", false);
                    agent.inSight = false;
                    agent.UpdateTargets();
                    agent.stateMachine.ChangeState(AIStateID.Idle);
                    

                }
                
            }
            else
            {
                agent.animator.SetBool("Fire", false);
                Debug.Log("RELOAD");//строка для отладки работоспособности механики
                agent.animator.SetBool("Reload", true); 
                bulletsPerMag = agent.weapon.bulletsPerMag;//пополняем магазин

            }
           
       }
       if(!agent.inSight)
       {
            agent.animator.SetBool("Fire", false);
            agent.stateMachine.ChangeState(AIStateID.Idle);
       }
    }
}