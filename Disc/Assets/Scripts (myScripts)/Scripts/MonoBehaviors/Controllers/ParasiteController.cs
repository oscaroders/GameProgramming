using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.AI;

public class ParasiteController : MonoBehaviour {

    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = Random.Range( 2 , 5 ) * 5;
    }

    // Update is called once per frame
    public void thisUpdate( Vector3 targetPosition ) {
        navMeshAgent.SetDestination( targetPosition );
    }
}