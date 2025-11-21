using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    public Transform enemySpawner;
    public Transform playerSpawner;

    public GameObject losePanel;

    public List<EntitySO> enemyDataList;
    public EntitySO enemyData;


    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        losePanel.SetActive(false);
        spawnEnemy();
    }


    public void spawnEnemy()
    {
        RandomizeEnemy();
        GameObject newEnemy = Instantiate(enemyData.entityPrefab, enemySpawner);
        EnemyScript enemyScript = newEnemy.GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            enemyScript.enemyData = enemyData;
        }
    }

    public void RandomizeEnemy()
    {
        int randomIndex = Random.Range(0, enemyDataList.Count);
        enemyData = enemyDataList[randomIndex];
    }






    public void loseManager()
    {
        losePanel.SetActive(true);
        LoseScript.instance.loseUpdate();
    }

}
