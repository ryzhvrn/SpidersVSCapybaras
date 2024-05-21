using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class CatchCapy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private bool _isAttackAllowed = false;

    private List<Capy> _allCapybaras = new List<Capy>();
    private Transform _possibleTarget;
    private float _attackDistance = 1.5f;

    public static event Action CapyCatched;
    public static event Action EnemyAttacking;
    public static event Action<bool> CapybarasDetected;

    private void FixedUpdate()
    {
        if (_possibleTarget == null)
        {
            ChooseNextTarget();

            if (_possibleTarget == null)
            {
                _navMeshAgent.isStopped = true;
                _navMeshAgent.ResetPath();
            }

            return;
        }

        CalculatePath();
    }

    private void OnEnable()
    {
        TriggerZone.TriggerZoneEntered += OnTriggerZoneEntered;
        TriggerZone.TriggerZoneLeft += OnTriggerZoneLeft;
        EnemyAnimator.AttackReloadCompleted += OnAttackReloadCompleted;
        Finish.CapyFinishedForEnemy += OnCapyFinishedForEnemy;
    }

    private void OnDisable()
    {
        TriggerZone.TriggerZoneEntered -= OnTriggerZoneEntered;
        TriggerZone.TriggerZoneLeft -= OnTriggerZoneLeft;
        EnemyAnimator.AttackReloadCompleted -= OnAttackReloadCompleted;
        Finish.CapyFinishedForEnemy -= OnCapyFinishedForEnemy;
    }

    private void ChooseNextTarget()
    {
        if (_allCapybaras != null && _allCapybaras.Count > 0)
        {
            _possibleTarget = _allCapybaras.FirstOrDefault().transform;
            CapybarasDetected?.Invoke(true);
        }
        else
        {
            CapybarasDetected?.Invoke(false);
            _navMeshAgent.isStopped = true;
            _navMeshAgent.ResetPath();
        }

        if (_allCapybaras.Count == 0)
        {
            _possibleTarget = null;
        }
    }

    private void CalculatePath()
    {
        if (_possibleTarget != null)
        {
            _navMeshAgent.SetDestination(_possibleTarget.position);
        }

        if (_possibleTarget == null)
        {
            _navMeshAgent.isStopped = true;
            _navMeshAgent.ResetPath();
        }
    }

    private float DistanceChecker(Transform object1, Transform object2)
    {
        float distance = Vector3.Distance(object1.position, object2.position);

        return distance;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Capy capy))
        {
            if (DistanceChecker(collision.transform, gameObject.transform) < _attackDistance)
            {
                EnemyAttacking?.Invoke();

                if (_isAttackAllowed == true)
                {
                    OnTriggerZoneLeft(capy);
                    Destroy(collision.gameObject);
                    CapyCatched?.Invoke();
                }
            }
        }
    }

    private void OnAttackReloadCompleted(bool isAttackAllowed)
    {
        _isAttackAllowed = isAttackAllowed;
    }

    private void OnTriggerZoneEntered(Capy capy)
    {
        _allCapybaras.Add(capy);
    }

    private void OnTriggerZoneLeft(Capy capy)
    {
        _allCapybaras.Remove(capy);
        _possibleTarget = null;
    }

    private void OnCapyFinishedForEnemy()
    {
        _allCapybaras.Clear();
    }
}