using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonRetry : UIButton
{
    
    void Start()
    {
        base.OnClick += HandleClick;
    }

    void HandleClick()
    {
        GameManager.Instance.TriggerChangeScreen(UIScreen.Type.Main);
    }
}
