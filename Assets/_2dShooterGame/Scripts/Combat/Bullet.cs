using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour, IPoolableObject
{
    [SerializeField]
    private GameObject hitEffectPrefab;

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private int damage = 1;

    [Space(10)]

    [SerializeField]
    private float minLimitX;
    
    [SerializeField]
    private float maxLimitX;

    [SerializeField]
    private float minLimitY;

    [SerializeField]
    private float maxLimitY;

    private ObjectPool<GameObject> pool;

    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);

        if (
            transform.position.x >= maxLimitX ||
            transform.position.x <= minLimitX ||
            transform.position.y >= maxLimitY ||
            transform.position.y <= minLimitY
           )
        {
            pool.Release(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITakeDamage element = collision.GetComponent<ITakeDamage>();

        if (element != null)
        {
            pool.Release(this.gameObject);
            element.TakeDamage(damage);

            var poolFx = Pool.GetPool(hitEffectPrefab);
            GameObject hitFx = poolFx.Get();
            hitFx.transform.position = transform.position;
        }
    }

    public void SetPool(ObjectPool<GameObject> pool)
    {
        this.pool = pool;
    }
}

