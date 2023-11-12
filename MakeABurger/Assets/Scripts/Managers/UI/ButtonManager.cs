using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;

    [SerializeField] Sprite resumeButtonSprite;
    [SerializeField] Button playButton;

    private void Awake()
    {
        #region SINGLETON
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        #endregion
    }

    public void PlayGame()
    {
        GameManager.Instance.PlayGame();
    }

    public void SwitchToSettings()
    {
        MenuSwitcher.Instance.SwitchMenu(GameManager.Instance.settingMenu, GameManager.Instance.mainMenu);
    }

    public void SwitchToMain()
    {
        MenuSwitcher.Instance.SwitchMenu(GameManager.Instance.mainMenu, GameManager.Instance.settingMenu);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR

        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ChangePlayToResume()
    {
        playButton.GetComponent<Image>().sprite = resumeButtonSprite;
    }
}
