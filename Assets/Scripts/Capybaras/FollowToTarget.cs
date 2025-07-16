using System;
using UnityEngine;
using UnityEngine.AI;

public class FollowToTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _target = FindObjectOfType<Player>().gameObject.transform;
        CalculatePath();
    }

    private void Update()
    {
        CalculatePath();
    }

    private void CalculatePath()
    {
        if (_target != null && _navMeshAgent != null)
        {
            _navMeshAgent.SetDestination(_target.position);
        }
    }
}
