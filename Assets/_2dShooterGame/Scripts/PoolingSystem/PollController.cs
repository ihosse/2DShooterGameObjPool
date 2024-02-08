using UnityEngine;

public class PollController : MonoBehaviour
{
    public Pool PoolFast { get; }
    public Pool PoolShoter{ get; }
    public Pool PoolHeavy { get; }
    public Pool PoolExplosion { get; }
    public Pool PoolHitFx { get; }
    public Pool PoolSimpleBullet { get; }
    public Pool PoolEnemyBullet { get; }

    [SerializeField]
    private Pool poolFast;

    [SerializeField]
    private Pool poolShoter;

    [SerializeField]
    private Pool poolHeavy;

    [SerializeField]
    private Pool poolExplosion;

    [SerializeField]
    private Pool poolHitFx;

    [SerializeField]
    private Pool poolSimpleBullet;

    [SerializeField]
    private Pool poolEnemyBullet;
}
