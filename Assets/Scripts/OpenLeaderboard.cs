using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class OpenLeaderboard : MonoBehaviour
{
    [SerializeField] private GameObject _authView;

    private void OnEnable()
    {
        AcceptButton.AcceptButtonPressed += OnAccessButtonClicked;
        DeclineButton.DeclineButtonPressed += OnDeclineButtonClicked;
    }

    private void OnDisable()
    {
        AcceptButton.AcceptButtonPressed -= OnAccessButtonClicked;
        DeclineButton.DeclineButtonPressed -= OnDeclineButtonClicked;
    }

    public void LeaderboardButtonPressed()
    {
        string currentLanguage = YandexGamesSdk.Environment.i18n.lang;
        Debug.Log("currentLanguageCode: " + currentLanguage);
        TryOpenLeaderboard();
    }

    private void TryOpenLeaderboard()
    {
        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            Debug.Log("ѕытаемс€ открыть лидерборд!");
            IJunior.TypedScenes.Leaderboard.Load();
        }

        if (PlayerAccount.IsAuthorized == false)
        {
            _authView.SetActive(true);
        }
    }

    private void OnAccessButtonClicked()
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize();
            PlayerAccount.RequestPersonalProfileDataPermission();
            _authView.SetActive(false);
            Debug.Log("ќстаемс€ на сцене и ждем авторизации игрока!");
        }

        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            Debug.Log("ѕытаемс€ открыть лидерборд!");
            IJunior.TypedScenes.Leaderboard.Load();
        }
    }

    private void OnDeclineButtonClicked()
    {
        _authView.SetActive(false);
    }
}
