using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    private Text scoreText;

    void OnEnable()
    {
        EventManager.Instance.OnScoreIncreased += HandleScoreIncrease;
        scoreText = GetComponentInChildren<Text>();
        scoreText.text = 0 + "";
    }

    void HandleScoreIncrease()
    {
        scoreText.text = GameManager.Instance.Score + "";
        GetComponent<Animator>().Play("ScoreBump");
    }
	
    void OnDisable()
    {
        EventManager.Instance.OnScoreIncreased -= HandleScoreIncrease;
    }
}
