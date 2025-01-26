using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Unity.Scenes;
using Unity.Entities;

public class GameLoop : MonoBehaviour
{
    public static GameLoop Singleton;
    public static int sessionHighScore = 0;

    public int score = 0;
    public bool isGameOver = false;

    public UnityEvent<int /*newScore*/> onScoreIncreaseEvent;
    public UnityEvent onGameLossEvent;

    public SubScene subSceneToLoad;

    private Entity subScene;


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
        if( !Singleton.isGameOver )
        {
            Singleton.isGameOver = true;
            Singleton.onGameLossEvent.Invoke();
            UpdateSessionHighScore();
            Singleton.StartCoroutine(Singleton.GameRestartCoroutine());
        }
    }

    public static void UpdateSessionHighScore()
    {
        sessionHighScore = Mathf.Max( Singleton.score, sessionHighScore );
    }

    public IEnumerator GameRestartCoroutine()
    {
        yield return new WaitForSeconds(3);

        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        entityManager.DestroyEntity(entityManager.UniversalQuery);

        World.DefaultGameObjectInjectionWorld.Dispose();
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        DefaultWorldInitialization.Initialize("Default World", false);

        var loadParameters = new SceneSystem.LoadParameters
        {
            Flags = SceneLoadFlags.NewInstance,

        };

        SceneSystem.LoadSceneAsync(World.DefaultGameObjectInjectionWorld.Unmanaged, subSceneToLoad.SceneGUID, loadParameters);
    }

}
