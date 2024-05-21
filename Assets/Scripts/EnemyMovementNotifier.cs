using System;
using UnityEngine;

public class EnemyMovementNotifier : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _previousPosition;

    public static event Action<bool> EnemyMoving;

    private void Start()
    {
        _previousPosition = transform.position;
    }

    private void Update()
    {
        bool isCurrentlyMoving = transform.position.x != _previousPosition.x;
        _isMoving = isCurrentlyMoving;

        EnemyMoving?.Invoke(_isMoving);

        _previousPosition = transform.position;
    }
}
