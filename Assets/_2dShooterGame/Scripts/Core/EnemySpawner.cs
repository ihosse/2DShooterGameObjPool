using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class EnemySpawner : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private GameObject enemyFastPrefab, enemyShooterPrefab, EnemyHeavyPrefab;

    [SerializeField]
    private Transform[] spawners;

    private IEnumerator spawnerCoroutine;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
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

    private void CreateEnemy(GameObject prefab, Transform transform)
    {
        var pool = Pool.GetPool(prefab);

        GameObject enemy = pool.Get(transform);
        enemy.GetComponent<Enemy>().OnKilled += gameManager.OnEnemyKilled;
        GameManager.OnGameOver += pool.OnGameOver;
    }

    private IEnumerator Spawner() 
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            CreateEnemy(enemyFastPrefab, spawners[2].transform);

            yield return new WaitForSeconds(.5f);

            CreateEnemy(enemyFastPrefab, spawners[1].transform);
            CreateEnemy(enemyFastPrefab, spawners[3].transform);

            yield return new WaitForSeconds(.5f);

            CreateEnemy(enemyFastPrefab, spawners[0].transform);
            CreateEnemy(enemyFastPrefab, spawners[4].transform);

            yield return new WaitForSeconds(2f);

            CreateEnemy(enemyFastPrefab, spawners[1].transform);
            CreateEnemy(enemyFastPrefab, spawners[3].transform);

            yield return new WaitForSeconds(2);

            CreateEnemy(enemyFastPrefab, spawners[0].transform);
            CreateEnemy(enemyFastPrefab, spawners[2].transform);
            CreateEnemy(enemyFastPrefab, spawners[4].transform);

            yield return new WaitForSeconds(2);

            CreateEnemy(enemyShooterPrefab, spawners[2].transform);

            yield return new WaitForSeconds(1);

            CreateEnemy(enemyShooterPrefab, spawners[1].transform);
            CreateEnemy(enemyShooterPrefab, spawners[3].transform);

            yield return new WaitForSeconds(1);

            CreateEnemy(enemyFastPrefab, spawners[0].transform);
            CreateEnemy(enemyFastPrefab, spawners[2].transform);
            CreateEnemy(enemyFastPrefab, spawners[4].transform);

            yield return new WaitForSeconds(3);

            CreateEnemy(EnemyHeavyPrefab, spawners[1].transform);
            CreateEnemy(EnemyHeavyPrefab, spawners[3].transform);

            yield return new WaitForSeconds(10);
        }
    }
}
