using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawnerManager : MonoBehaviour
{
    public static IngredientSpawnerManager Instance;

    [SerializeField] Transform pattySpawner;
    [SerializeField] Transform lettuceSpawner;
    [SerializeField] Transform cheeseSpawner;
    [SerializeField] Transform bunSpawner;

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
        if (pattySpawner == null)
        {
            pattySpawner = GameObject.Find("PattySpawner").transform;
        }

        if (lettuceSpawner == null)
        {
            lettuceSpawner = GameObject.Find("LettuceSpawner").transform;
        }

        if (cheeseSpawner == null)
        {
            cheeseSpawner = GameObject.Find("CheeseSpawner").transform;
        }

        if (bunSpawner == null)
        {
           bunSpawner = GameObject.Find("BunSpawner").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Getter and Setter
    public Transform PattySpawner { get { return pattySpawner; } }
    public Transform LettuceSpawner { get { return lettuceSpawner; } }
    public Transform CheeseSpawner { get { return cheeseSpawner; } }
    public Transform BunSpawner { get { return bunSpawner; } }
    #endregion
}
