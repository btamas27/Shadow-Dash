using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    private Text scoreText;

    void Start()
    {
        EventManager.Instance.OnScoreIncreased += HandleScoreIncrease;
        scoreText = GetComponentInChildren<Text>();
        scoreText.text = GameManager.Instance.Score + "";
    }

    void HandleScoreIncrease()
    {
        scoreText.text = GameManager.Instance.Score + "";
        GetComponent<Animator>().Play("ScoreBump");
    }
	
}
