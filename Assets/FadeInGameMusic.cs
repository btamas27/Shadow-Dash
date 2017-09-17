using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInGameMusic : MonoBehaviour {



    void OnEnable()
    {
        MenuMusic.Instance.CallFadeIn(GetComponent<AudioSource>());
    }

//    void OnDisable()
//    {
//        MenuMusic.Instance.CallFadeOut(GetComponent<AudioSource>());
//    }
}
