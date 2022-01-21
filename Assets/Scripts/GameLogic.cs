using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic gameLogic;
    private int GetEnemiesOnTheScene => GameObject.FindGameObjectsWithTag("Enemy").Length;
    private int enemiesCount;
    [SerializeField]
    private GameStatForUI gameStatForUI;

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
    }

    private void Start()
    {
        enemiesCount = GetEnemiesOnTheScene;
//        gameStatForUI.ResetScores();
    }

    public void DestroyEnemy(Enemy enemy)
    {
        return;
        gameStatForUI.KilledEnemy(enemy.myType);
        Destroy(enemy.gameObject);
        enemiesCount--;
        if (enemiesCount == 0)
            Debug.Log("Level ends");
    }
}
