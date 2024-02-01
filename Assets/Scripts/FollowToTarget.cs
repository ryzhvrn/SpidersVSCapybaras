using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowToTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    public static event Action CapyFollowed;

    private void Start()
    {
        _target = FindObjectOfType<Player>().gameObject.transform;
        CapyFollowed?.Invoke();
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
