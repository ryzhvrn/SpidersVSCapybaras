using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetLeaderboardProgress : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerScore;
    private List<string> _levelNames = new List<string>();
    private int _totalStars = 0;

    private void Start()
    {
        SetLevelNames();
        SetPlayerScore();
    }

    private void SetLevelNames()
    {
        _levelNames.Add("Level1");
        _levelNames.Add("Level2");
        _levelNames.Add("Level3");
        _levelNames.Add("Level4");
        _levelNames.Add("Level5");
        _levelNames.Add("Level6");
    }

    private void SetPlayerScore()
    {
        foreach (string levelName in _levelNames)
        {
            if (PlayerPrefs.HasKey(levelName))
            {
                int starsAmount = PlayerPrefs.GetInt(levelName);
                _totalStars += starsAmount;
            }
            else
            {
                _totalStars += 0;
            }
        }

        _playerScore.text = _totalStars.ToString();
    }
}
