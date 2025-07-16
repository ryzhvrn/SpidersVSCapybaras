using Scripts.Services;
using UnityEngine;

namespace Scripts.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private const string IsWalking = nameof(IsWalking);
        private const string IsAttacking  = nameof(IsAttacking);
        private const string IsAttackingTrigger = nameof(IsAttackingTrigger);

        [SerializeField] private Animator _animator;
        [SerializeField] private GameEventBus _eventBus;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _eventBus.OnEnemyAttacking += OnEnemyAttacking;
            _eventBus.OnCapybarasDetected += OnCapybarasDetected;
            _eventBus.OnEnemyMoving += OnEnemyMoving;
        }

        private void OnDisable()
        {
            _eventBus.OnEnemyAttacking -= OnEnemyAttacking;
            _eventBus.OnCapybarasDetected -= OnCapybarasDetected;
            _eventBus.OnEnemyMoving -= OnEnemyMoving;
        }

        public void BlockAttackAbility()
        {
            _eventBus.AttackReloadCompleted(false);
            _animator.ResetTrigger(IsAttacking);
        }

        public void OnEnemyMoving(bool isMoving)
        {
            _animator.SetBool(IsWalking, isMoving);
        }

        public void ReturnAttackAbility()
        {
            _eventBus.AttackReloadCompleted(true);
        }

        private void OnCapybarasDetected(bool moving)
        {
            _animator.SetBool(IsWalking, moving);
        }

        private void OnEnemyAttacking()
        {
            _animator.SetTrigger(IsAttackingTrigger);
        }
    }
}