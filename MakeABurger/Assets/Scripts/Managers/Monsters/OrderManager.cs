using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;

    [SerializeField] Transform orderAtTriggerTransform;

    [SerializeField] List<GameObject> possibleOrderList;

    [SerializeField] GameObject currentOrder;
 
    private void Awake()
    {
        #region SINGLETON
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        #endregion  
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetOrder(MONSTER_TYPE monsterType)
    {
        if (possibleOrderList.Count > 0)
        {
            Debug.Log("Ordering");
        }

        PlayerOrderSound(monsterType);
    }

    public bool CheckOrder(GameObject orderMade)
    {
        if (orderMade == currentOrder)
        {
            return true;
        }

        return false;
    }

    void PlayerOrderSound(MONSTER_TYPE monsterType)
    {
        EventReference monsterOrderSound;

        switch (monsterType)
        {
            case MONSTER_TYPE.LIZARD:
                {
                    monsterOrderSound = FModEvents.Instance.lizardOrder;
                    break;
                }
            case MONSTER_TYPE.PINK_BLOB:
                {
                    monsterOrderSound = FModEvents.Instance.pinkBlobOrder;
                    break;
                }
            case MONSTER_TYPE.PURPLE_BLOB:
                {
                    monsterOrderSound = FModEvents.Instance.purpleBlobOrder;
                    break;
                }
            case MONSTER_TYPE.SQUID:
                {
                    monsterOrderSound = FModEvents.Instance.squidOrder;
                    break;
                }
            default:
                {
                    monsterOrderSound = new EventReference();
                    break;
                }
        }

        if (monsterOrderSound.Equals(new EventReference()) == false)
        {
            AudioManager.Instance.PlayOneShot(monsterOrderSound, orderAtTriggerTransform.position);
        }

    }
}
