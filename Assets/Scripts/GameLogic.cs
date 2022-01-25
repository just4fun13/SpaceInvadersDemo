using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection.Emit;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameStatForUI))]
public class GameLogic : MonoBehaviour
{
    public static GameLogic gameLogic;
    private int GetEnemiesOnTheScene => GameObject.FindGameObjectsWithTag("Enemy").Length;
    private int enemiesCount;
    private GameStatForUI gameStatForUI;
    public bool gamePaused { get; private set; } = false;
    
    [SerializeField] GameObject gameOverPanel;

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


    private void Start()
    {
        gameStatForUI.ShowStats();
        enemiesCount = GetEnemiesOnTheScene;
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
        if (nextSceneIndex >= SceneManager.sceneCount)
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

    private void InitScene(Scene s, LoadSceneMode m)
    {
        gameStatForUI.ShowStats();
        enemiesCount = GetEnemiesOnTheScene;
    }

    private void GameOver()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        GameObject.FindGameObjectWithTag("GameOverPanel").SetActive(true);
    }

    public void RestartGame()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        gameStatForUI.ResetScores();
        SceneManager.LoadScene(0);
    }
}
