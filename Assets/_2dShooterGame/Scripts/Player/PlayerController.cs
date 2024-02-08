using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class PlayerController : MonoBehaviour, IDamageable
{
    public event Action OnKilled;

    public InputHandler InputHandler { get { return inputHandler; } }

    [SerializeField]
    private GameObject explosionPrefab;

    private InputHandler inputHandler;


    public bool IsInControl { get; private set; }

    private void Start()
    {
        IsInControl = true;
        inputHandler = GetComponent<InputHandler>();
    }

    public void ActivateControl(bool value)
    {
        IsInControl = value;
    }

    public void TakeDamage(int damage)
    {
        KillMe();
    }

    private void KillMe()
    {
        gameObject.SetActive(false);

        var poolFx = Pool.GetPool(explosionPrefab);
        GameObject hitFx = poolFx.Get();
        hitFx.transform.position = transform.position;

        OnKilled?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out _))
        {
            KillMe();
        }
    }
}