using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class CatchCapy : MonoBehaviour
{
    public List<Capy> allcapyes = new List<Capy>();

    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private bool _isAttackAllowed = false;
    private Transform _possibleTarget;

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

        Debug.Log("Обнаружили цель");
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
        if (allcapyes != null && allcapyes.Count > 0)
        {
            _possibleTarget = allcapyes.FirstOrDefault().transform;
            CapybarasDetected?.Invoke(true);
            Debug.Log("Текущая цель: " + _possibleTarget.name);
        }
        else
        {
            CapybarasDetected?.Invoke(false);
            _navMeshAgent.isStopped = true;
            _navMeshAgent.ResetPath();
        }

        if (allcapyes.Count == 0)
        {
            _possibleTarget = null;
        }
    }

    private void CalculatePath()
    {
        if (_possibleTarget != null)
        {
            _navMeshAgent.SetDestination(_possibleTarget.position);
            Debug.Log("Имя обнаруженной цели: " + _possibleTarget.name);
        }
        if (_possibleTarget == null)
        {
            _navMeshAgent.isStopped = true;
            _navMeshAgent.ResetPath();
            Debug.Log("_navMeshAgent.ResetPath()");
        }
    }

    private float DistanceChecker(Transform object1, Transform object2)
    {
        float distance = Vector3.Distance(object1.position, object2.position);
        Debug.Log("Расстояние = " + distance);

        return distance;
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("AttackAbilityStatus: " + _isAttackAllowed);

        if (collision.gameObject.TryGetComponent(out Capy capy))
        {
            if (DistanceChecker(collision.transform, gameObject.transform) < 1.5f)
            {
                EnemyAttacking?.Invoke();

                if (_isAttackAllowed == true)
                {
                    Debug.Log("Capy поймана!");
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
        allcapyes.Add(capy);
        Debug.Log("В сферу обнаружения всего попало: " + allcapyes.Count + " капибар!");

        Debug.Log("Список объектов в allcapyes после добавления объекта:");

        foreach (var capyElement in allcapyes)
        {

            Debug.Log(capyElement.name);
        }
    }

    private void OnTriggerZoneLeft(Capy capy)
    {
        allcapyes.Remove(capy);
        Debug.Log("Капибара покинула сферу, теперь их: " + allcapyes.Count + " штук!");
        _possibleTarget = null;
        Debug.Log("Список объектов в allcapyes после удаления объекта:");

        foreach (var capyElement in allcapyes)
        {

            Debug.Log(capyElement.name);
        }
    }

    private void OnCapyFinishedForEnemy()
    {
        allcapyes.Clear();
    }
}

