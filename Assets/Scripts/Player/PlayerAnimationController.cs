using UnityEngine;

namespace Scripts.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private const string IsMoving = nameof(IsMoving);

        [SerializeField] private ThirdPersonMovementController _controller;
    
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _controller.PlayerMoving += OnPlayerMoving;
        }

        private void OnDisable()
        {
            _controller.PlayerMoving -= OnPlayerMoving;
        }

        private void OnPlayerMoving(bool moving)
        {
            _animator.SetBool(IsMoving, moving);
        }
    }
}
