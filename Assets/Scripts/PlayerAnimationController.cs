using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private const string IsMoving = nameof(IsMoving);
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ThirdPersonMovementController.PlayerMoving += OnPlayerMoving;
    }

    private void OnDisable()
    {
        ThirdPersonMovementController.PlayerMoving -= OnPlayerMoving;
    }

    private void OnPlayerMoving(bool moving)
    {
        _animator.SetBool(IsMoving, moving);
    }
}
