using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Bullet bullet;

    [SerializeField]
    private float collDownTime = 1;
    private float timeToShoot;

    private void Start()
    {
        timeToShoot = collDownTime;
    }
    private void Update()
    {
        timeToShoot += Time.deltaTime;
    }
    public void FireWhenReady()
    {
        if (timeToShoot > collDownTime)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timeToShoot = 0;
        }
    }
}