using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int _maxChildCapybarasAmount;
    private int _currentSpawnedChildCapybarasAmount = 0;
    private bool _isEventActivated = false;
    private string _currentSceneName;
    private int _currentAmountCapybarasSaved = 0;
    private int _amountOfEarnedStars = 0;

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
                Debug.Log(_currentSpawnedChildCapybarasAmount + " = " + _maxChildCapybarasAmount);
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
    }

    private void OnDisable()
    {
        Spawner.ChildCapybarasSpawned -= OnChildCapybarasSpawned;
        CheckRemainingCapybarasOnLevel.ChildCapybarasEnded -= OnChildCapybarasEnded;
        Finish.AmountOfChildCapybarasSaved -= OnAmountOfChildCapybarasSaved;
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
                Debug.Log("Получено 3 звезды");
                _amountOfEarnedStars = 3;
            }
            else if (percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn >= 66 && percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn <= 99)
            {
                Debug.Log("Получено 2 звезды");
                _amountOfEarnedStars = 2;
            }
            else if (percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn >= 33 && percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn <= 65)
            {
                Debug.Log("Получена 1 звезда");
                _amountOfEarnedStars = 1;
            }
            else if (percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn >= 1 && percentsRatioCurrentAmountFinishedCapybarasWithMaxAmountCapybarasForSpawn <= 32)
            {
                Debug.Log("Получена 0 звезд");
                _amountOfEarnedStars = 0;
            }
        }
        else
        {
            Debug.Log("Получено 0 звёзд");
            _amountOfEarnedStars = 0;
        }
    }

    private void CreateConfig()
    {
        Debug.Log("CreateConfigEarnedStars: " + _amountOfEarnedStars);
        Debug.Log("CreateConfigSceneName:" + _currentSceneName);
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
