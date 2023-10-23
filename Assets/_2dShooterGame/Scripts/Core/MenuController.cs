using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(InputHandler))]
public class MenuController : MonoBehaviour
{
    [SerializeField]
    private HUD hud;

    [SerializeField]
    private string gameSceneName;

    private InputHandler inputHandler;

    private void Start()
    {
        inputHandler = GetComponent<InputHandler>();

        hud.UpdateScore(Globals.PlayerScore);
        hud.UpdateHiScore(Globals.PlayerHighScore);
    }

    private void Update()
    {
        if (inputHandler.GetFire1Button())
        {
           SceneManager.LoadScene(gameSceneName);
        }
    }
}
