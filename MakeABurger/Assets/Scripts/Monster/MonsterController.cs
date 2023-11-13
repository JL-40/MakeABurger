using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MONSTER_TYPE
{
    LIZARD,
    PINK_BLOB,
    PURPLE_BLOB,
    SQUID
}
public class MonsterController : MonoBehaviour
{
    [SerializeField] MONSTER_TYPE monster_type;

    [SerializeField] Transform orderHereTransform;
    bool hasOrdered = false;


    // Start is called before the first frame update
    void Start()
    {
        if (orderHereTransform == null)
        {
            orderHereTransform = GameObject.FindGameObjectWithTag("OrderHere").transform;
        }

        hasOrdered = false;
    }

    // Update is called once per frame
    void Update()
    {
        AlwaysFacePlayer();

        if (transform.position != orderHereTransform.position)
        {
            MoveToOrder();
        }
    }

    void MoveToOrder()
    {
        transform.position = Vector3.MoveTowards(transform.position, orderHereTransform.position, 0.01f);
    }

    void AlwaysFacePlayer()
    {
        transform.LookAt(GameManager.Instance.PlayerTransform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OrderHere"))
        {
            OrderManager.Instance.GetOrder(MonsterType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OrderHere"))
        {
            hasOrdered = true;
        }
    }

    public MONSTER_TYPE MonsterType { get { return monster_type; } }
}
