using Agava.YandexGames;
using UnityEngine;

public class OpenLeaderboard : MonoBehaviour
{
    [SerializeField] private GameObject _authView;
    [SerializeField] private Accept _acceptButton;
    [SerializeField] private Decline _declineButton;

    private void OnEnable()
    {
        _acceptButton.AcceptButtonPressed += OnAcceptButtonClicked;
        _declineButton.DeclineButtonPressed += OnDeclineButtonClicked;
    }

    private void OnDisable()
    {
        _acceptButton.AcceptButtonPressed -= OnAcceptButtonClicked;
        _declineButton.DeclineButtonPressed -= OnDeclineButtonClicked;
    }
    
    private void TryOpenLeaderboard()
    {
        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            IJunior.TypedScenes.Leaderboard.Load();
        }

        if (PlayerAccount.IsAuthorized == false)
        {
            _authView.SetActive(true);
        }
    }

    private void OnAcceptButtonClicked()
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize();
            PlayerAccount.RequestPersonalProfileDataPermission();
            _authView.SetActive(false);
        }

        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            IJunior.TypedScenes.Leaderboard.Load();
        }
    }

    private void OnDeclineButtonClicked()
    {
        _authView.SetActive(false);
    }
    
    public void LeaderboardButtonPressed()
    {
        TryOpenLeaderboard();
    }
}
