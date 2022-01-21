using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatForUI : MonoBehaviour
{
    private int _scores;
    private int _playerLifes;
    public int scores
    {
        get { return _scores; }
        private set { _scores = value; if (ScoresChanged != null) ScoresChanged(); }
    }

    public int playerLifes
    {
        get { return playerLifes; }
        private set { playerLifes = value; if (LifesCountChanged != null) LifesCountChanged(); }
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
