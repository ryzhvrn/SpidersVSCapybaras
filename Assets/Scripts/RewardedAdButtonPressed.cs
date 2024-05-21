using UnityEngine;
using UnityEngine.UI;

public class RewardedAdButtonPressed : MonoBehaviour
{
    [SerializeField] private Image _dress;
    [SerializeField] private Image _top;
    [SerializeField] private Image _pants;
    [SerializeField] private Button _adButton;
    private AdService _ads = new AdService();
    private int _adViewedCount;
    private const string _keyAdViewedCount = "adViewedCount";

    private void Start()
    {
        if (PlayerPrefs.HasKey(_keyAdViewedCount) == false)
        {
            PlayerPrefs.SetInt(_keyAdViewedCount, 0);
        }

        _adViewedCount = PlayerPrefs.GetInt(_keyAdViewedCount);
        int currentAdViewedCount = PlayerPrefs.GetInt(_keyAdViewedCount);
        ShowFunCapybaraView(currentAdViewedCount);
    }

    private void OnEnable()
    {
        AdService.CollectingVideoAdReward += OnCollectVideoAdReward;
    }

    private void OnDisable()
    {
        AdService.CollectingVideoAdReward -= OnCollectVideoAdReward;
    }

    private void OnCollectVideoAdReward()
    {
        _adViewedCount++;
        PlayerPrefs.SetInt(_keyAdViewedCount, _adViewedCount);
        ShowFunCapybaraView(_adViewedCount);
        PlayerPrefs.Save();
    }

    private void ShowFunCapybaraView(int count)
    {
        switch (count)
        {
            case 0:
                _adButton.gameObject.SetActive(true);
                _dress.gameObject.SetActive(true);
                _top.gameObject.SetActive(true);
                _pants.gameObject.SetActive(true);
                break;
            case 1:
                _adButton.gameObject.SetActive(true);
                _dress.gameObject.SetActive(false);
                _top.gameObject.SetActive(true);
                _pants.gameObject.SetActive(true);
                break;
            case 2:
                _adButton.gameObject.SetActive(false);
                _dress.gameObject.SetActive(false);
                _top.gameObject.SetActive(false);
                _pants.gameObject.SetActive(false);
                break;
        }
    }

    public void OnRewardAdButtonPressed()
    {
        _ads.ShowVideoAd();
    }
}
