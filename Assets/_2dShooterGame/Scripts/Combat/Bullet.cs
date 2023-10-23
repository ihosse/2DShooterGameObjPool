using UnityEngine;

public class Bullet : MonoBehaviour
{
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

    [SerializeField]
    private GameObject ImpactFx;

    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);

        if (
            transform.position.x >= maxLimitX ||
            transform.position.x <= minLimitX ||
            transform.position.y >= maxLimitY ||
            transform.position.y <= minLimitY
           )
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITakeDamage element = collision.GetComponent<ITakeDamage>();

        if (element != null)
        {
            Destroy(gameObject);
            element.TakeDamage(damage);

            GameObject effect = Instantiate(ImpactFx.gameObject, transform.position, Quaternion.identity);
            Destroy(effect, .5f);
        }
    }
}

