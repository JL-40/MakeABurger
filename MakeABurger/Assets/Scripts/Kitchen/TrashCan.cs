using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrashCan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            Destroy(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            Destroy(other);
        }
    }
}
