using System;
using Scripts.Capybaras;
using UnityEngine;

namespace Scripts.Services
{
    public class GameEventBus : MonoBehaviour
    {
        public event Action OnAllCapybarasReachedFinish;
        public event Action<Capy> OnCapySpawned;
        public event Action<Capy> OnCapyDied;
        public event Action<int> OnChildCapybarasSpawned;
        public event Action OnAllCapybarasSpawned;
        public event Action OnChildCapybarasEnded;
        public event Action OnPlayerDetected;
        public event Action OnPlayerFinished;
        public event Action OnFinished;
        public event Action OnCapyFinishedForUI;
        public event Action OnCapyFinishedForEnemy;
        public event Action<int> OnAmountOfCapybarasSaved;
        public event Action OnNotifyFinishAboutLevelFinished;
        public event Action<int, string> OnNotifyLevelConfigAboutAmountOfEarnedStars;
        public event Action OnCurrentLevelFinished;
        public event Action OnLevelsSceneActivated;
        public event Action OnEnemyAttacking;
        public event Action<bool> OnEnemyMoving;
        public event Action OnCapyCatched;
        public event Action<bool> OnCapybarasDetected;
        public event Action<bool> OnAttackReloadCompleted;
        public event Action<Capy> OnTriggerZoneEntered;
        public event Action<Capy> OnTriggerZoneLeft;
    
        public void AllCapybarasReachedFinish() => OnAllCapybarasReachedFinish?.Invoke();
        public void CapySpawned(Capy capy) => OnCapySpawned?.Invoke(capy);
        public void CapyDied(Capy capy) => OnCapyDied?.Invoke(capy);
        public void ChildCapybarasSpawned(int count) => OnChildCapybarasSpawned?.Invoke(count);
        public void AllCapybarasSpawned() => OnAllCapybarasSpawned?.Invoke();
        public void ChildCapybarasEnded() => OnChildCapybarasEnded?.Invoke();
        public void PlayerDetected() => OnPlayerDetected?.Invoke();
        public void PlayerFinished() => OnPlayerFinished?.Invoke();
        public void Finished() => OnFinished?.Invoke();
        public void CapyFinishedForUI() => OnCapyFinishedForUI?.Invoke();
        public void CapyFinishedForEnemy() => OnCapyFinishedForEnemy?.Invoke();
        public void AmountOfCapybarasSaved(int amount) => OnAmountOfCapybarasSaved?.Invoke(amount);
        public void NotifyFinishAboutLevelFinished() => OnNotifyFinishAboutLevelFinished?.Invoke();
        public void NotifyLevelConfigAboutAmountOfEarnedStars(int stars, string sceneName)
            => OnNotifyLevelConfigAboutAmountOfEarnedStars?.Invoke(stars, sceneName);
        public void CurrentLevelFinished() => OnCurrentLevelFinished?.Invoke();
        public void LevelsSceneActivated() => OnLevelsSceneActivated?.Invoke();
        public void EnemyAttacking() => OnEnemyAttacking?.Invoke();
        public void EnemyMoving(bool isMoving) => OnEnemyMoving?.Invoke(isMoving);
        public void CapyCatched() => OnCapyCatched?.Invoke();
        public void CapybarasDetected(bool found) => OnCapybarasDetected?.Invoke(found);
        public void AttackReloadCompleted(bool allowed) => OnAttackReloadCompleted?.Invoke(allowed);
        public void TriggerZoneEntered(Capy capy) => OnTriggerZoneEntered?.Invoke(capy);
        public void TriggerZoneLeft(Capy capy) => OnTriggerZoneLeft?.Invoke(capy);
    }
}
