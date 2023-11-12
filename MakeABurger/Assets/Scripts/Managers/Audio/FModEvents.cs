using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

// FModEvents Script given by Shaped by Rain Studios. Link to Youtube video: https://www.youtube.com/watch?v=rcBHIOjZDpk
public class FModEvents : MonoBehaviour
{
    #region SOUND_EVENT_REFERENCE
    [field: Header("Cooking Sizzle SFX")]
    [field: SerializeField] public EventReference cookingSizzleSFX { get; private set; }

    [field: Header("Cooking Done SFX")]
    [field: SerializeField] public EventReference coookedSFX { get; private set; }

    [field: Header("Order In SFX")]
    [field: SerializeField] public EventReference orderSFX { get; private set; }

    [field: Header("Pickup SFX")]
    [field: SerializeField] public EventReference pickupItem { get; private set; }

    [field: Header("Drop SFX")]
    [field: SerializeField] public EventReference drop { get; private set; }

    [field: Header("Footstep SFX")]
    [field: SerializeField] public EventReference footsteps { get; private set; }

    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }

    [field: Header("UI SFX")]
    [field: SerializeField] public EventReference UI_SFX { get; private set; }
    #endregion

    public static FModEvents Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one FMod Events Instance in the Scene");
        }

        Instance = this;
    }

}
