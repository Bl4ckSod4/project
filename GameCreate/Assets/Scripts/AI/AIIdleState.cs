using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
    //Этот стэйт служит для охраны текущего места, где стоит солдат
    public void Enter(AIAgent agent)
    {
        
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AIStateID GetID()
    {
        return AIStateID.Idle;
    }

    public void Update(AIAgent agent)
    {
        Vector3 targetDirection = agent.currentTarget.position - agent.transform.position;//получаем направление к цели
        if(targetDirection.magnitude > agent.config.maxSightDistance)//если длина к цели больше дальности видимости для врагов, то ничего не возвращает
        {
            return;
        }
        
        if(!Physics.Raycast(agent.transform.position, targetDirection, agent.config.maxSightDistance, agent.obstacleMask))//проверка на наличие obstacle(препятствий) между солдатом и целью
        {
            agent.inSight = true;//если между ними нет стены и других препятствий, то солдат видит противника
        }
        if(agent.inSight)//если солдат видит противника
        {
            Vector3 agentDirection = agent.transform.forward;//вектор направления взгляда солдата, он направлен вперед
            targetDirection.Normalize();//приравниваем длину к 1, т.к. нужно лишь направление
            float dotProduct = Vector3.Dot(targetDirection, agentDirection);//скалярное произведение вектора взгляда вперед и направления к цели
            if(dotProduct > 0.0f)//если равен 0, то значит эти вектора перпендикулярны, следовательно враг покинул поле зрения
            {
                agent.stateMachine.ChangeState(AIStateID.ChasePlayer);//преследуем игрока
            }
            
            agent.stateMachine.ChangeState(AIStateID.Attack);//атакуем
                
        }
    }
}
