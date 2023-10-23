using System;
using UnityEngine;

[RequireComponent(typeof(Explosion))]
public class Enemy : MonoBehaviour, ITakeDamage
{
    public event Action<int> OnKilled;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private float life = 3;

    [SerializeField]
    private int points = 100;

    private Explosion explosion;
    private Weapon[] weapons;

    private void Start()
    {
        explosion = GetComponent<Explosion>();
        weapons = GetComponentsInChildren<Weapon>();
    }

    private void Update()
    {
        Move();
        Shot();
    }

    private void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
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
            Destroy(gameObject);

            explosion.Activate();
        }
    }
}
