using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeYandexGamesMetrics : MonoBehaviour
{
    private void Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        YandexGamesSdk.GameReady();
#endif
    }
}
