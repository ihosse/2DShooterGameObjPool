using System;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour, IDamageable, IPoolableObject
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

    [SerializeField]
    private GameObject explosionPrefab;
    private Weapon[] weapons;

    private ObjectPool<GameObject> pool;
    private int life;

    private void OnEnable()
    {
        life = initialLife;
    }
    private void Start()
    {
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
            pool.Release(gameObject);

            var poolFx = Pool.GetPool(explosionPrefab);
            GameObject hitFx = poolFx.Get();
            hitFx.transform.position = transform.position;
        }
    }

}
