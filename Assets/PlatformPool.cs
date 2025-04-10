using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    public GameObject platformPrefab;
    public int poolSize = 10;

    private Queue<GameObject> platformPool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(platformPrefab);
            obj.SetActive(false);
            platformPool.Enqueue(obj);
        }
    }

    public GameObject GetPlatform()
    {
        GameObject obj = platformPool.Dequeue();
        obj.SetActive(true);
        platformPool.Enqueue(obj);
        return obj;
    }
}
