using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public static event Action<bool> EnemyMoving;

    private bool _isMoving = false;
    private Vector3 _previousPosition;

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
            Debug.Log("Враг движется!");
            EnemyMoving?.Invoke(_isMoving);
        }
        else
        {
            Debug.Log("Враг не движется!");
            EnemyMoving?.Invoke(_isMoving);
        }
        _previousPosition= transform.position;
    }
}
