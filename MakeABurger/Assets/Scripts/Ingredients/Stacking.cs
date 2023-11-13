using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    [SerializeField] bool isStackable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ingredient") && collision.collider.GetComponent<Stacking>().IsStackable == true)
        {
            if (isStackable == true)
            {
                gameObject.transform.parent = collision.collider.transform;
            }
        }
    }

    public bool IsStackable { get { return this; } set { isStackable = value; } }
}
