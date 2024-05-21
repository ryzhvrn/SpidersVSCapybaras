using UnityEngine;
using UnityEngine.UI;

public class SummonedCapybarasCounter : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private int _maxCount;

    private int _currentCount;

    private void Start()
    {
        _currentCount = _maxCount;
    }

    private void OnEnable()
    {
        PlayerDetector.PlayerDetected += OnPlayerDetected;
    }

    private void OnDisable()
    {
        PlayerDetector.PlayerDetected -= OnPlayerDetected;
    }

    private void OnPlayerDetected()
    {
        if (_currentCount > 0)
        {
            _currentCount--;
            _scoreText.text = _currentCount + "/" + _maxCount;
        }

        if(_currentCount==0)
        {
            _scoreText.gameObject.SetActive(false);
        }
    }
}
