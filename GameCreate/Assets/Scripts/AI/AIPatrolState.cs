using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolState : AIState
{
    AIAgent agent;//ссылка на солдата, у которого проигрываем этот стэйт в стэйт машин
    public void Enter(AIAgent agent)
    {
        agent.navMeshAgent.destination = agent.waypoints[Random.Range(0,4)].transform.position;//идти к точке waypoint
        
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AIStateID GetID()
    {
        return AIStateID.Patrol;
    }

    public void Update(AIAgent agent)
    {
        if(!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = agent.waypoints[0].transform.position;//обновляем путь если не в пути
        }
        if(agent.navMeshAgent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete)
        {
            agent.navMeshAgent.destination = agent.waypoints[Random.Range(0,4)].transform.position;//если путь завершен, то двигаться к следующей точке в массиве waypoints
        }
        Patrol(agent);
    }

    public void Patrol(AIAgent agent)
    {
        Vector3 targetDirection = agent.currentTarget.position - agent.transform.position;
        //int index = Random.Range(0, 3);
        //Vector3 ofset = new Vector3(Random.Range(-2,2), 0, Random.Range(-2,2));
        //nextWayPoint = agent.waypoints[index].transform.position;
        //return nextWayPoint;
        //agent.navMeshAgent.destination = agent.waypoints[0].transform.position;
        //Vector3 targetDirection = agent.currentTarget.position - agent.transform.position;//agent.waypoints[index].transform.position;//nextWayPoint - ofset;
        if(!Physics.Raycast(agent.transform.position, targetDirection, agent.config.maxSightDistance, agent.obstacleMask))//если видим врага через рэйкаст
        {
            agent.stateMachine.ChangeState(AIStateID.Idle);//то стэйт машин переводим в Idle
        }
    }
}
