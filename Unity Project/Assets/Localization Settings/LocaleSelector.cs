using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.HasKey("LocaleKey"))
        {
            int ID = PlayerPrefs.GetInt("LocaleKey", 0);
            ChangeLocale(ID);
        }
    }

    private bool active = false;

    public void ChangeLocale(int localeID)
    {
        if (active == true)
            return;
        StartCoroutine(SetLocale(localeID));
    }


    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;

        // Save the selected locale ID
        PlayerPrefs.SetInt("LocaleKey", _localeID);
        PlayerPrefs.Save(); // Make sure to save PlayerPrefs changes
    }
}
