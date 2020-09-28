using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class EnemyPooler : MonoBehaviour
{
    
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;        

    }

    /*Singleton*/
    public static EnemyPooler instance;
    public GameObject[] spawnPoints;
    private int randomSpawnPoint;
    private Vector3 pos;

    private void Awake()
    {
        instance = this;
    }

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public List<Pool> pools;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool (string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag: " + tag + " doesn't exist.");
            return null;
        }

        GameObject objToSpawn = poolDictionary[tag].Dequeue();

        objToSpawn.SetActive(true);

        randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        pos = new Vector3(spawnPoints[randomSpawnPoint].transform.position.x, spawnPoints[randomSpawnPoint].transform.position.y, 10);

        objToSpawn.transform.position = pos;

        poolDictionary[tag].Enqueue(objToSpawn);
        return objToSpawn;
    }

    public int getSize()
    {
        return pools[0].size;
    }

    public void deleteSpawnPoint(GameObject sp)
    {
        Debug.Log("HAI");
        spawnPoints = spawnPoints.Where(val => val != sp).ToArray();
    }

}
