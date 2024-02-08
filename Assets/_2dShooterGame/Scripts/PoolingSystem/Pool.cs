using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [HideInInspector]
    public GameObject prefab { get; set; }

    [SerializeField]
    private int defaultCapacity = 10;

    [SerializeField]
    private int maxCapacity = 1000;

    private static Dictionary<string, Pool> pools = new Dictionary<string, Pool>();

    private ObjectPool<GameObject> objectPool;

    private static GameObject parentGameObject;

    private void Awake()
    {
        objectPool = new ObjectPool<GameObject>(CreateNewGameObject,
                                     OnGetFromPool,
                                     OnReturnedToPool,
                                     OnDestroyFromPool, false, defaultCapacity, maxCapacity);

        if(parentGameObject == null)
            parentGameObject = new GameObject("PooledObjects");
    }

    public void OnGameOver()
    {
        objectPool.Clear();

        if(pools.Count > 0)
            pools.Clear();
    }

    public static Pool GetPool(GameObject prefab)
    {
        if (pools.ContainsKey(prefab.name))
        {
            return pools[prefab.name];
        }

        var poolObject = new GameObject(prefab.name + "_Poll");
        var pool = poolObject.AddComponent<Pool>();
        pool.prefab = prefab;

        pools.Add(prefab.name, pool);

        return pool;
    }

    public GameObject Get()
    {
        var obj = objectPool.Get();
        obj.transform.SetParent(parentGameObject.transform);

        obj.GetComponent<IPoolableObject>().SetPool(objectPool);

        return obj;
    }

    public GameObject Get(Transform transform)
    {
        var obj = Get();
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;

        return obj;
    }

    protected virtual GameObject CreateNewGameObject()
    {
        var obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        return obj;
    }

    protected virtual void OnReturnedToPool(GameObject obj) => obj.SetActive(false);

    protected virtual void OnGetFromPool(GameObject obj) => obj.SetActive(true);

    protected virtual void OnDestroyFromPool(GameObject obj) => Destroy(obj);
}