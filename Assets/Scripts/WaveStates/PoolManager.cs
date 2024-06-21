using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance;
        [SerializeField] private GameObject enemyPrefab;
         [SerializeField] private GameObject finalEnemy;

        private List <GameObject> enemyPool;
        public int enemyAmount;

   
    public static PoolManager Instance
    {
        get 
        {
            if (instance == null) 
            Debug.LogError("PoolManager is NULL!");

            return instance;
        }
    }
   private void Awake() 
   {
     instance = this;
     InstanceEnemies(enemyAmount);
   }
    public void InstanceEnemies(int enemyAmount)
    {
        enemyPool = new List<GameObject>();
            for (int i = 0; i <enemyAmount; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, new Vector3(10,0,0), Quaternion.identity);
                enemy.SetActive(false);
                enemyPool.Add(enemy);
            }
            
    }
    public GameObject RequestEnemy()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy) 
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        return null;
    }
    public void GimmeMyBoss()
    {
        Instantiate(finalEnemy, new Vector3(10,0,0), Quaternion.identity);
    }
}
