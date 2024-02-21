using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;
using System;

public class LevelFinishedLoader : MonoBehaviour, ISceneLoadHandler<LevelConfig>
{
    [SerializeField] private Image ThreeStarsEarned;
    [SerializeField] private Image TwoStarsEarned;
    [SerializeField] private Image OneStarsEarned;
    [SerializeField] private Text ZeroStarsEarnedWarning;

    public static event Action SetPlayerScore;

    public void OnSceneLoaded(LevelConfig argument)
    {
        int starsEarnedAmount = argument.StarsEarned;
        SetCurrentLevelResul(starsEarnedAmount);
        SetPlayerScore?.Invoke();
    }

    private void SetCurrentLevelResul(int starsEarnedAmount)
    {
        if (starsEarnedAmount == 3)
        {
            OneStarsEarned.gameObject.SetActive(true);
            TwoStarsEarned.gameObject.SetActive(true);
            ThreeStarsEarned.gameObject.SetActive(true);
        }
        else if (starsEarnedAmount == 2)
        {
            OneStarsEarned.gameObject.SetActive(true);
            TwoStarsEarned.gameObject.SetActive(true);
        }
        else if (starsEarnedAmount == 1)
        {
            OneStarsEarned.gameObject.SetActive(true);
        }
        else if (starsEarnedAmount == 0)
        {
            ZeroStarsEarnedWarning.gameObject.SetActive(true);
        }
    }
}
