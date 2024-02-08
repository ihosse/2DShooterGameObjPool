using UnityEngine.Pool;
using UnityEngine;

public interface IPoolableObject
{
    public void SetPool(ObjectPool<GameObject> pool);
}