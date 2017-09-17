using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonPlay : UIButton
{

    void Start()
    {
        base.OnClick += HandleClick;		
    }

	
    void HandleClick()
    {
        GameManager.Instance.StartGame();
    }
}
