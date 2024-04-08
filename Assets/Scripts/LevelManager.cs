using IJunior.TypedScenes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        CheckRemainingCapybarasOnLevel.ChildCapybarasEnded += OnChildCapybarasEnded;
        Finish.AmountOfChildCapybarasSaved += OnAmountOfChildCapybarasSaved;
        LevelsButtonPressed.LevelsSceneActivated += OnLevelsSceneActivated;
    }

    private void OnDisable()
    {
        Spawner.ChildCapybarasSpawned -= OnChildCapybarasSpawned;
        CheckRemainingCapybarasOnLevel.ChildCapybarasEnded -= OnChildCapybarasEnded;
        Finish.AmountOfChildCapybarasSaved -= OnAmountOfChildCapybarasSaved;
        LevelsButtonPressed.LevelsSceneActivated -= OnLevelsSceneActivated;
    }

    private void OnLevelsSceneActivated()
    {
        LevelsMenu.Load();
    }

    private void CalculateMaximumChildCapybarasForSpawn()
    {
        StartPoolChildCapybara[] ChildCapybarasOnStartPools = FindObjectsOfType<StartPoolChildCapybara>();
        _maxChildCapybarasAmount = ChildCapybarasOnStartPools.Length;
    }

    private void CalculateFinishedLevelProgress()
    {
        if (_currentAmountCapybarasSaved != 0)
        {
            float percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn = (float)_currentAmountCapybarasSaved / _maxChildCapybarasAmount * 100;

            if (percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn == 100)
            {
                _amountOfEarnedStars = 3;
            }
            else if (percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn >= 66
                && percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn <= 99)
            {
                _amountOfEarnedStars = 2;
            }
            else if (percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn >= 33 
                && percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn <= 65)
            {
                _amountOfEarnedStars = 1;
            }
            else if (percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn >= 1 
                && percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn <= 32)
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
