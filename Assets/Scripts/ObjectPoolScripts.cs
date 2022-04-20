using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolScripts : MonoBehaviour
{
    public static ObjectPoolScripts Instance;
    public List<GameObject> pool = new List<GameObject>();
    public List<PoolObject> poolItems = new List<PoolObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        return;
    }
    // Start is called before the first frame update
    void Start()
    {
        AddToPool();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddToPool()
    {
        foreach (PoolObject item in poolItems)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject temp = Instantiate(item.objectsPrefabs);
                temp.SetActive(false);
                pool.Add(temp);
            }
        }
    }

    public GameObject GetObjectsFromPool(string tagName)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].gameObject.tag == tagName)
            {
                if (!pool[i].activeInHierarchy)
                {
                    return pool[i];
                }

            }
        }

        return null;
    }

    public void BackToPool(GameObject gameObjectPrefabs)
    {
        pool.Add(gameObjectPrefabs);
        gameObjectPrefabs.SetActive(false);
    }
}
[System.Serializable]
public class PoolObject
{
    public GameObject objectsPrefabs;
    public int amount;
}
