using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreenMain : UIScreen
{

    void OnEnable()
    {
        MenuMusic.Instance.CallFadeIn(MenuMusic.Instance.MusicMenu);
    }

    void OnDisable()
    {
        MenuMusic.Instance.CallFadeOut(MenuMusic.Instance.MusicMenu);
    }
}
