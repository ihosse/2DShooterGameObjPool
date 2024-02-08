using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ParticleEffect : MonoBehaviour, IPoolableObject
{
    [SerializeField]
    private float timeToDeactivate = 1;

    private ParticleSystem particleSystem;

    private ObjectPool<GameObject> pool;
    public void OnEnable() 
    {
        particleSystem.Play();
        StartCoroutine(Deactivate());
    }

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void SetPool(ObjectPool<GameObject> pool)
    {
        this.pool = pool;
    }

    private IEnumerator Deactivate() 
    {
        yield return new WaitForSeconds(timeToDeactivate);
        pool.Release(this.gameObject);
    }
}
