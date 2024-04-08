using Agava.YandexGames;
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
