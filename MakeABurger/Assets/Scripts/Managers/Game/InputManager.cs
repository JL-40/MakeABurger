using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credits to samyam's Youtube video: Cinemachine First Person Controller w/ Input System - Unity Tutorial - https://www.youtube.com/watch?v=5n_hmqHdijM
public class InputManager : MonoBehaviour
{
    static InputManager _Instance;
    public static InputManager Instance { get { return _Instance; } }

    PlayerInputActions playerInputActions;

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _Instance = this;
        }

        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
        SwitchToPlayerMap();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    public void SwitchToUIMap()
    {
        playerInputActions.Player.Disable();
        playerInputActions.UI.Enable();
    }

    public void SwitchToPlayerMap()
    {
        playerInputActions.UI.Disable();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementValue()
    {
        return playerInputActions.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetLookValue()
    {
        return playerInputActions.Player.Look.ReadValue<Vector2>();
    }

    public bool IsPaused()
    {
        return playerInputActions.Player.Pause.triggered;
    }

    public bool IsResumed()
    {
        return playerInputActions.UI.Resume.triggered;
    }

    public bool IsFiring()
    {
        return playerInputActions.Player.Fire.triggered;
    }
}
