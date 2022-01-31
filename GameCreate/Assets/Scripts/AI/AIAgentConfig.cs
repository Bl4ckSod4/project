using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class AIAgentConfig : ScriptableObject
{
    //в этом классе вынесены некоторые параметры для удобной регулировки АИ 
    public float maxTime = 1.0f;//время задержки между Idle и Chase(преследованием)
    public float maxDistance = 1.0f;//при удалении цели от солдата на это значение, игрок спустя maxTime времени будет преследовать цель
    public float maxSightDistance = 5.0f;//предел области видимости врагов
    
}
