using System;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private const string IsWalking = nameof(IsWalking);
    private const string IsAttacking  = nameof(IsAttacking);

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
    }

    private void OnDisable()
    {
        _eventBus.OnEnemyAttacking -= OnEnemyAttacking;
        _eventBus.OnCapybarasDetected -= OnCapybarasDetected;
    }

    public void BlockAttackAbility()
    {
        _eventBus.AttackReloadCompleted(false);
        _animator.ResetTrigger(IsAttacking);
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
        _animator.SetTrigger(IsAttacking);
    }
}