using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

    public static ObstaclePool Instance{ get; set; }

    public AudioSource music;
    public GetSongData data;

    private void Awake()
    {
        Instance = this;
    }

	public void StartPool () 
    {
        StartCoroutine(YSpawner());
        StartCoroutine(YStartMusic());
        data.gameObject.SetActive(true);
	}

    private IEnumerator YSpawner()
    {
        while (GameManager.Instance.IsPlaying)
        {
            if (data.dbValue > 8)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (transform.GetChild(i).gameObject.activeSelf == false)
                    {
                        transform.GetChild(i).gameObject.SetActive(true);
                        break;
                    }
                }
                yield return new WaitForSeconds(.9f);
//                yield return null;
            }
            else
            {
                yield return null;
            }
        }
        data.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        StopAllCoroutines();
    }

    private IEnumerator YStartMusic()
    {
        yield return new WaitForSeconds(1.28f);
        music.gameObject.SetActive(true);
//        yield return null;
    }
}
