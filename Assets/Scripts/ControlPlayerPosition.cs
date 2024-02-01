using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerPosition : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private float _initialYPosition; 

    private void Start()
    {
        _initialYPosition = _playerTransform.position.y;
        StartCoroutine(CorrectPlayerPosition());
    }

    private IEnumerator CorrectPlayerPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (Mathf.Abs(_playerTransform.position.y - _initialYPosition) > 0.01f) 
            {
                Vector3 newPosition = _playerTransform.position; 
                newPosition.y = _initialYPosition;
                _playerTransform.position = newPosition;
            }
        }
    }
}
