using System;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string isWalking = nameof(isWalking);
    private const string isAttacking = nameof(isAttacking);
    private const string isAttackingTrigger = nameof(isAttackingTrigger);

    public static event Action<bool> AttackReloadCompleted;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EnemyMovementController.EnemyMoving += OnEnemyMoving;
        CatchCapy.EnemyAttacking += OnEnemyAttacking;
    }

    private void OnDisable()
    {
        EnemyMovementController.EnemyMoving -= OnEnemyMoving;
        CatchCapy.EnemyAttacking -= OnEnemyAttacking;
    }

    public void BlockAttackAbility()
    {
        AttackReloadCompleted?.Invoke(false);
        _animator.ResetTrigger(isAttackingTrigger);
    }

    public void ReturnAttackAbility()
    {
        AttackReloadCompleted?.Invoke(true);
    }

    private void OnEnemyMoving(bool moving)
    {
        _animator.SetBool(isWalking, moving);
    }

    private void OnEnemyAttacking()
    {
        _animator.SetTrigger(isAttackingTrigger);
    }
}
