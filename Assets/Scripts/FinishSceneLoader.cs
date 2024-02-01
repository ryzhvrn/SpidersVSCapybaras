using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using System;

public class FinishSceneLoader : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;

    private void OnEnable()
    {
        LevelManager.CurrentLevelFinished += LoadLevelFinishedScene;
        LevelsButtonPressed.LevelsSceneActivated += LoadLevelsMenuScene;
        RestartButtonPressed.RestartCurrentLevelScene += ReloadFirstLevel;
        RestartButtonPressed.RestartCurrentLevelScene += ReloadSecondLevel;
        RestartButtonPressed.RestartCurrentLevelScene += ReloadThirdLevel;
        RestartButtonPressed.RestartCurrentLevelScene += ReloadFourthLevel;
        RestartButtonPressed.RestartCurrentLevelScene += ReloadFifthLevel;
    }

    private void OnDisable()
    {
        LevelManager.CurrentLevelFinished -= LoadLevelFinishedScene;
        LevelsButtonPressed.LevelsSceneActivated -= LoadLevelsMenuScene;
        RestartButtonPressed.RestartCurrentLevelScene -= ReloadFirstLevel;
        RestartButtonPressed.RestartCurrentLevelScene -= ReloadSecondLevel;
        RestartButtonPressed.RestartCurrentLevelScene -= ReloadThirdLevel;
        RestartButtonPressed.RestartCurrentLevelScene -= ReloadFourthLevel;
        RestartButtonPressed.RestartCurrentLevelScene -= ReloadFifthLevel;
    }

    private void LoadLevelFinishedScene()
    {
        LevelFinished.Load(_levelConfig);
        Agava.YandexGames.VideoAd.Show();
    }

    private void LoadLevelsMenuScene()
    {
        LevelsMenu.Load();
    }

    private void ReloadFirstLevel()
    {
        if (_levelConfig.CurrentLevelName == "Level1")
        {
            Level1.Load();
        }
    }

    private void ReloadSecondLevel()
    {
        if (_levelConfig.CurrentLevelName == "Level2")
        {
            Level2.Load();
        }
    }

    private void ReloadThirdLevel()
    {
        if (_levelConfig.CurrentLevelName == "Level3")
        {
            Level3.Load();
        }
    }

    private void ReloadFourthLevel()
    {
        if (_levelConfig.CurrentLevelName == "Level4")
        {
            //Level4.Load();
        }
    }

    private void ReloadFifthLevel()
    {
        if (_levelConfig.CurrentLevelName == "Level5")
        {
            //Level5.Load();
        }
    }
}
