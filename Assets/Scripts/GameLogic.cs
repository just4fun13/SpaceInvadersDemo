using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection.Emit;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

[RequireComponent(typeof(GameStatForUI))]
public class GameLogic : MonoBehaviour
{
    public static GameLogic gameLogic;
    private int GetEnemiesOnTheScene => GameObject.FindGameObjectsWithTag("Enemy").Length;
    private int enemiesCount;
    private GameStatForUI gameStatForUI;
    public bool gamePaused { get; private set; } = false;
    
    void Awake()
    {
        if (gameLogic != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
            gameLogic = this;
        }
        gameStatForUI = GetComponent<GameStatForUI>();
        SceneManager.sceneLoaded += InitScene;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= InitScene;
    }


    public void DestroyEnemy(Enemy enemy)
    {
        gameStatForUI.EarnScores(enemy.myType);
        Destroy(enemy.gameObject);
        enemiesCount--;
        if (enemiesCount == 0)
            LoadNextLevel();
    }
    private void LoadNextLevel() 
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void PlayerGotDamage()
    {
        if (gameStatForUI.Lifes > 0)
            gameStatForUI.PlayerDamage();
        else
            GameOver();
    }

    private async void InitScene(Scene s, LoadSceneMode m)
    {
        enemiesCount = GetEnemiesOnTheScene;
        await Task.Delay(500);
        gameStatForUI.ShowStats();
    }

    private void GameOver()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        GameObject pn = GameObject.FindWithTag("GameOverPanel");
        pn.GetComponent<CanvasGroup>().alpha = 1f;
    }

    public void RestartGame()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        gameStatForUI.ResetScores();
        SceneManager.LoadScene(0);
    }
}
