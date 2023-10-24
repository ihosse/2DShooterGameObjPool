using System;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent (typeof(Explosion))]
public class Enemy : MonoBehaviour, ITakeDamage, IObjectPoolable
{
    public event Action<int> OnKilled;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private int initialLife = 3;

    [SerializeField]
    private int points = 100;

    [SerializeField]
    private float verticalMoventLimit = -3;

    private Explosion explosion;
    private Weapon[] weapons;

    private ObjectPool<GameObject> pool;
    private int life;

    private void OnEnable()
    {
        life = initialLife;
    }
    private void Start()
    {
        explosion = GetComponent<Explosion> ();
        weapons = GetComponentsInChildren<Weapon>();
    }

    public void SetPool(ObjectPool<GameObject> pool)
    {
        this.pool = pool;
    }

    private void Update()
    {
        Move();
        Shot();
    }

    private void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);

        if(transform.position.y <= verticalMoventLimit) 
        {
            pool.Release(this.gameObject);
        }
    }

    private void Shot()
    {
        if (weapons == null)
            return;

        foreach (var weapon in weapons)
        {
            weapon.FireWhenReady();
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            OnKilled?.Invoke(points);
            pool.Release(this.gameObject);

            explosion.Create(transform.position);
        }
    }

}
