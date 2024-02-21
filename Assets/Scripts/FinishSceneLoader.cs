using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using System;

public class FinishSceneLoader : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;

    private string _firstLevelName = "Level1";
    private string _secondLevelName = "Level2";
    private string _thirdLevelName = "Level3";
    private VideoAd _ads;

    private void OnEnable()
    {
        LevelManager.CurrentLevelFinished += LoadLevelFinishedScene;
        LevelsButtonPressed.LevelsSceneActivated += LoadLevelsMenuScene;
        RestartButtonPressed.RestartCurrentLevelScene += ReloadFirstLevel;
        RestartButtonPressed.RestartCurrentLevelScene += ReloadSecondLevel;
        RestartButtonPressed.RestartCurrentLevelScene += ReloadThirdLevel;
    }

    private void OnDisable()
    {
        LevelManager.CurrentLevelFinished -= LoadLevelFinishedScene;
        LevelsButtonPressed.LevelsSceneActivated -= LoadLevelsMenuScene;
        RestartButtonPressed.RestartCurrentLevelScene -= ReloadFirstLevel;
        RestartButtonPressed.RestartCurrentLevelScene -= ReloadSecondLevel;
        RestartButtonPressed.RestartCurrentLevelScene -= ReloadThirdLevel;
    }

    private void LoadLevelFinishedScene()
    {
        LevelFinished.Load(_levelConfig);
        _ads.ShowInterstitialAd();
    }

    private void LoadLevelsMenuScene()
    {
        LevelsMenu.Load();
    }

    private void ReloadFirstLevel()
    {
        if (_levelConfig.CurrentLevelName == _firstLevelName)
        {
            Level1.Load();
        }
    }

    private void ReloadSecondLevel()
    {
        if (_levelConfig.CurrentLevelName == _secondLevelName)
        {
            Level2.Load();
        }
    }

    private void ReloadThirdLevel()
    {
        if (_levelConfig.CurrentLevelName == _thirdLevelName)
        {
            Level3.Load();
        }
    }
}
