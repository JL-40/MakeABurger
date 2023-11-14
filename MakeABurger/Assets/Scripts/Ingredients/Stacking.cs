using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    public bool isCookable;

    [SerializeField] List<Rigidbody> connectedBodies = new List<Rigidbody>();

    FixedJoint fixedJoint;

    // Start is called before the first frame update
    void Start()
    {
        connectedBodies.Clear();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if (isCookable == true)
        {
            if (GetComponent<Cookable>().IsCooked == false)
            {
                return;
            }

            if (collider.CompareTag("Ingredient"))
            {
                if (collider.GetComponent<Stacking>().Coockable == true)
                {
                    if (collider.GetComponent<Cookable>().IsCooked == false)
                    {
                        return;
                    }
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
        else
        {
            Rigidbody otherBody = collision.rigidbody;

            if (connectedBodies.Contains(otherBody) == false)
            {
                fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.connectedBody = collision.rigidbody;

                connectedBodies.Add(otherBody);
            }
        }
    }

    #region Getter
    public bool Coockable { get { return isCookable; } }

    public List<Rigidbody> Stack { get { return connectedBodies; } }
    #endregion
}
