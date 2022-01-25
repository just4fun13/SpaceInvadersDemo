using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIoutput : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoresText;
    [SerializeField] TextMeshProUGUI lifesText;

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

    public void ShowScores() => scoresText.text = $"Scores : {GameStatForUI.gameStatForUI.scores}";

    public void ShowLifesCount() => lifesText.text = $"Lifes x {GameStatForUI.gameStatForUI.scores}";
}
