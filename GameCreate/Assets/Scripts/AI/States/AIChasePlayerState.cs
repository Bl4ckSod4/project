using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIChasePlayerState : AIState
{
    //стэйт преследует цель, подходя на расстояние атаки
    AIAgent agent;//ссылка на солдата, у которого проигрываем этот стэйт в стэйт машин
    public float timer;//таймер задержки перед преследованием
    public void Enter(AIAgent agent)
    {
        agent.lastSeenPosition = agent.currentTarget.transform;//последняя видимая цель равняется текущей позиции текущей цели
        timer = agent.config.maxTime;//таймер равен значению, указанному в AIAgentConfig
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AIStateID GetID()
    {
        return AIStateID.ChasePlayer;
    }

    public void Update(AIAgent agent)
    {
        if(!agent.enabled)
        {
            return;
        }

        timer -= Time.deltaTime;//отсчет таймера задержки
        if(!agent.navMeshAgent.hasPath)//если солдат сейчас не в пути
        {
            agent.navMeshAgent.destination = agent.lastSeenPosition.transform.position;//солдат движется к последней видимой позиции врага
        }
        else
        {
            agent.transform.LookAt(agent.currentTarget, agent.transform.up);//враг смотрит в сторону цели
        }        
        if(timer < 0.0f)
        {
            Vector3 direction = (agent.currentTarget.transform.position - agent.navMeshAgent.destination);//направление к цели
            direction.y = 0;//сбрасываем направление вверх для более точных расчетов 
            if(direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance)//если квадрат длины направления больше квадрата максимальной длины, при которой солдат преследует цель
            {
                agent.lastSeenPosition = agent.currentTarget.transform;//изменяем ранее видимую позицию на последнюю увиденную
                agent.navMeshAgent.destination = agent.lastSeenPosition.transform.position;//идем к ней
            }
            
            if(agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)//если достичь цели возможно
            {
                agent.navMeshAgent.destination = agent.currentTarget.transform.position;//преследует цель
            }

            timer = agent.config.maxTime;//сбрасываем таймер
        }
        if(agent.navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)//если путь достигнут
        {
            agent.stateMachine.ChangeState(AIStateID.Idle);//стэйт машин переходит в Idle
        }
    }
}
 