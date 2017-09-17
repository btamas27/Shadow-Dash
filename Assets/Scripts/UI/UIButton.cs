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
        SoundManager.Instance.Play(GameManager.Instance.buttonClick.sound, transform.parent.parent, transform.position,GameManager.Instance.buttonClick.volume);
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