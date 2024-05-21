using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolManager : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolPoints = new Transform[] { };
    [SerializeField] private NavMeshAgent _enemyNavMeshAgent;

    private float _moveSpeed;
    private int _currentPatrolIndex = 0;
    private bool _isCapybarasDetected = false;
    private float _transitionDistance = 1f;

    private void Start()
    {
        _moveSpeed = _enemyNavMeshAgent.speed;
    }

    private void Update()
    {
        if (_isCapybarasDetected == false)
        {
            if (_patrolPoints.Length > 0)
            {
                Transform currentPatrolPoint = _patrolPoints[_currentPatrolIndex];
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    currentPatrolPoint.position,
                    _moveSpeed * Time.deltaTime);

                Vector3 direction = currentPatrolPoint.position - transform.position;
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(direction.normalized),
                    0.1f);

                if (Vector3.Distance(transform.position, currentPatrolPoint.position) < _transitionDistance)
                {
                    _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    private void OnEnable()
    {
        CatchCapy.CapybarasDetected += OnCapybarasDetected;
    }

    private void OnDisable()
    {
        CatchCapy.CapybarasDetected -= OnCapybarasDetected;
    }

    private void OnCapybarasDetected(bool isCapybarasDetected)
    {
        _isCapybarasDetected = isCapybarasDetected;
    }
}
