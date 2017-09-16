using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static float positionY = -3.5f;

    public iTween.EaseType movement = iTween.EaseType.easeOutCubic;
    public iTween.EaseType putBackMovement = iTween.EaseType.easeOutExpo;
    Vector3 lastPosition;

    public float MinPositionX
    {
        get
        {
            return Utilities.ScreenSize.x - Utilities.GetHalfSizeOfObject(gameObject);
        }
    }

    public float MaxPositionX
    {
        get
        {
            return Utilities.GetHalfSizeOfObject(gameObject) - Utilities.ScreenSize.x;
        }
    }

    public Vector3 LastPosition
    {
        get
        {
            
            return lastPosition;
        }
        set
        {
            lastPosition = value;
        }
    }

    public Vector3 CurrentPosition
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }

    void Start()
    {
        iTween.Init(gameObject);
    }

    void Update()
    {
        
    }
}
