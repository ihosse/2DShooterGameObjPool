using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private string hierarquiyPoolName;

    [SerializeField]
    private float collDownTime = 1;

    private float timeToShoot;
    private BasicPool basicPool;

    private void Start()
    {
        basicPool = GameObject.Find("Pools/"+ hierarquiyPoolName).GetComponent<BasicPool>();
        basicPool.Initialize(10, 20);
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
            GameObject bullet = basicPool.Pool.Get();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            timeToShoot = 0;
        }
    }
}