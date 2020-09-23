using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Awake()
    {
        instance = this;    
    }

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public List<Pool> pools;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
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

    public GameObject SpawnFromPool (string tag, Vector2 positon)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag: " + tag + " doesn't exist.");
            return null;
        }

        GameObject objToSpawn = poolDictionary[tag].Dequeue();

        objToSpawn.SetActive(true);
        objToSpawn.transform.position = positon;

        IPooledObj pooledObj = objToSpawn.GetComponent<IPooledObj>();

        if(pooledObj != null)
        {
            pooledObj.OnObjSpawned();
        }

        poolDictionary[tag].Enqueue(objToSpawn);
        return objToSpawn;
    }
}
