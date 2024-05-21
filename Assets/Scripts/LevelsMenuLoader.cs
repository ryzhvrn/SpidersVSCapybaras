using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenuLoader : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;

    [SerializeField] private Image _zeroStarsEarnedFirstLevel;
    [SerializeField] private Image _oneStarsEarnedFirstLevel;
    [SerializeField] private Image _twoStarsEarnedFirstLevel;
    [SerializeField] private Image _threeStarsEarnedFirstLevel;

    [SerializeField] private Image _zeroStarsEarnedSecondLevel;
    [SerializeField] private Image _oneStarsEarnedSecondLevel;
    [SerializeField] private Image _twoStarsEarnedSecondLevel;
    [SerializeField] private Image _threeStarsEarnedSecondLevel;

    [SerializeField] private Image _zeroStarsEarnedThirdLevel;
    [SerializeField] private Image _oneStarsEarnedThirdLevel;
    [SerializeField] private Image _twoStarsEarnedThirdLevel;
    [SerializeField] private Image _threeStarsEarnedThirdLevel;

    [SerializeField] private Image _zeroStarsEarnedFourthLevel;
    [SerializeField] private Image _oneStarsEarnedFourthLevel;
    [SerializeField] private Image _twoStarsEarnedFourthLevel;
    [SerializeField] private Image _threeStarsEarnedFourthLevel;

    [SerializeField] private Image _zeroStarsEarnedFifthLevel;
    [SerializeField] private Image _oneStarsEarnedFifthLevel;
    [SerializeField] private Image _twoStarsEarnedFifthLevel;
    [SerializeField] private Image _threeStarsEarnedFifthLevel;

    [SerializeField] private Image _zeroStarsEarnedSixthLevel;
    [SerializeField] private Image _oneStarsEarnedSixthLevel;
    [SerializeField] private Image _twoStarsEarnedSixthLevel;
    [SerializeField] private Image _threeStarsEarnedSixthLevel;

    [SerializeField] private Image _lockedLevelSecondLevelImage;
    [SerializeField] private Image _lockedLevelThirdLevelImage;
    [SerializeField] private Image _lockedLevelFourthLevelImage;
    [SerializeField] private Image _lockedLevelFifthLevelImage;
    [SerializeField] private Image _lockedLevelSixthLevelImage;

    [SerializeField] private Image[] _firstLevelStars;
    [SerializeField] private Image[] _secondLevelStars;
    [SerializeField] private Image[] _thirdLevelStars;
    [SerializeField] private Image[] _fourthLevelStars;
    [SerializeField] private Image[] _fifthLevelStars;
    [SerializeField] private Image[] _sixthLevelStars;
    [SerializeField] private Image[] _lockedLevelImages;

    private void Start()
    {
        SetCurrentFinishedLevelProgress("Level1");
        SetCurrentFinishedLevelProgress("Level2");
        SetCurrentFinishedLevelProgress("Level3");
        SetCurrentFinishedLevelProgress("Level4");
        SetCurrentFinishedLevelProgress("Level5");
        SetCurrentFinishedLevelProgress("Level6");
        SetLevelsProgress(
            "Level1",
            _zeroStarsEarnedFirstLevel,
            _oneStarsEarnedFirstLevel,
            _twoStarsEarnedFirstLevel,
            _threeStarsEarnedFirstLevel,
            _lockedLevelSecondLevelImage);
        SetLevelsProgress(
            "Level2",
            _zeroStarsEarnedSecondLevel,
            _oneStarsEarnedSecondLevel,
            _twoStarsEarnedSecondLevel,
            _threeStarsEarnedSecondLevel,
            _lockedLevelThirdLevelImage);
        SetLevelsProgress(
            "Level3",
            _zeroStarsEarnedThirdLevel,
            _oneStarsEarnedThirdLevel,
            _twoStarsEarnedThirdLevel,
            _threeStarsEarnedThirdLevel,
            _lockedLevelFourthLevelImage);
        SetLevelsProgress(
            "Level4",
            _zeroStarsEarnedFourthLevel,
            _oneStarsEarnedFourthLevel,
            _twoStarsEarnedFourthLevel,
            _threeStarsEarnedFourthLevel,
            _lockedLevelFifthLevelImage);
        SetLevelsProgress(
            "Level5",
            _zeroStarsEarnedFifthLevel,
            _oneStarsEarnedFifthLevel,
            _twoStarsEarnedFifthLevel,
            _threeStarsEarnedFifthLevel,
            _lockedLevelSixthLevelImage);
        SetLevelsProgress(
            "Level6",
            _zeroStarsEarnedSixthLevel,
            _oneStarsEarnedSixthLevel,
            _twoStarsEarnedSixthLevel,
            _threeStarsEarnedSixthLevel,
            null);
    }

    private void OnEnable()
    {
        SecretLevelButtonPressed.SecretLevelActivated += OnSecretLevelActivated;
    }

    private void OnDisable()
    {
        SecretLevelButtonPressed.SecretLevelActivated -= OnSecretLevelActivated;
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

    private void OnSecretLevelActivated()
    {
        LevelFun.Load();
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

    private void SetLevelsProgress(string levelName, Image zeroStars, Image OneStar,
        Image twoStars, Image threeStars, Image nextLevelLocked)
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
                        nextLevelLocked.gameObject.SetActive(true);
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
            }
        }
        else
        {
            return;
        }
    }
}
