using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGameOver : MonoBehaviour {

    void OnEnable()
    {
        GetComponentInChildren<Text>().text = GameManager.Instance.Score + "";
    }
}
