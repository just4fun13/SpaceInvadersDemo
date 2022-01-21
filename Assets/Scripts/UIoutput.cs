using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIoutput : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoresText;
    [SerializeField] TextMeshProUGUI lifesText;
    [SerializeField] GameStatForUI gameStatForUI;

    private void OnEnalbe()
    {
        GameStatForUI.ScoresChanged += ShowScores;
        GameStatForUI.LifesCountChanged += ShowLifesCount;
    }

    private void OnDisable()
    {
        GameStatForUI.ScoresChanged -= ShowScores;
        GameStatForUI.LifesCountChanged -= ShowLifesCount;
    }

    public void ShowScores() => scoresText.text = $"Scores : {gameStatForUI.scores}";

    public void ShowLifesCount() => lifesText.text = $"Lifes x {gameStatForUI.scores}";
}
