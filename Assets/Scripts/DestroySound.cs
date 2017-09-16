using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySound : MonoBehaviour 
{
    private void Start()
    {
        if (!GetComponent<AudioSource> ().loop) {
            StartCoroutine (DestroyWhenOver ());
        } else {
            //StartCoroutine (FadeIn ());
        }
    }

    private IEnumerator DestroyWhenOver()
    {
        yield return new WaitForSeconds (3.5f);
        yield return new WaitUntil(() => !GetComponent<AudioSource>().isPlaying);
        Destroy (gameObject);
    }
}
