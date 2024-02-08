using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

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
            var pool = Pool.GetPool(bulletPrefab);
            pool.Get(transform);
            timeToShoot = 0;
        }
    }
}