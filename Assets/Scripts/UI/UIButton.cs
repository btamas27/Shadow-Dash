using System.Collections;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action OnClick;
    public Action OnClickUp;
    public Action<UIButton.Type> OnClickThis;

    public enum Type
    {
        Play,
        Retry
    }

    public Type type;

    public float MyDistance{ get; set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnClick != null)
        {
            OnClick();
        }
        if (OnClickThis != null)
        {
            OnClickThis(type);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnClickUp != null)
        {
            OnClickUp();
        }

    }
}