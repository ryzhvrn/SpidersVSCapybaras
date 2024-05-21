using UnityEngine;

public class LittleCapybaraAnimationController : MonoBehaviour
{
    private const string IsMoving = nameof(IsMoving);
    private Animator _animator;
    private Vector3 _lastPosition;
    private float _differenceValue = 0.1f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _lastPosition = transform.position;
    }

    private void Update()
    {
        bool isMoving = (transform.position - _lastPosition).magnitude >= _differenceValue;
        SetLittleCapybaraAnimatorStatus(isMoving);
        _lastPosition = transform.position;
    }

    private void SetLittleCapybaraAnimatorStatus(bool moving)
    {
        _animator.SetBool(IsMoving, moving);
    }
}
