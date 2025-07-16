using Scripts.SO;
using UnityEngine;

namespace Scripts.Services
{
    public class LevelConfigUpdater : MonoBehaviour
    {
        [SerializeField] private GameEventBus _eventBus;
        [SerializeField] private LevelConfig _levelConfig;

        private void OnEnable()
        {
            _eventBus.OnNotifyLevelConfigAboutAmountOfEarnedStars += UpdateConfig;
        }

        private void OnDisable()
        {
            _eventBus.OnNotifyLevelConfigAboutAmountOfEarnedStars -= UpdateConfig;
        }

        private void UpdateConfig(int amount, string levelName)
        {
            _levelConfig.SetConfigInfo(amount, levelName);
        }
    }
}