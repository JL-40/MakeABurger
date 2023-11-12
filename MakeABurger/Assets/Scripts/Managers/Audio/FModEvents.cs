using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FModEvents : MonoBehaviour
{
    [field: Header("Cooking SFX")]
    [SerializeField] public EventReference cookingSFX { get; private set; }

    [field: Header("Pickup SFX")]
    [SerializeField] public EventReference pickupItem { get; private set; }

    [field: Header("Drop SFX")]
    [SerializeField] public EventReference drop { get; private set; }

    [field: Header("Walking Footstep SFX")]
    [SerializeField] public EventReference walkingFootsteps { get; private set; }

    [field: Header("Ambience SFX")]
    [SerializeField] public EventReference ambience { get; private set; }

    [field: Header("Music")]
    [SerializeField] public EventReference music { get; private set; }

    public static FModEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one FMod Events instance in the Scene");
        }

        instance = this;
    }

}
