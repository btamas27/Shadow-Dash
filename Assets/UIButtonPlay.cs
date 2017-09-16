using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonPlay : UIButton
{

    void Start()
    {
        EventManager.Instance.OnClick += HandleClick;		
    }
	
    void HandleClick()
    {
        GameManager.Instance.StartGame();
    }
}
