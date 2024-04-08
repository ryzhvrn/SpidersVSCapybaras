using UnityEngine;
using UnityEngine.UI;

public class ScoreChanger : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private int _maxCapybarasCount;

    private int _score = 0;

    private void OnEnable()
    {
        Finish.CapyFinishedForUI += OnPlayerLevelReached;
    }

    private void OnDisable()
    {
        Finish.CapyFinishedForUI -= OnPlayerLevelReached;
    }

    private void OnPlayerLevelReached()
    {
        _score++;
        _scoreText.text = _score.ToString();
        _scoreText.text = _score + "/" + _maxCapybarasCount;
    }
}
