using Agava.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _ranks;
    [SerializeField] private TMP_Text[] _leaderNames;
    [SerializeField] private TMP_Text[] _scoreList;
    [SerializeField] private string _leaderboardName = "Leaderboard";

    private const string EnglishAnonymousName = "Anonymous";
    private const string RussianAnonymousName = "Аноним";
    private const string TurkishAnonymousName = "Anonim";

    private List<string> _levelNames = new List<string>();
    private int _playerScore = 0;

    private void Start()
    {
        SetLevelNames();
        SetLeaderboardScore();
        OpenYandexLeaderboard();
    }

    private void OnEnable()
    {
        LevelFinishedLoader.SetPlayerScore += SetLeaderboardScore;
    }

    private void OnDisable()
    {
        LevelFinishedLoader.SetPlayerScore -= SetLeaderboardScore;
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
                _playerScore += starsAmount;
            }
            else
            {
                _playerScore += 0;
            }
        }
    }

    public void OpenYandexLeaderboard()
    {
        Leaderboard.GetEntries(_leaderboardName, (result) =>
        {
            int leadersNumber = result.entries.Length >= _leaderNames.Length ? _leaderNames.Length : result.entries.Length;

            for (int i = 0; i < leadersNumber; i++)
            {
                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                {
                    string currentLanguage = YandexGamesSdk.Environment.i18n.lang;
                    Debug.Log("currentLanguageCode: " + currentLanguage);

                    switch (currentLanguage)
                    {
                        case "ru":
                            name = RussianAnonymousName;
                            break;
                        case "en":
                            name = EnglishAnonymousName;
                            break;
                        case "tr":
                            name = TurkishAnonymousName;
                            break;
                        default:
                            name = EnglishAnonymousName;
                            break;
                    }
                }

                _leaderNames[i].text = name;
                _scoreList[i].text = result.entries[i].formattedScore;
                _ranks[i].text = result.entries[i].rank.ToString();
            }
        });
    }

    public void SetLeaderboardScore()
    {
        if (YandexGamesSdk.IsInitialized)
        {
            Leaderboard.GetPlayerEntry(_leaderboardName, OnSuccessCallback);
        }
    }

    private void OnSuccessCallback(LeaderboardEntryResponse result)
    {
        SetPlayerScore();

        if (result == null || _playerScore > result.score)
        {
            Leaderboard.SetScore(_leaderboardName, _playerScore);
        }
    }
}
