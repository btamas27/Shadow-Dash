using System.Collections;
using System;
using UnityEngine;

[System.Serializable]
public class SoundClip
{
    public AudioClip sound;
    public float volume;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance{ get; set; }

    private void Awake()
    {
        Instance = this;
    }

    private AudioSource GetNewAudioItem(Transform trans)
    {
        AudioSource audioItem = null;
        foreach (AudioSource audio in GetComponentsInChildren<AudioSource>())
        {
            if (!audio.isPlaying)
            {
                audioItem = audio;
            }
        }

        if (audioItem == null)
        {
            GameObject go = new GameObject();
            go.transform.SetParent(trans);
            go.AddComponent<AudioSource>();
            audioItem = go.GetComponent<AudioSource>();
        }

        return audioItem;

    }

    public AudioSource Play(AudioClip ac, Transform trans, Vector3 position, float volume = 1, ulong delay = 0, bool loop = false)
    {
        AudioSource audioItem = GetNewAudioItem(trans);
        audioItem.clip = ac;
        audioItem.volume = volume;
        audioItem.Play(delay);
        audioItem.loop = loop;
        audioItem.transform.position = position;
        audioItem.gameObject.AddComponent<DestroySound>();
        return audioItem;
    }



}
