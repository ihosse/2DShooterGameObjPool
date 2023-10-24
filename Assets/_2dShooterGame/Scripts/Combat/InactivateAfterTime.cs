using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class InactivateAfterTime : MonoBehaviour, IObjectPoolable
{
    [SerializeField]
    private UnityEngine.GameObject explosionPrefab;

    [SerializeField]
    private float timeToAutoDestroy = 2f;

    private ObjectPool<GameObject> pool;

    private void OnEnable() 
    {
        StartCoroutine(Deactivate());
    }
    
    public void SetPool(ObjectPool<GameObject> pool)
    {
        this.pool = pool;
    }
    public IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(timeToAutoDestroy);
        pool.Release(this.gameObject);
    }

    
}
