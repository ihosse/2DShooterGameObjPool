using UnityEngine;
using UnityEngine.Pool;

public class BasicPool : MonoBehaviour
{
    [SerializeField]
    protected GameObject prefab;

    public ObjectPool<GameObject> Pool { get; protected set; }

    public virtual void Initialize(int defaultCapacity, int maxSize)
    {
        Pool = new ObjectPool<GameObject>(CreateNewGameObject,
                                     OnGetFromPool,
                                     OnReturnedToPool,
                                     OnDestroyFromPool, false, defaultCapacity, maxSize);
    }

    protected virtual GameObject CreateNewGameObject()
    {
        var enemy = Instantiate(prefab, gameObject.transform);

        IObjectPoolable objectPoolable = enemy.GetComponent<IObjectPoolable>();
        objectPoolable?.SetPool(Pool);

        return enemy;
    }

    protected virtual void OnReturnedToPool(GameObject obj) => obj.gameObject.SetActive(false);

    protected virtual void OnGetFromPool(GameObject obj) => obj.gameObject.SetActive(true);

    protected virtual void OnDestroyFromPool(GameObject obj) => Destroy(obj.gameObject);
}
