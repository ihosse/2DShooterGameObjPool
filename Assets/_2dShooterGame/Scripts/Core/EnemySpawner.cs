using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class EnemySpawner : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private BasicPool enemyFastPool, enemyShooterPool, EnemyHeavyPool;

    [SerializeField]
    private Transform[] spawners;

    private IEnumerator spawnerCoroutine;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();

        enemyFastPool.Initialize(5, 10);
        enemyShooterPool.Initialize(3, 10);
        EnemyHeavyPool.Initialize(2, 10);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        foreach (Transform spawnPoint in spawners)
            Gizmos.DrawSphere(spawnPoint.position, .5f);
    }
    public void Activate() 
    {
        spawnerCoroutine = Spawner();
        StartCoroutine(spawnerCoroutine);
    }

    public void Deactivate()
    {
        StopCoroutine(spawnerCoroutine);
    }

    private void CreateEnemy(BasicPool selectedPool, Transform transform)
    {
        GameObject enemy = selectedPool.Pool.Get();
        enemy.gameObject.transform.position = transform.position;

        enemy.GetComponent<Enemy>().OnKilled += gameManager.OnEnemyKilled;
    }

    private IEnumerator Spawner() 
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            CreateEnemy(enemyFastPool, spawners[2].transform);

            yield return new WaitForSeconds(.5f);

            CreateEnemy(enemyFastPool, spawners[1].transform);
            CreateEnemy(enemyFastPool, spawners[3].transform);

            yield return new WaitForSeconds(.5f);

            CreateEnemy(enemyFastPool, spawners[0].transform);
            CreateEnemy(enemyFastPool, spawners[4].transform);

            yield return new WaitForSeconds(2f);

            CreateEnemy(enemyFastPool, spawners[1].transform);
            CreateEnemy(enemyFastPool, spawners[3].transform);

            yield return new WaitForSeconds(2);

            CreateEnemy(enemyFastPool, spawners[0].transform);
            CreateEnemy(enemyFastPool, spawners[2].transform);
            CreateEnemy(enemyFastPool, spawners[4].transform);

            yield return new WaitForSeconds(2);

            CreateEnemy(enemyShooterPool, spawners[2].transform);

            yield return new WaitForSeconds(1);

            CreateEnemy(enemyShooterPool, spawners[1].transform);
            CreateEnemy(enemyShooterPool, spawners[3].transform);

            yield return new WaitForSeconds(1);

            CreateEnemy(enemyFastPool, spawners[0].transform);
            CreateEnemy(enemyFastPool, spawners[2].transform);
            CreateEnemy(enemyFastPool, spawners[4].transform);

            yield return new WaitForSeconds(3);

            CreateEnemy(EnemyHeavyPool, spawners[1].transform);
            CreateEnemy(EnemyHeavyPool, spawners[3].transform);

            yield return new WaitForSeconds(10);
        }
    }
}
