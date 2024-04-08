using System;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
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
        if (transform.position.x!=_previousPosition.x)
        {
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
        }

        if (_isMoving)
        {
            EnemyMoving?.Invoke(_isMoving);
        }
        else
        {
            EnemyMoving?.Invoke(_isMoving);
        }

        _previousPosition= transform.position;
    }
}
