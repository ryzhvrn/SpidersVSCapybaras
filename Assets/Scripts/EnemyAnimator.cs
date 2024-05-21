using System;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private const string IsWalking = nameof(IsWalking);
    private const string IsAttacking = nameof(IsAttacking);
    private const string IsAttackingTrigger = nameof(IsAttackingTrigger);
    [SerializeField] private Animator _animator;

    public static event Action<bool> AttackReloadCompleted;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EnemyMovementNotifier.EnemyMoving += OnEnemyMoving;
        CatchCapy.EnemyAttacking += OnEnemyAttacking;
    }

    private void OnDisable()
    {
        EnemyMovementNotifier.EnemyMoving -= OnEnemyMoving;
        CatchCapy.EnemyAttacking -= OnEnemyAttacking;
    }

    public void BlockAttackAbility()
    {
        AttackReloadCompleted?.Invoke(false);
        _animator.ResetTrigger(IsAttackingTrigger);
    }

    public void ReturnAttackAbility()
    {
        AttackReloadCompleted?.Invoke(true);
    }

    private void OnEnemyMoving(bool moving)
    {
        _animator.SetBool(IsWalking, moving);
    }

    private void OnEnemyAttacking()
    {
        _animator.SetTrigger(IsAttackingTrigger);
    }
}
