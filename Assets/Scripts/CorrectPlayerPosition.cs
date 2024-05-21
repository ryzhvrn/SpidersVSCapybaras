using System.Collections;
using UnityEngine;

public class CorrectPlayerPosition : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private float _initialYPosition;
    private float _acceptableDistance = 0.01f;

    private void Start()
    {
        _initialYPosition = _playerTransform.position.y;
        StartCoroutine(CorrectPlayerPositionCoroutine());
    }

    private IEnumerator CorrectPlayerPositionCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (Mathf.Abs(_playerTransform.position.y - _initialYPosition) > _acceptableDistance)
            {
                Vector3 newPosition = _playerTransform.position; 
                newPosition.y = _initialYPosition;
                _playerTransform.position = newPosition;
            }
        }
    }
}
