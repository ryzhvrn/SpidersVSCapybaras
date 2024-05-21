using System;
using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;

public class FinishSceneLoader : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;

    private Dictionary<string, Action> _levelReloadActions = new Dictionary<string, Action>();

    private void OnEnable()
    {
        LevelManager.CurrentLevelFinished += LoadLevelFinishedScene;
        OpenLevelsScene.LevelsSceneActivated += LoadLevelsMenuScene;
        Restart.RestartCurrentLevelScene += ReloadLevel;
    }

    private void OnDisable()
    {
        LevelManager.CurrentLevelFinished -= LoadLevelFinishedScene;
        OpenLevelsScene.LevelsSceneActivated -= LoadLevelsMenuScene;
        Restart.RestartCurrentLevelScene -= ReloadLevel;
    }

    private void Start()
    {
        InitializeLevelReloadActions();
    }

    private void InitializeLevelReloadActions()
    {
        _levelReloadActions.Add("Level1", () => Level1.Load());
        _levelReloadActions.Add("Level2", () => Level2.Load());
        _levelReloadActions.Add("Level3", () => Level3.Load());
        _levelReloadActions.Add("Level4", () => Level4.Load());
        _levelReloadActions.Add("Level5", () => Level5.Load());
        _levelReloadActions.Add("Level6", () => Level6.Load());
    }

    private void LoadLevelFinishedScene()
    {
        LevelFinished.Load(_levelConfig);
    }

    private void LoadLevelsMenuScene()
    {
        LevelsMenu.Load();
    }

    private void ReloadLevel()
    {
        if (_levelReloadActions.ContainsKey(_levelConfig.CurrentLevelName))
        {
            _levelReloadActions[_levelConfig.CurrentLevelName]();
        }
    }
}
