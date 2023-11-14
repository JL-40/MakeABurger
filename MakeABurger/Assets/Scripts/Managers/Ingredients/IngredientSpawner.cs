using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] int ingredientCount = 0;

    [Range(1, 10)]
    [SerializeField] int maxIngredientToSpawn = 1;

    [SerializeField] GameObject ingredientToSpawn;

    // Update is called once per frame
    void Update()
    {
        if (ingredientToSpawn == null)
        {
            return;
        }

        if (ingredientCount != maxIngredientToSpawn)
        {
            GameObject newIngredient = Instantiate(ingredientToSpawn);
            newIngredient.transform.position = gameObject.transform.position;

            ingredientCount += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains(ingredientToSpawn.name) && other.CompareTag(ingredientToSpawn.tag))
        {
            ingredientCount -= 1;

            if (ingredientCount < 0)
            {
                ingredientCount += 1;
            } 
        }
    }

    public int Count { get { return ingredientCount; } }
}
