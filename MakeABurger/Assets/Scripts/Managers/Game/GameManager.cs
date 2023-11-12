using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject settingMenu;
    public GameObject mainMenu;

    public GameObject menuUI;

    public bool IsGamePaused { get; private set; }

    public bool gameStarted { get; private set; }

    private void Awake()
    {
        #region SINGLETON
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        #endregion    
    }

    // Start is called before the first frame update
    void Start()
    {
        PauseGame();

        if (gameStarted != false)
        {
            gameStarted = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.IsPaused() == true && gameStarted == true)
        {
            PauseGame();
        }

        if (InputManager.Instance.IsResumed() == true && gameStarted == true)
        {
            PlayGame();
        }
    }

    public void PlayGame()
    {
        IsGamePaused = false;

        AudioManager.Instance.ResumeAllAudio();

        mainMenu.SetActive(true);
        settingMenu.SetActive(false);
        menuUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;

        if (gameStarted == false)
        {
            ButtonManager.Instance.ChangePlayToResume();

            gameStarted = true;
        }
    }

    public void PauseGame()
    {
        IsGamePaused = true;

        AudioManager.Instance.PauseAllAudio();

        menuUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    #region Getter/Setter

    #endregion
}
