using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Credits to Rytech for the code. Link to source: https://www.youtube.com/watch?v=zgCV26yFAiU
public class PhysicsPickup : MonoBehaviour
{
    [SerializeField] LayerMask pickupMask;
    [SerializeField] Camera playerCamera;
    [SerializeField] Transform pickupTarget;

    [SerializeField] float pickupRange;
    [SerializeField] float flingSpeed;
    Rigidbody heldObject;

    // Start is called before the first frame update
    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.IsFiring())
        {
            if (heldObject)
            {
                heldObject.useGravity = true;
                heldObject = null;

                return;
            }

            Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(cameraRay, out RaycastHit HitInfo, pickupRange, pickupMask))
            {
                heldObject = HitInfo.rigidbody;
                heldObject.useGravity = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (heldObject)
        {
            Vector3 DirectionToPoint = pickupTarget.position - heldObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            heldObject.velocity = DirectionToPoint * (flingSpeed * DistanceToPoint);
        }
    }
}
