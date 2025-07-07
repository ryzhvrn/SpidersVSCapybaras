using System;
using UnityEngine;

public class GameEventBus : MonoBehaviour
{
    // === Capy Events ===
    public event Action OnAllCapybarasReachedFinish;
    public void AllCapybarasReachedFinish() => OnAllCapybarasReachedFinish?.Invoke();
    
    
    public event Action<Capy> OnCapySpawned;
    public void CapySpawned(Capy capy) => OnCapySpawned?.Invoke(capy);

    public event Action<Capy> OnCapyDied;
    public void CapyDied(Capy capy) => OnCapyDied?.Invoke(capy);

    // === Spawning ===
    public event Action<int> OnChildCapybarasSpawned;
    public void ChildCapybarasSpawned(int count) => OnChildCapybarasSpawned?.Invoke(count);

    public event Action OnAllCapybarasSpawned;
    public void AllCapybarasSpawned() => OnAllCapybarasSpawned?.Invoke();

    public event Action OnChildCapybarasEnded;
    public void ChildCapybarasEnded() => OnChildCapybarasEnded?.Invoke();

    // === Player Events ===
    public event Action OnPlayerDetected;
    public void PlayerDetected() => OnPlayerDetected?.Invoke();

    public event Action OnPlayerFinished;
    public void PlayerFinished() => OnPlayerFinished?.Invoke();

    // === Finish Events ===
    public event Action OnFinished;
    public void Finished() => OnFinished?.Invoke();

    public event Action OnCapyFinishedForUI;
    public void CapyFinishedForUI() => OnCapyFinishedForUI?.Invoke();

    public event Action OnCapyFinishedForEnemy;
    public void CapyFinishedForEnemy() => OnCapyFinishedForEnemy?.Invoke();

    public event Action<int> OnAmountOfCapybarasSaved;
    public void AmountOfCapybarasSaved(int amount) => OnAmountOfCapybarasSaved?.Invoke(amount);

    public event Action OnNotifyFinishAboutLevelFinished;
    public void NotifyFinishAboutLevelFinished() => OnNotifyFinishAboutLevelFinished?.Invoke();

    // === LevelManager / Level Progress ===
    public event Action<int, string> OnNotifyLevelConfigAboutAmountOfEarnedStars;
    public void NotifyLevelConfigAboutAmountOfEarnedStars(int stars, string sceneName)
        => OnNotifyLevelConfigAboutAmountOfEarnedStars?.Invoke(stars, sceneName);

    public event Action OnCurrentLevelFinished;
    public void CurrentLevelFinished() => OnCurrentLevelFinished?.Invoke();

    public event Action OnLevelsSceneActivated;
    public void LevelsSceneActivated() => OnLevelsSceneActivated?.Invoke();

    // === Combat / Enemy ===
    public event Action OnEnemyAttacking;
    public void EnemyAttacking() => OnEnemyAttacking?.Invoke();

    public event Action OnCapyCatched;
    public void CapyCatched() => OnCapyCatched?.Invoke();

    public event Action<bool> OnCapybarasDetected;
    public void CapybarasDetected(bool found) => OnCapybarasDetected?.Invoke(found);

    public event Action<bool> OnAttackReloadCompleted;
    public void AttackReloadCompleted(bool allowed) => OnAttackReloadCompleted?.Invoke(allowed);

    // === Trigger Zone ===
    public event Action<Capy> OnTriggerZoneEntered;
    public void TriggerZoneEntered(Capy capy) => OnTriggerZoneEntered?.Invoke(capy);

    public event Action<Capy> OnTriggerZoneLeft;
    public void TriggerZoneLeft(Capy capy) => OnTriggerZoneLeft?.Invoke(capy);
}
