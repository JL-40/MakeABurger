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

    #region Order SFX
    [field: Header("Order In SFX")]
    [field: SerializeField] public EventReference orderInSFX { get; private set; }

    [field: Header("Order Done SFX")]
    [field: SerializeField] public EventReference orderDoneSFX { get; private set; }
    #endregion

    #region Voice
    #region Lizard Voice
    [field: Header("Lizard Order SFX")]
    [field: SerializeField] public EventReference lizardOrder { get; private set; }

    [field: Header("Lizard Happy SFX")]
    [field: SerializeField] public EventReference lizardHappy { get; private set; }

    [field: Header("Lizard Sad SFX")]
    [field: SerializeField] public EventReference lizardSad { get; private set; }
    #endregion

    #region PinkBlob Voice
    [field: Header("Pink Blob Order SFX")]
    [field: SerializeField] public EventReference pinkBlobOrder { get; private set; }

    [field: Header("Pink Blob Happy SFX")]
    [field: SerializeField] public EventReference pinkBlobHappy { get; private set; }

    [field: Header("Pink Blob Sad SFX")]
    [field: SerializeField] public EventReference pinkBlobSad { get; private set; }
    #endregion

    #region PurpleBlob Voice
    [field: Header("Purple Blob Order SFX")]
    [field: SerializeField] public EventReference purpleBlobOrder { get; private set; }

    [field: Header("Purple Blob Happy SFX")]
    [field: SerializeField] public EventReference purpleBlobHappy { get; private set; }

    [field: Header("Purple Blob Sad SFX")]
    [field: SerializeField] public EventReference purpleBlobSad { get; private set; }
    #endregion

    #region Squid Voice
    [field: Header("Squid Order SFX")]
    [field: SerializeField] public EventReference squidOrder { get; private set; }

    [field: Header("Squid Happy SFX")]
    [field: SerializeField] public EventReference squidHappy { get; private set; }

    [field: Header("Squid Sad SFX")]
    [field: SerializeField] public EventReference squidSad { get; private set; }
    #endregion

    #endregion

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
