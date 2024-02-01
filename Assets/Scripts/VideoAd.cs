using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoAd : MonoBehaviour
{
    public void ShowAd() => Agava.YandexGames.VideoAd.Show(OnOpenAdCallback, OnCloseAdCallback);

    private void OnOpenAdCallback()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    private void OnCloseAdCallback()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }
}
