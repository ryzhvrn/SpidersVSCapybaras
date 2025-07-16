using System.Collections.Generic;
using System.Linq;
using Scripts.Capybaras;
using Scripts.Services;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameEventBus _eventBus;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        [Header("Settings")]
        [SerializeField] private float _attackDistance = 1.5f;

        private List<Capy> _allCapybaras = new List<Capy>();
        private Transform _currentTarget;
        private bool _isAttackAllowed = false;

        private void OnEnable()
        {
            _eventBus.OnTriggerZoneEntered += OnCapyEnteredZone;
            _eventBus.OnTriggerZoneLeft += OnCapyLeftZone;
            _eventBus.OnAttackReloadCompleted += OnAttackReloadCompleted;
            _eventBus.OnCapyFinishedForEnemy += OnCapyFinishedForEnemy;
        }

        private void OnDisable()
        {
            _eventBus.OnTriggerZoneEntered -= OnCapyEnteredZone;
            _eventBus.OnTriggerZoneLeft -= OnCapyLeftZone;
            _eventBus.OnAttackReloadCompleted -= OnAttackReloadCompleted;
            _eventBus.OnCapyFinishedForEnemy -= OnCapyFinishedForEnemy;
        }

        private void FixedUpdate()
        {
            if (_currentTarget == null)
            {
                ChooseNextTarget();
                return;
            }

            _navMeshAgent.SetDestination(_currentTarget.position);
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Capy capy))
            {
                float distance = Vector3.Distance(transform.position, capy.transform.position);

                if (distance < _attackDistance)
                {
                    _eventBus.EnemyAttacking();

                    if (_isAttackAllowed)
                    {
                        OnCapyLeftZone(capy);
                        Destroy(capy.gameObject);
                        _eventBus.CapyCatched();
                    }
                }
            }
        }

        private void ChooseNextTarget()
        {
            if (_allCapybaras.Count > 0)
            {
                _currentTarget = _allCapybaras.FirstOrDefault()?.transform;
                _eventBus.CapybarasDetected(true);
            }
            else
            {
                _currentTarget = null;
                _eventBus.CapybarasDetected(false);
                _navMeshAgent.ResetPath();
            }
        }

        private void OnAttackReloadCompleted(bool canAttack)
        {
            _isAttackAllowed = canAttack;
        }

        private void OnCapyEnteredZone(Capy capy)
        {
            if (!_allCapybaras.Contains(capy))
                _allCapybaras.Add(capy);
        }

        private void OnCapyLeftZone(Capy capy)
        {
            _allCapybaras.Remove(capy);
            _currentTarget = null;
        }

        private void OnCapyFinishedForEnemy()
        {
            _allCapybaras.Clear();
        }
    }
}
