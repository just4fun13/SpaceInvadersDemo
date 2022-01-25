using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIoutput : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoresText;
    [SerializeField] TextMeshProUGUI lifesText;

    private void Awake()
    {
        GameStatForUI.LifeCountChangedEvent += ShowLifesCount;
        GameStatForUI.ScoresChangedEvent += ShowScores;
    }

    private void OnDisable()
    {
        GameStatForUI.LifeCountChangedEvent -= ShowLifesCount;
        GameStatForUI.ScoresChangedEvent -= ShowScores;
    }

    public void ShowScores(int scores) => scoresText.text = $"Scores : {scores}";

    public void ShowLifesCount(int lifes) => lifesText.text = $"Lifes x {lifes}";
}
