using Agava.YandexGames;
using UnityEngine;

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
        TryOpenLeaderboard();
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

    private void OnAccessButtonClicked()
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
}
