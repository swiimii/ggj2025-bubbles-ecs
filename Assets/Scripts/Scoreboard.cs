using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text sessionHighScore;

    private void Start()
    {
        UpdateScoreboard(0);
        UpdateHighScore();
    }
    public void UpdateScoreboard( int newScore )
    {
        score.text = "Score: " + newScore;
    }

    public void UpdateHighScore()
    {
        sessionHighScore.text = "High Score: " + GameLoop.sessionHighScore;
    }
}
