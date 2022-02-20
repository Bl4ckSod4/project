using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHoldingState : AIState
{
    //AIAgent agent;//ссылка на солдата, у которого проигрываем этот стэйт в стэйт машин
    private float timer = 0f;//таймер задержки между выстрелами
    public float nextTimeToFire = 0;//переменная отвечает за скорострельность и равна показателю скорострельности у текущего оружия солдата
    private int bulletsPerMag;//количество патронов в магазине равно количеству патронов в магазине у текущего оружия солдата
    private float coverZone = 20;

    public void Enter(AIAgent agent)
    {
        nextTimeToFire = agent.weapon.fireRate;
        bulletsPerMag = agent.weapon.bulletsPerMag;
        FindFreePosition(agent);//ищет свободную позицию
    }

    private void FindFreePosition(AIAgent agent)//перебор доступных укрытий, выбор пустого поблизости
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Position");        
        Position wallBest=null;
        Vector3 oldPos = new Vector3(0, 0, 0);

        foreach (GameObject i in walls)
        {
            Position wall = i.GetComponent<Position>();
            if (wall.isEmpty && coverZone> (agent.transform.position - i.transform.position).magnitude &&((agent.transform.position - oldPos).magnitude > (agent.transform.position - i.transform.position).magnitude))
            {
                wallBest = wall;
            }
        }

        if (wallBest != null)
        {
            oldPos= wallBest.ReturnPos(agent);
        }
        if (oldPos != new Vector3(0, 0, 0))
        {
            agent.navMeshAgent.destination = oldPos;
        }
        else
        {
            agent.stateMachine.ChangeState(AIStateID.Patrol);
        }
    }

    public void Update(AIAgent agent)
    {
        Shoot(agent);
    }

    public void Exit(AIAgent agent)
    {
       
    }

    public AIStateID GetID()
    {
        return AIStateID.Hold;
    }

    bool Distance(AIAgent agent)//возвращает истину если враг в зоне поражения
    {
        bool data = (agent.currentTarget.position - agent.transform.position).magnitude <= agent.weapon.shootRange;
        //Debug.Log((agent.currentTarget.position - agent.transform.position).magnitude + " "+ agent.weapon.shootRange);
        return data;
    }

    void Shoot(AIAgent agent)
    {

        Vector3 targetDirection = agent.currentTarget.position - agent.transform.position;//получаем направление к цели
        PlayerStats enemyStats = agent.currentTarget.GetComponent<PlayerStats>();//получаем скрипт с параметрами солдата у текущей цели
        timer += Time.deltaTime;//запускаем таймер

        if (!Physics.Raycast(agent.transform.position, targetDirection, agent.config.maxSightDistance, agent.obstacleMask) && Distance(agent))//проверка на наличие obstacle(препятствий) между солдатом и целью
        {
            agent.inSight = true;//если между ними нет стены и других препятствий, то солдат видит противника
        }
        else
        {
            agent.inSight = false;
        }        

        if (timer > nextTimeToFire && agent.inSight) //если таймер больше показателя скорострельности и враг в поле зрения
        {
            if (bulletsPerMag > 0)//если патронов в магазине больше 0
            {
                agent.animator.SetBool("Reload", false);
                agent.animator.SetBool("Fire", true);
                agent.transform.LookAt(agent.currentTarget);
                agent.weapon.Fire();
                timer = 0f;
                bulletsPerMag--;

                if (enemyStats != null && enemyStats.isDead)//если текущая цель уничтожена
                {
                    agent.animator.SetBool("Fire", false);
                    agent.inSight = false;
                    agent.UpdateTargets();
                }
            }
            else
            {
                agent.animator.SetBool("Fire", false);
                agent.animator.SetBool("Reload", true);
                bulletsPerMag = agent.weapon.bulletsPerMag;//пополняем магазин
            }
        }
        if (!agent.inSight)
        {
            agent.animator.SetBool("Fire", false);
        }
    }
}
