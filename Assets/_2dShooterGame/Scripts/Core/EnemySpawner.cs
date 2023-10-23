using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class EnemySpawner : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private Enemy enemyFast;

    [SerializeField]
    private Enemy enemyShooter;

    [SerializeField]
    private Enemy enemyHeavy;

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

    private IEnumerator Spawner() 
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            CreateEnemy(enemyFast.gameObject, spawners[2].transform);

            yield return new WaitForSeconds(.5f);

            CreateEnemy(enemyFast.gameObject, spawners[1].transform);
            CreateEnemy(enemyFast.gameObject, spawners[3].transform);

            yield return new WaitForSeconds(.5f);

            CreateEnemy(enemyFast.gameObject, spawners[0].transform);
            CreateEnemy(enemyFast.gameObject, spawners[4].transform);

            yield return new WaitForSeconds(2f);

            CreateEnemy(enemyFast.gameObject, spawners[1].transform);
            CreateEnemy(enemyFast.gameObject, spawners[3].transform);

            yield return new WaitForSeconds(2);

            CreateEnemy(enemyFast.gameObject, spawners[0].transform);
            CreateEnemy(enemyFast.gameObject, spawners[2].transform);
            CreateEnemy(enemyFast.gameObject, spawners[4].transform);

            yield return new WaitForSeconds(2);

            CreateEnemy(enemyShooter.gameObject, spawners[2].transform);

            yield return new WaitForSeconds(1);

            CreateEnemy(enemyShooter.gameObject, spawners[1].transform);
            CreateEnemy(enemyShooter.gameObject, spawners[3].transform);

            yield return new WaitForSeconds(1);

            CreateEnemy(enemyFast.gameObject, spawners[0].transform);
            CreateEnemy(enemyFast.gameObject, spawners[2].transform);
            CreateEnemy(enemyFast.gameObject, spawners[4].transform);

            yield return new WaitForSeconds(3);

            CreateEnemy(enemyHeavy.gameObject, spawners[1].transform);
            CreateEnemy(enemyHeavy.gameObject, spawners[3].transform);

            yield return new WaitForSeconds(10);
        }
    }

    private void CreateEnemy(GameObject selectedEnemy, Transform transform) 
    {
        GameObject enemy = Instantiate(selectedEnemy);
        enemy.transform.position = transform.position;

        enemy.GetComponent<Enemy>().OnKilled += gameManager.OnEnemyKilled;
    }
}
