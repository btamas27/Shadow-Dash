using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; set; }

    public Action<UIScreen.Type> OnChangeScreen;
    public Action<UIButton.Type> OnClickThis;
    public Action OnClick;
    public Action OnClickUp;
    public Action OnClickDown;

    private void Awake()
    {
        Instance = this;
    }
}
