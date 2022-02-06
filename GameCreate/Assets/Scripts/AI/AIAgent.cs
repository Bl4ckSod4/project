using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public Animator animator;
    public PlayerStats1 playerStats;//параметры солдата
    public IKWeapon weapon;//Инверсная кинематика и параметры оружия
    public NavMeshAgent navMeshAgent;
    public AIStateMachine stateMachine;//Стэйт машин для АИ
    public AIStateID initialState;//первоначальный стэйт при запуске игры
    public AIAgentConfig config;
    public Transform currentTarget;//текущая цель
    public Transform lastSeenPosition;//последняя позиция текущей цели, которую видел солдат
    public bool inSight = false;//враг в поле зрения
    public GameObject[] targets;//массив целей
    public List<GameObject> waypoints;//точки на карте, куда будут идти солдаты в стэйте Patrol
    public LayerMask obstacleMask;//в инспекторе для всех статичных объектов нужно пометить layer как obstacle, чтобы не видел противника сквозь стены
    [HideInInspector]
    public int index;//индекс в массиве целей для указания в нем текущей цели
    public string tag = "Enemy";//тэг врага для текущего солдата(по умолчанию enemy, выбирать в инспекторе)
    void Start()
    {
        navMeshAgent.speed = playerStats.speed;
        //navMeshAgent.stoppingDistance = config.maxSightDistance;
        animator = GetComponent<Animator>();
        UpdateTargets();
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new AIStateMachine(this);  
        stateMachine.RegisterState(new AIChasePlayerState());
        stateMachine.RegisterState(new AIIdleState());
        stateMachine.RegisterState(new AIAttackPlayerState());
        stateMachine.RegisterState(new AIPatrolState());
        stateMachine.ChangeState(initialState);  
    }
    void Update()
    {
        UpdateTargets();
        GetNearestEnemyIndex(targets);
        currentTarget = targets[index].transform;
        stateMachine.Update();
    }

    public int GetNearestEnemyIndex(GameObject[] targets)//перебираем массив целей и возвращаем индекс ближайшего врага
    {
        this.targets = targets;
        float nearTarget = targets[0].transform.position.magnitude;//переменная для наименьшего расстояния, по умолчанию первый объект в массиве целей
        for (int i = 0; i < targets.Length; i++)
        {
            float targetDistance = (targets[i].transform.position - navMeshAgent.transform.position).magnitude;//переменная проверяет дистанцию к каждой цели в массиве
            if(targetDistance < nearTarget)//если дистанция меньше чем предыдущая, то возвращает ее
            {
                nearTarget = targetDistance;
                index = i;
            }
        }
        return index;
    }
    public void debugStates(AIStateMachine stateMachine)//вывод в консоль текущего стэйта АИ, который сейчас в стэйт машин
    {
        Debug.Log(stateMachine.currentState); 
    }

    public void UpdateTargets()//обновляем массив целей(нужно для того, чтобы если некоторые солдаты погибнут, и список целей не был местами Null, а обновился)
    {
        targets = new GameObject[0];//создаем новый массив
        targets = GameObject.FindGameObjectsWithTag(tag);//помещаем туда цели с тэгом врага
        if(targets == null)
        {
            return;
        }
    }
}
