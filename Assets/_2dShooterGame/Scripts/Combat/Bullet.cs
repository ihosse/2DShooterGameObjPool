using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private string hierarquiyPoolName;

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

    private BasicPool basicPool;
    private BasicPool hitPool;

    private void Start()
    {
        basicPool = GameObject.Find("Pools/" + hierarquiyPoolName).GetComponent<BasicPool>();

        hitPool = GameObject.Find("Pools/HitEffectPool").GetComponent<BasicPool>();
        hitPool.Initialize(5, 10);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);

        if (
            transform.position.x >= maxLimitX ||
            transform.position.x <= minLimitX ||
            transform.position.y >= maxLimitY ||
            transform.position.y <= minLimitY
           )
            basicPool.Pool.Release(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITakeDamage element = collision.GetComponent<ITakeDamage>();

        if (element != null)
        {
            basicPool.Pool.Release(this.gameObject);
            element.TakeDamage(damage);

            GameObject hitEffect = hitPool.Pool.Get();
            hitEffect.transform.position = transform.position;
        }
    }
}

