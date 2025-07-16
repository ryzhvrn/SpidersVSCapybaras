using Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class ScoreChanger : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private int _maxCapybarasCount;
        [SerializeField] private GameEventBus _eventBus;

        private int _score = 0;

        private void OnEnable()
        {
            _eventBus.OnCapyFinishedForUI += OnPlayerLevelReached;
        }

        private void OnDisable()
        {
            _eventBus.OnCapyFinishedForUI -= OnPlayerLevelReached;
        }

        private void OnPlayerLevelReached()
        {
            _score++;
            _scoreText.text = _score + "/" + _maxCapybarasCount;
        }
    }
}