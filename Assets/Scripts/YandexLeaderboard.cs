using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

public class YandexLeaderboard : MonoBehaviour
{
    [SerializeField] private LeaderboardView _leaderboardView;

    private const string EnglishAnonymousName = "Anonymous";
    private const string RussianAnonymousName = "Аноним";
    private const string TurkishAnonymousName = "Anonim";
    private const string LeaderboardName = "Leaderboard";
    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new ();

    public void SetPlayerScore(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            return;
        }

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result.score < score)
            {
                Leaderboard.SetScore(LeaderboardName, score);
            }
        });
    }

    public void Fill()
    {
        _leaderboardPlayers.Clear();

        if (PlayerAccount.IsAuthorized == false)
        {
            return;
        }

        Leaderboard.GetEntries(LeaderboardName, result =>
        {
            foreach (var entry in result.entries)
            {
                var rank = entry.rank;
                var score = entry.score;
                var name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                {
                    string currentLanguage = YandexGamesSdk.Environment.i18n.lang;

                    switch (currentLanguage)
                    {
                        case "Russian":
                            name = RussianAnonymousName;
                            break;

                        case "English":
                            name = EnglishAnonymousName;
                            break;

                        case "Turkish":
                            name = TurkishAnonymousName;
                            break;
                    }
                }

                _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));
            }

            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        });
    }
}
