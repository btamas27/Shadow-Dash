using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance{ get; set; }

    #region FIELDS

    public GameObject character;

    public SoundClip deathSound;
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
//        IsPlaying = true;
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
        Debug.Log("WTF");
        StartCoroutine(YStartGame());
    }

    IEnumerator YStartGame()
    {
        TriggerChangeScreen(UIScreen.Type.InGame);
        yield return new WaitForSeconds(.4f);
        IsPlaying = true;
        ObstaclePool.Instance.StartPool();
        character.transform.position = new Vector2(0, -3.5f);
        character.gameObject.SetActive(true);
        character.transform.GetChild(0).gameObject.SetActive(true);
        character.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
    }

    #endregion

}
