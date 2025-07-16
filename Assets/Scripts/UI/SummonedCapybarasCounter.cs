using Scripts.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class SummonedCapybarasCounter : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Text _scoreText;

        [Header("Data")]
        [SerializeField] private int _maxCount;

        [SerializeField] private GameEventBus _eventBus;

        private int _currentCount;

        private void Start()
        {
            _currentCount = _maxCount;
            UpdateScoreText();
        }

        private void OnEnable()
        {
            _eventBus.OnPlayerDetected += OnPlayerDetected;
        }

        private void OnDisable()
        {
            _eventBus.OnPlayerDetected -= OnPlayerDetected;
        }

        private void OnPlayerDetected()
        {
            if (_currentCount > 0)
            {
                _currentCount--;
                UpdateScoreText();
            }

            if (_currentCount == 0)
            {
                _scoreText.gameObject.SetActive(false);
            }
        }

        private void UpdateScoreText()
        {
            _scoreText.text = $"{_currentCount}/{_maxCount}";
        }
    }
}