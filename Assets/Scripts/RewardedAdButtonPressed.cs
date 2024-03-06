using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardedAdButtonPressed : MonoBehaviour
{
    [SerializeField] private Image _dress;
    [SerializeField] private Image _top;
    [SerializeField] private Image _pants;
    [SerializeField] private Button _adButton;
    private AdService _ads = new AdService();
    private int _adViewedCount = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("adViewedCount") == false)
        {
            PlayerPrefs.SetInt("adViewedCount", 0);
        }

        int currentAdViewedCount = PlayerPrefs.GetInt("adViewedCount");
        ShowFunCapybaraView(currentAdViewedCount);
    }

    private void OnEnable()
    {
        AdService.CollectVideoAdReward += OnCollectVideoAdReward;
    }

    private void OnDisable()
    {
        AdService.CollectVideoAdReward -= OnCollectVideoAdReward;
    }

    private void OnCollectVideoAdReward()
    {
        _adViewedCount++;
        PlayerPrefs.SetInt("adViewedCount", _adViewedCount);
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
