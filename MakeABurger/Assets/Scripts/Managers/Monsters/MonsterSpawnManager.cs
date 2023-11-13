using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    public static MonsterSpawnManager Instance;

    [SerializeField] List<GameObject> monsterList;

    [SerializeField] int numberOfMonsters = 1;

    [SerializeField] Transform customerSpawner;

    int currentMonsterCount = 0;

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
        currentMonsterCount = 0;
    }

    public void SpawnMonster()
    {
        if (currentMonsterCount == 0 && numberOfMonsters > 0)
        {
            int randomMonsterFromList = Random.Range(0, monsterList.Count);

            GameObject newMonster = Instantiate(monsterList[randomMonsterFromList]);
            newMonster.transform.position = customerSpawner.position;

            currentMonsterCount = 1;

            AudioManager.Instance.PlayOneShot(FModEvents.Instance.orderInSFX, customerSpawner.position);

            ReduceDailyCustomerCount();
        }
    }

    public void ReduceDailyCustomerCount()
    {
        numberOfMonsters -= 1;
    }
}
