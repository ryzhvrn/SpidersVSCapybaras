using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public static event Action<bool> AttackReloadCompleted;

    [SerializeField] private Animator _animator;
    private const string isWalking = nameof(isWalking);
    private const string isAttacking = nameof(isAttacking);
    private const string isAttackingTrigger = nameof(isAttackingTrigger);

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
        Debug.Log("Атака на перезарядке!");
        AttackReloadCompleted?.Invoke(false);
        _animator.ResetTrigger(isAttackingTrigger);
    }

    public void ReturnAttackAbility()
    {
        Debug.Log("Можно атаковать!");
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
