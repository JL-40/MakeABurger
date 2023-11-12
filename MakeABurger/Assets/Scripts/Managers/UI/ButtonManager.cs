using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ButtonManager : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
