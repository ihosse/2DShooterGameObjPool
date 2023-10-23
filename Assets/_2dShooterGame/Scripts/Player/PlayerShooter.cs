using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerShooter : MonoBehaviour
{
    private PlayerController controller;

    private Weapon[] weapons;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
        weapons = GetComponentsInChildren<Weapon>();
    }

    private void Update()
    {
        if (!controller.IsInControl)
            return;

        Shot();
    }
    private void Shot()
    {
        if (controller.InputHandler.GetFire1Button())
        {
            foreach (var weapon in weapons) 
            {
                weapon.FireWhenReady();
            } 
        }
    }
}
