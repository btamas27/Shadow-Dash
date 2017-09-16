using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance{ get; set; }

    #region FIELDS
    public GameObject character;
    #endregion

    #region PROPERTIES

    public int Score{ get; set; }

    public int HighScore{ get; set; }

    public bool IsPlaying{ get; set; }

    #endregion

    #region METHODS

    private void Awake()
    {
        Instance = this;
        IsPlaying = true;
    }

    public void TriggerChangeScreen(UIScreen.Type type)
    {
        if (EventManager.Instance.OnChangeScreen != null)
        {
            EventManager.Instance.OnChangeScreen(type);
        }
    }

    public void StartGame()
    {
        StartCoroutine(YStartGame());
    }

    IEnumerator YStartGame()
    {
        IsPlaying = true;
        TriggerChangeScreen(UIScreen.Type.InGame);
        yield return new WaitForSeconds(.4f);
        ObstaclePool.Instance.StartPool();
        character.transform.position = new Vector2(0, -3.5f);
        character.gameObject.SetActive(true);
    }

    #endregion

}
