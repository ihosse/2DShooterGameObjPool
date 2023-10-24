using UnityEngine.Pool;
using UnityEngine;

public interface IObjectPoolable
{
    public void SetPool(ObjectPool<GameObject> pool);
}