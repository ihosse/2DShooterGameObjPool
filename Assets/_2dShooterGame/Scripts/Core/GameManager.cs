using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EnemySpawner))]
public class GameManager : MonoBehaviour
{
    private EnemySpawner enemySpawner;

    [SerializeField]
    private PlayerController playerController;
    
    [SerializeField]
    private HUD hud;

    [SerializeField]
    private string menuSceneName;


    private void Start()
    {
        Globals.PlayerScore = 0;
        hud.UpdateScore(Globals.PlayerScore);
        hud.UpdateHiScore(Globals.PlayerHighScore);

        playerController.OnKilled += OnPlayerKilled;

        enemySpawner = GetComponent<EnemySpawner>();
        enemySpawner.Activate();
    }

    public void OnEnemyKilled(int points) 
    {
        Globals.PlayerScore += points;
        hud.UpdateScore(Globals.PlayerScore);

        if (Globals.PlayerScore > Globals.PlayerHighScore)
        {
            Globals.PlayerHighScore = Globals.PlayerScore;
            hud.UpdateHiScore(Globals.PlayerHighScore);
        }
    }
    private void OnPlayerKilled()
    {
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver() 
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(menuSceneName);
    }
}
