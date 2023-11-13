using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

[RequireComponent(typeof (Stacking))]
public class Patty : MonoBehaviour, ICookable
{
    [SerializeField] float cookingTime;

    [SerializeField] Material cookedMaterial;

    [SerializeField] Transform griddleTransform;

    MeshRenderer meshRenderer;
    EventInstance sizzleEventInstance;

    bool isCooking;
    bool isCooked;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        isCooking = false;
    }

    public IEnumerator StartCooking()
    {
        yield return new WaitForSeconds(cookingTime);

        meshRenderer.material = cookedMaterial;

        isCooked = true;

        GetComponent<Stacking>().IsStackable = isCooked;

        StopCookingAudio();
    }

    public void StopCooking(bool isInterrupted = false)
    {
        if (isCooking == true)
        {
            StopCoroutine("StartCooking");
            isCooking = false;

            StopCookingAudio(isInterrupted);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Griddle" && isCooked == false)
        {
            griddleTransform = other.gameObject.transform;

            StartCoroutine("StartCooking");
            isCooking = true;

            PlayCookingAudio();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Griddle")
        {
            StopCooking(true);
        }
    }

    void PlayCookingAudio()
    {
        if (isCooked == false)
        {
            sizzleEventInstance = AudioManager.Instance.CreateEventInstance(FModEvents.Instance.cookingSizzleSFX, griddleTransform);

            sizzleEventInstance.start();
        }
    }

    void StopCookingAudio(bool isInterrupted = false)
    {
        sizzleEventInstance.stop(STOP_MODE.ALLOWFADEOUT);

        if (isInterrupted == false)
        {
            AudioManager.Instance.PlayOneShot(FModEvents.Instance.coookedSFX, griddleTransform.position);
        }
    }
}
