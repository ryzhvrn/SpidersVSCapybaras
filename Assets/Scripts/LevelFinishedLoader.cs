using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;

public class LevelFinishedLoader : MonoBehaviour, ISceneLoadHandler<LevelConfig>
{
    [SerializeField] private Image ThreeStarsEarned;
    [SerializeField] private Image TwoStarsEarned;
    [SerializeField] private Image OneStarsEarned;
    [SerializeField] private Text ZeroStarsEarnedWarning;
    [SerializeField] private Text _levelFinishedText;

    public void OnSceneLoaded(LevelConfig argument)
    {
        Debug.Log(argument.StarsEarned);
        int starsEarnedAmount = argument.StarsEarned;
        string levelName = "level";

        if (argument.CurrentLevelName == "Level1")
        {
            levelName = "Первый уровень";
        }
        else if (argument.CurrentLevelName == "Level2")
        {
            levelName = "Второй уровень";
        }
        else if (argument.CurrentLevelName == "Level3")
        {
            levelName = "Третий уровень";
        }

        _levelFinishedText.text = "Поздравляю!\r\n" + levelName + " пройден!";

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
