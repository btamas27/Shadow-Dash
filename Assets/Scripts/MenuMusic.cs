using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{

    public static MenuMusic Instance { get; set; }
    public AudioSource MusicMenu{ get { return GetComponent<AudioSource>(); } }
    private float bgVolume;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        bgVolume = 1f;
    }

    public void CallFadeIn(AudioSource sound)
    {
        StartCoroutine(FadeIn(sound));
    }

    public void CallFadeOut(AudioSource sound)
    {
        StartCoroutine(FadeOut(sound));
    }

    private IEnumerator FadeIn (AudioSource sound)
    {
        float fader = 0;
        float fadeTime = 1f;
        //        if (counter > 10)
        //        {
        //            fadeTime = Random.Range(.4f, 8f);
        //        }
        while (fader < bgVolume)
        {
            fader += Time.deltaTime;
            sound.volume = fader;
            yield return null;
        }
        sound.volume = bgVolume;
    }

    private IEnumerator FadeOut (AudioSource sound)
    {
        float fader = bgVolume;
        while (fader > 0)
        {
            fader -= Time.deltaTime;
            sound.volume = fader;
            yield return null;
        }
        sound.volume = 0;
    }
}
