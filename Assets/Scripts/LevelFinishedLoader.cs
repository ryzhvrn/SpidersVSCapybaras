using System;
using IJunior.TypedScenes;
using UnityEngine.UI;
using UnityEngine;

public class LevelFinishedLoader : MonoBehaviour, ISceneLoadHandler<LevelConfig>
{
    [SerializeField] private Image[] _starsEarnedImages;
    /*[SerializeField] private Image ThreeStarsEarned;
    [SerializeField] private Image TwoStarsEarned;
    [SerializeField] private Image OneStarsEarned;*/
    [SerializeField] private Text _zeroStarsEarnedWarning;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _levelsMenuButton;
    private AdService _ads = new AdService();

    public static event Action SetPlayerScore;

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        _restartButton.gameObject.SetActive(false);
        _levelsMenuButton.gameObject.SetActive(false);
        Invoke("ShowInterstitialAd", 2f);
#endif
    }

    private void OnEnable()
    {
        AdService.ShowingInteractiveElements += OnShowInteractiveElements;
    }

    private void OnDisable()
    {
        AdService.ShowingInteractiveElements -= OnShowInteractiveElements;
    }

    public void OnSceneLoaded(LevelConfig argument)
    {
        int starsEarnedAmount = argument.StarsEarned;
        SetCurrentLevelResult(starsEarnedAmount);
        SetPlayerScore?.Invoke();
    }

    private void ShowInterstitialAd()
    {
        _ads.ShowInterstitialAd();
    }

    private void OnShowInteractiveElements()
    {
        _restartButton.gameObject.SetActive(true);
        _levelsMenuButton.gameObject.SetActive(true);
    }

    /*private void SetCurrentLevelResult(int starsEarnedAmount)
    {
        if (starsEarnedAmount == 3)
        {
            OneStarsEarned.gameObject.SetActive(true);
            TwoStarsEarned.gameObject.SetActive(true);
            ThreeStarsEarned.gameObject.SetActive(true);
        }
        else if (starsEarnedAmount == 2)
        {
            OneStarsEarned.gameObject.SetActive(true);
            TwoStarsEarned.gameObject.SetActive(true);
        }
        else if (starsEarnedAmount == 1)
        {
            OneStarsEarned.gameObject.SetActive(true);
        }
        else if (starsEarnedAmount == 0)
        {
            ZeroStarsEarnedWarning.gameObject.SetActive(true);
        }
    }*/

    private void SetCurrentLevelResult(int starsEarnedAmount)
    {
        for (int i = 0; i < _starsEarnedImages.Length; i++)
        {
            _starsEarnedImages[i].gameObject.SetActive(i < starsEarnedAmount);
        }

        _zeroStarsEarnedWarning.gameObject.SetActive(starsEarnedAmount == 0);
    }
}
