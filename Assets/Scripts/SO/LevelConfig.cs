using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Create Level Config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _starsAmountEarned;
    [SerializeField] private string _currentLevelName;

    public int StarsEarned => _starsAmountEarned;
    public string CurrentLevelName => _currentLevelName;

    public void SetConfigInfo(int amount, string name)
    {
        _starsAmountEarned = amount;
        _currentLevelName = name;
    }
}
