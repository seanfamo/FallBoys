using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponents : MonoBehaviour
{
    NavMeshAgent _opponent;
    public Transform _endTarget;
    void Start()
    {
        _opponent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _opponent.SetDestination(_endTarget.transform.position);
    }
}
