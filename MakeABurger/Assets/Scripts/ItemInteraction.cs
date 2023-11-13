using UnityEngine;
using UnityEngine.InputSystem;

public class ItemInteraction : MonoBehaviour
{
    private bool isBeingCarried = false;
    private Transform originalParent;

    private void Start()
    {
        originalParent = transform.parent;
    }

    private void Update()
    {
        if (isBeingCarried)
        {
            if (InputManager.Instance.IsFiring())
            {
                Drop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isBeingCarried)
            {
                if (InputManager.Instance.IsFiring())
                {
                    PickUp(other.transform);
                }
            }
        }
    }

    private void PickUp(Transform newParent)
    {
        isBeingCarried = true;
        transform.SetParent(newParent);
        transform.localPosition = Vector3.zero; 
        GetComponent<Rigidbody>().isKinematic = true; 
    }

    private void Drop()
    {
        isBeingCarried = false;
        transform.SetParent(originalParent);
        GetComponent<Rigidbody>().isKinematic = false; 
    }
}
