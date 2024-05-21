using System;
using IJunior.TypedScenes;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int _maxChildCapybarasAmount;
    private int _currentSpawnedChildCapybarasAmount = 0;
    private int _currentAmountCapybarasSaved = 0;
    private int _amountOfEarnedStars = 0;
    private bool _isEventActivated = false;
    private string _currentSceneName;

    public static event Action AllChildCapybarasSpawned;
    public static event Action CurrentLevelFinished;
    public static event Action NotifyFinishAboutLevelFinished;
    public static event Action<int, string> NotifyLevelConfigAboutAmountOfEarnedStars;

    private void Start()
    {
        _currentSceneName = SceneManager.GetActiveScene().name;
        CalculateMaximumChildCapybarasForSpawn();
    }

    private void Update()
    {
        if (_currentSpawnedChildCapybarasAmount == _maxChildCapybarasAmount)
        {
            if (_isEventActivated == false)
            {
                AllChildCapybarasSpawned?.Invoke();
                _isEventActivated = true;
            }
            else
            {
                return;
            }
        }
    }

    private void OnEnable()
    {
        Spawner.ChildCapybarasSpawned += OnChildCapybarasSpawned;
        RemainingCapybarasDetector.ChildCapybarasEnded += OnChildCapybarasEnded;
        Finish.AmountOfChildCapybarasSaved += OnAmountOfChildCapybarasSaved;
        OpenLevelsScene.LevelsSceneActivated += OnLevelsSceneActivated;
    }

    private void OnDisable()
    {
        Spawner.ChildCapybarasSpawned -= OnChildCapybarasSpawned;
        RemainingCapybarasDetector.ChildCapybarasEnded -= OnChildCapybarasEnded;
        Finish.AmountOfChildCapybarasSaved -= OnAmountOfChildCapybarasSaved;
        OpenLevelsScene.LevelsSceneActivated -= OnLevelsSceneActivated;
    }

    private void OnLevelsSceneActivated()
    {
        LevelsMenu.Load();
    }

    private void CalculateMaximumChildCapybarasForSpawn()
    {
        StartPoolChildCapybara[] childCapybarasOnStartPools = FindObjectsOfType<StartPoolChildCapybara>();
        _maxChildCapybarasAmount = childCapybarasOnStartPools.Length;
    }

    private void CalculateFinishedLevelProgress()
    {
        if (_currentAmountCapybarasSaved != 0)
        {
            float value = (float)_currentAmountCapybarasSaved / _maxChildCapybarasAmount * 100;

            if (value == 100)
            {
                _amountOfEarnedStars = 3;
            }
            else if (value >= 66 && value <= 99)
            {
                _amountOfEarnedStars = 2;
            }
            else if (value >= 33 && value <= 65)
            {
                _amountOfEarnedStars = 1;
            }
            else if (value >= 1 && value <= 32)
            {
                _amountOfEarnedStars = 0;
            }
        }
        else
        {
            _amountOfEarnedStars = 0;
        }
    }

    private void CreateConfig()
    {
        NotifyLevelConfigAboutAmountOfEarnedStars?.Invoke(_amountOfEarnedStars, _currentSceneName);
    }

    private void OnAmountOfChildCapybarasSaved(int amount)
    {
        _currentAmountCapybarasSaved = amount;
    }

    private void OnChildCapybarasEnded()
    {
        NotifyFinishAboutLevelFinished?.Invoke();
        CalculateFinishedLevelProgress();
        CreateConfig();
        CurrentLevelFinished?.Invoke();
    }

    private void OnChildCapybarasSpawned(int amount)
    {
        _currentSpawnedChildCapybarasAmount += amount;
    }
}
