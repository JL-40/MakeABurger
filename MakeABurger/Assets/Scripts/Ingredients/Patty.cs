using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Stacking))]
public class Patty : Cookable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cooking") && isCooked == false)
        {
            griddleTransform = other.gameObject.transform;

            StartCoroutine("StartCooking");
            isCooking = true;
            PlayCookingAudio();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cooking"))
        {
            StopCooking(true);
        }
    }
}
