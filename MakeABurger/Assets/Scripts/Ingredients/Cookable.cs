using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class Cookable : MonoBehaviour
{
    [SerializeField] float cookingTime;
    [SerializeField] Material cookedMaterial;
    MeshRenderer meshRenderer;

    [SerializeField] protected Transform griddleTransform;
    EventInstance sizzleEventInstance;

    [SerializeField] protected bool isCooking = false;
    [SerializeField] protected bool isCooked = false;

    // Start is called before the first frame update
    void Start()
    {
       if (meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        isCooking = false;
        isCooked = false;
    }

    protected IEnumerator StartCooking()
    {
        yield return new WaitForSeconds(cookingTime);

        meshRenderer.material = cookedMaterial;

        StopCookingAudio();
    }

    protected void StopCooking(bool isInterrupted = false)
    {
        if (isCooking == true)
        {
            StopCoroutine("StartCooking");
            isCooking = false;

            StopCookingAudio(isInterrupted);
        }
    }

    protected void PlayCookingAudio()
    {
        if (isCooked == false)
        {
            sizzleEventInstance = AudioManager.Instance.CreateEventInstance(FModEvents.Instance.cookingSizzleSFX, griddleTransform);

            sizzleEventInstance.start();
        }
    }

    protected void StopCookingAudio(bool isInterrupted = false)
    {
        sizzleEventInstance.stop(STOP_MODE.ALLOWFADEOUT);

        if (isInterrupted == false)
        {
            isCooked = true;

            AudioManager.Instance.PlayOneShot(FModEvents.Instance.coookedSFX, griddleTransform.position);
        }
    }

    public bool IsCooked { get { return isCooked; } }
}
