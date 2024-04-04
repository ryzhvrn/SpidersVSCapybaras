using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using System;
using UnityEngine.UI;

public class FinishSceneLoader : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;

    private string _firstLevelName = "Level1";
    private string _secondLevelName = "Level2";
    private string _thirdLevelName = "Level3";
    private string _fourthLevelName = "Level4";
    private string _fifthLevelName = "Level5";

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
    }

    private void LoadLevelsMenuScene()
    {
        LevelsMenu.Load();
        Debug.Log("FinishSceneLoader - LoadLevelsMenu");
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

    private void ReloadFourthLevel()
    {
        if (_levelConfig.CurrentLevelName == _fourthLevelName)
        {
            //Level4.Load();
        }
    }

    private void ReloadFifthLevel()
    {
        if (_levelConfig.CurrentLevelName == _fifthLevelName)
        {
            //Level5.Load();
        }
    }
}
