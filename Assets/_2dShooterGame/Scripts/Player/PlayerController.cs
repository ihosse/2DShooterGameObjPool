using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(Explosion))]
public class PlayerController : MonoBehaviour, ITakeDamage
{
    public event Action OnKilled;

    public InputHandler InputHandler { get { return inputHandler; } }

    private Explosion explosion;

    private InputHandler inputHandler;


    public bool IsInControl { get; private set; }

    private void Start()
    {
        IsInControl = true;

        explosion = GetComponent<Explosion>();
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

        explosion.Create(transform.position);

        OnKilled?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            KillMe();
        }
    }
}