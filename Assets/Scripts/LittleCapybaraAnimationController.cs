using UnityEngine;

public class LittleCapybaraAnimationController : MonoBehaviour
{
    private const string IsMoving = nameof(IsMoving);
    private Animator _animator;
    private Vector3 _lastPosition;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _lastPosition = transform.position;
    }

    private void Update()
    {
        Vector3 direction = transform.position - _lastPosition;

        if (direction.magnitude >= 0.1f)
        {
            OnLittleCapyMoving(true);
        }
        else
        {
            OnLittleCapyMoving(false);
        }

        _lastPosition = transform.position;
    }

    private void OnLittleCapyMoving(bool moving)
    {
        _animator.SetBool(IsMoving, moving);
    }
}
