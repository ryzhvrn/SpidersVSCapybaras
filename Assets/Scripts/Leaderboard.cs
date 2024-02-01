using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private const string AnonymousName = "Anonymous";
    private const string LeaderboardName = "Leaderboard";
    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new();

    [SerializeField] private LeaderboardView _leaderboardView;

    public void SetPlayer(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            return;
        }

        Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderboardName, onSuccessCallback =>
        {
            Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, score);
        });
    }

    private void Fill()
    {
        _leaderboardPlayers.Clear();

        if (PlayerAccount.IsAuthorized == false)
        {
            return;
        }

        Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName,  result  =>
        {
            foreach (var entry in result.entries)
            {
                var rank= entry.rank;
                var score = entry.score;
                var name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                {
                    name = AnonymousName;
                }

                _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));
            }
            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        });
    }

    private void OpenLeaderBoard()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
        }

        if (PlayerAccount.IsAuthorized == false)
        {
            return;
        }
    }
}
