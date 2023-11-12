using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patty : MonoBehaviour, ICookable
{
    [SerializeField] float cookingTime;

    [SerializeField] Material cookedMaterial;

    bool isCooking;

    // Start is called before the first frame update
    void Start()
    {
        isCooking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartCooking()
    {
        yield return new WaitForSeconds(cookingTime);

        GetComponent<MeshRenderer>().material = cookedMaterial;

        isCooking = true;
    }

    public void StopCooking()
    {
        if (isCooking == true)
        {
            StopCoroutine("StartCooking");
            isCooking = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Griddle")
        {
            StartCoroutine("StartCooking");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Griddle")
        {
            StopCooking();
        }
    }
}
