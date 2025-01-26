using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    public static GameLoop Singleton;
    public static int sessionHighScore = 0;

    public int score = 0;
    public bool isGameOver = false;

    public UnityEvent<int /*newScore*/> onScoreIncreaseEvent;
    public UnityEvent onGameLossEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Singleton = this;
    }

    public static void IncrementScore(int increment)
    {
        if( !Singleton.isGameOver )
        {
            Singleton.score += increment;
            Singleton.onScoreIncreaseEvent.Invoke(Singleton.score);
        }
    }

    public static void LoseGame()
    {
        Singleton.isGameOver = true;
        Singleton.onGameLossEvent.Invoke();
        UpdateSessionHighScore();
    }

    public static void UpdateSessionHighScore()
    {
        sessionHighScore = Mathf.Max( Singleton.score, sessionHighScore );
    }

    public IEnumerator GameRestartCoroutine()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
