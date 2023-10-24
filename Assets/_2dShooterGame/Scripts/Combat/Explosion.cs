using UnityEngine;

public class Explosion : MonoBehaviour
{
    private BasicPool basicPool;

    private void Start()
    {
        basicPool = GameObject.Find("Pools/ExplosionsParticlePool").GetComponent<BasicPool>();
        basicPool.Initialize(5, 10);
    }
    public void Create(Vector3 position)
    {
        GameObject explosion = basicPool.Pool.Get();
        explosion.transform.position = transform.position;
        explosion.GetComponent<DeactivationTimer>().ScheduleDeactivation(basicPool);
    }
}
