using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenuLoader : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;

    [SerializeField] private Image _ZeroStarsEarnedFirstLevel;
    [SerializeField] private Image _OneStarsEarnedFirstLevel;
    [SerializeField] private Image _TwoStarsEarnedFirstLevel;
    [SerializeField] private Image _ThreeStarsEarnedFirstLevel;

    [SerializeField] private Image _ZeroStarsEarnedSecondLevel;
    [SerializeField] private Image _OneStarsEarnedSecondLevel;
    [SerializeField] private Image _TwoStarsEarnedSecondLevel;
    [SerializeField] private Image _ThreeStarsEarnedSecondLevel;

    [SerializeField] private Image _ZeroStarsEarnedThirdLevel;
    [SerializeField] private Image _OneStarsEarnedThirdLevel;
    [SerializeField] private Image _TwoStarsEarnedThirdLevel;
    [SerializeField] private Image _ThreeStarsEarnedThirdLevel;

    [SerializeField] private Image _ZeroStarsEarnedFourthLevel;
    [SerializeField] private Image _OneStarsEarnedFourthLevel;
    [SerializeField] private Image _TwoStarsEarnedFourthLevel;
    [SerializeField] private Image _ThreeStarsEarnedFourthLevel;

    [SerializeField] private Image _ZeroStarsEarnedFifthLevel;
    [SerializeField] private Image _OneStarsEarnedFifthLevel;
    [SerializeField] private Image _TwoStarsEarnedFifthLevel;
    [SerializeField] private Image _ThreeStarsEarnedFifthLevel;

    [SerializeField] private Image _lockedLevelSecondLevelImage;
    [SerializeField] private Image _lockedLevelThirdLevelImage;
    [SerializeField] private Image _lockedLevelFourthLevelImage;
    [SerializeField] private Image _lockedLevelFifthLevelImage;

    private void Start()
    {
        SetCurrentFinishedLevelProgress("Level1");
        SetCurrentFinishedLevelProgress("Level2");
        SetCurrentFinishedLevelProgress("Level3");
        SetCurrentFinishedLevelProgress("Level4");
        SetCurrentFinishedLevelProgress("Level5");
        SetLevelsProgress("Level1", _ZeroStarsEarnedFirstLevel, _OneStarsEarnedFirstLevel, _TwoStarsEarnedFirstLevel, _ThreeStarsEarnedFirstLevel, _lockedLevelSecondLevelImage);
        SetLevelsProgress("Level2", _ZeroStarsEarnedSecondLevel, _OneStarsEarnedSecondLevel, _TwoStarsEarnedSecondLevel, _ThreeStarsEarnedSecondLevel, _lockedLevelThirdLevelImage);
        SetLevelsProgress("Level3", _ZeroStarsEarnedThirdLevel, _OneStarsEarnedThirdLevel, _TwoStarsEarnedThirdLevel, _ThreeStarsEarnedThirdLevel, _lockedLevelFourthLevelImage);
        SetLevelsProgress("Level4", _ZeroStarsEarnedFourthLevel, _OneStarsEarnedFourthLevel, _TwoStarsEarnedFourthLevel, _ThreeStarsEarnedFourthLevel, _lockedLevelFifthLevelImage);
        SetLevelsProgress("Level5", _ZeroStarsEarnedFifthLevel, _OneStarsEarnedFifthLevel, _TwoStarsEarnedFifthLevel, _ThreeStarsEarnedFifthLevel, null);
    }

    private void SetCurrentFinishedLevelProgress(string levelName)
    {
        if (_levelConfig.CurrentLevelName == levelName)
        {
            int currentLevelStarsEarned = _levelConfig.StarsEarned;
            int savedAmountOfStarsOnLevelEarned = GetStarsOnLevelEarned(_levelConfig.CurrentLevelName);

            if (savedAmountOfStarsOnLevelEarned < currentLevelStarsEarned)
            {
                SetStarsOnLevelEarned(_levelConfig.CurrentLevelName, currentLevelStarsEarned);
            }
        }
    }

    private void SetStarsOnLevelEarned(string levelName, int starsEarned)
    {
        PlayerPrefs.SetInt(levelName, starsEarned);
        PlayerPrefs.Save();
    }

    private int GetStarsOnLevelEarned(string levelName)
    {
        if (PlayerPrefs.HasKey(levelName))
        {
            return PlayerPrefs.GetInt(levelName);
        }
        else
        {
            return -1;
        }
    }

    private void SetLevelsProgress(string levelName, Image zeroStars, Image OneStar, Image twoStars, Image threeStars, Image nextLevelLocked)
    {
        if (PlayerPrefs.HasKey(levelName))
        {
            int levelStarsReached = PlayerPrefs.GetInt(levelName);

            switch (levelStarsReached)
            {
                case 0:
                    zeroStars.gameObject.SetActive(true);
                    OneStar.gameObject.SetActive(false);
                    twoStars.gameObject.SetActive(false);
                    threeStars.gameObject.SetActive(false);

                    if (nextLevelLocked != null)
                    {
                        nextLevelLocked.gameObject.SetActive(true);
                    }

                    break;
                case 1:
                    zeroStars.gameObject.SetActive(false);
                    OneStar.gameObject.SetActive(true);
                    twoStars.gameObject.SetActive(false);
                    threeStars.gameObject.SetActive(false);

                    if (nextLevelLocked != null)
                    {
                        nextLevelLocked.gameObject.SetActive(false);
                    }

                    break;
                case 2:
                    zeroStars.gameObject.SetActive(false);
                    OneStar.gameObject.SetActive(false);
                    twoStars.gameObject.SetActive(true);
                    threeStars.gameObject.SetActive(false);

                    if (nextLevelLocked != null)
                    {
                        nextLevelLocked.gameObject.SetActive(false);
                    }

                    break;
                case 3:
                    zeroStars.gameObject.SetActive(false);
                    OneStar.gameObject.SetActive(false);
                    twoStars.gameObject.SetActive(false);
                    threeStars.gameObject.SetActive(true);

                    if (nextLevelLocked != null)
                    {
                        nextLevelLocked.gameObject.SetActive(false);
                    }

                    break;
                default:
                    Debug.Log("LevelName " + levelName + " levelStarsReached: " + levelStarsReached + " Wrong!!!");
                    break;
            }
        }
        else
        {
            Debug.Log("No info about: " + levelName);

            return;
        }
    }
}
