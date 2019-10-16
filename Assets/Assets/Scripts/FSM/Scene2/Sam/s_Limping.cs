using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;
using UnityEngine.AI;

public class s_Limping : StateBehaviour
{
    NavMeshAgent navMeshAgent;
    // Called when the state is enabled
    void OnEnable () {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = 3.5f;
    }
    private void Update()
    {
        SendEvent("Slow");

    }
}


