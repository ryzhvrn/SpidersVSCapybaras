using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
//using Lean.Localization;

public class Localization : MonoBehaviour
{
    private const string EnglishCode = "English";
    private const string RussianCode = "Russian";
    private const string TurkishCode = "Turkish";
    private const string Turkish = "tr";
    private const string Russian = "ru";
    private const string English = "en";

    //[SerializeField] private LeanLocalization _leanLanguage;

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
ChangeLanguage();
#endif
    }

    private void ChangeLanguage()
    {
        string languageCode = YandexGamesSdk.Environment.i18n.lang;

        switch (languageCode)
        {
            case English:
                //_leanLanguage.SetCurrentLenguage(EnglishCode);
                break;
            case Turkish:
                //_leanLanguage.SetCurrentLenguage(TurkishCode);
                break;
            case Russian:
               // _leanLanguage.SetCurrentLenguage(RussianCode);
                break;
        }
    }
}
