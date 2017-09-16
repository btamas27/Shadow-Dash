using System.Collections;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum Type
    {
        Play,
        Retry
    }

    public Type type;

    public float MyDistance{ get; set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (EventManager.Instance.OnClick != null)
        {
            EventManager.Instance.OnClick();
        }
        if (EventManager.Instance.OnClickThis != null)
        {
            EventManager.Instance.OnClickThis(type);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (EventManager.Instance.OnClickUp != null)
        {
            EventManager.Instance.OnClickUp();
        }

    }
}