using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    [SerializeField] List<Rigidbody> connectedBodies = new List<Rigidbody>();

    FixedJoint fixedJoint;

    // Start is called before the first frame update
    void Start()
    {
        connectedBodies.Clear();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<Cookable>().IsCooked == false)
        {
            return;
        }

        Collider collider = collision.collider;
        if (collider.CompareTag("Ingredient"))
        {
            if (collider.GetComponent<Cookable>().IsCooked == false)
            {
                return;
            }

            Rigidbody otherBody = collision.rigidbody;

            if (connectedBodies.Contains(otherBody) == false)
            {
                fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.connectedBody = collision.rigidbody;

                connectedBodies.Add(otherBody);
            }

        }
    }
}
