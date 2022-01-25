using UnityEngine;

public class GameStatForUI : MonoBehaviour
{
    private int _scores = 0;
    private int _playerLifes = 3;
    public static GameStatForUI gameStatForUI;

    public GameStatForUI()
    {
        gameStatForUI = this;
    }

    public int scores
    {
        get { return _scores; }
        private set 
        { 
            _scores = value; 
        }
    }

    public static string GetMessage()
    {
        return $"IamAlive +{gameStatForUI.scores}";
    }

    public int playerLifes
    {
        get { return playerLifes; }
        private set 
        { 
            playerLifes = value; 
        }
    }

    public delegate void ScoresChangedVoid();
    public static event ScoresChangedVoid ScoresChanged;
    public delegate void LifesCountChangedVoid();
    public static event LifesCountChangedVoid LifesCountChanged;

    public void ResetScores()
    {
        scores = 0;
        playerLifes = 3;
    }

    public void KilledEnemy(EnemyStat.EnemyType enemyType) => scores += 100 * (int)(enemyType + 1);

    public void LostLife() => playerLifes--;
}
