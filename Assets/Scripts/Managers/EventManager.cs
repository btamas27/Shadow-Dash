using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; set; }

    public Action<UIScreen.Type> OnChangeScreen;
    public Action OnClickDown;
    public Action OnDeath;

    private void Awake()
    {
        Instance = this;
    }
}
