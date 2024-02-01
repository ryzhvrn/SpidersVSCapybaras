using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Create Level Config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _starsAmountEarned;
    [SerializeField] private string _currentLevelName;

    public int StarsEarned => _starsAmountEarned;
    public string CurrentLevelName => _currentLevelName;

    private void OnEnable()
    {
        LevelManager.NotifyLevelConfigAboutAmountOfEarnedStars += SetConfigInfo;
    }

    private void OnDisable()
    {
        LevelManager.NotifyLevelConfigAboutAmountOfEarnedStars -= SetConfigInfo;
    }

    private void SetConfigInfo(int amount, string name)
    {
        _starsAmountEarned = amount;
        _currentLevelName = name;
    }
}
