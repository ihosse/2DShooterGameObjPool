using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score;

    [SerializeField]
    private TextMeshProUGUI hiScore;

    public void UpdateScore(int newScore) 
    {
        score.text = "SCORE\n" + newScore.ToString("D5");
    }

    public void UpdateHiScore(int newHiScore) 
    {
        hiScore.text = "HI-SCORE\n" + newHiScore.ToString("D5"); ;
    }
}
