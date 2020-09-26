using System.Collections;
using System.Collections.Generic;
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
    public GameObject quad;
    private float screenX, screenY;
    private Vector2 pos;
    private MeshCollider c;

    private void Awake()
    {
        instance = this;
        c = quad.GetComponent<MeshCollider>();
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

                screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
                screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);

                pos = new Vector2(screenX, screenY);
                
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

        screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
        screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
        pos = new Vector2(screenX, screenY);

        objToSpawn.transform.position = pos;

        poolDictionary[tag].Enqueue(objToSpawn);
        return objToSpawn;
    }

    public int getSize()
    {
        return pools[0].size;
    }


}
