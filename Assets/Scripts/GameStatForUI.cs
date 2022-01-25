using UnityEngine;

public class GameStatForUI : MonoBehaviour
{
    private int _playerLifesCount = 3;
    private int _scores = 0;

    public delegate void ScoresChanged(int newScores);
    public static event ScoresChanged ScoresChangedEvent;
    public delegate void LifeCountChanged(int newScores);
    public static event LifeCountChanged LifeCountChangedEvent;


    public int Scores
    {
        get { return _scores; }
        set 
        { 
            _scores = value;
            if (ScoresChangedEvent != null)
                ScoresChangedEvent(_scores);
        }
    }

    public int Lifes
    {
        get { return _playerLifesCount; }
        set 
        { 
            _playerLifesCount = value;
            if (LifeCountChangedEvent != null)
                LifeCountChangedEvent(_playerLifesCount);
        }
    }

    public void ShowStats()
    {
        if (ScoresChangedEvent != null)
            ScoresChangedEvent(_scores);
        if (LifeCountChangedEvent != null)
            LifeCountChangedEvent(_playerLifesCount);
    }

    public void ResetScores()
    {
        Lifes = 3;
        Scores = 0;
    }

    public void EarnScores(EnemyStat.EnemyType enemyType)
    {
        Scores += ((int)enemyType + 1) * 100;
    }

    public void PlayerDamage()
    {
        Lifes--;
    }
}
