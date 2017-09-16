using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    public enum SIDE
    {
        LEFT = -1,
        RIGHT = 1
    }

    public static Vector3 ScreenSize
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
        }
    }

    public static Vector3 MousePositionInWorldUnit
    {
        get
        { 
            Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return new Vector3(_mousePosition.x, Character.positionY, 0);
        }
    }

    public static int CheckIfOutOfScreen(GameObject obj, GameObject parent = null)
    {
        float halfSize = GetHalfSizeOfObject(obj);

        Transform compareTo = obj.transform;
        if (parent != null)
        {
            compareTo = parent.transform;
        }

        if (compareTo.position.x > (ScreenSize.x - halfSize))
        {
            return (int)SIDE.LEFT;
        }
        else if (compareTo.position.x < (halfSize - ScreenSize.x))
        {
            return (int)SIDE.RIGHT;
        }
        return 0;
    }

    public static float GetHalfSizeOfObject(GameObject obj)
    {
        Renderer renderer = GetRenderer(obj);
        if (renderer != null)
        {
            return renderer.bounds.size.x / 2;
        }
        return 0.0f;
    }

    public static Renderer GetRenderer(GameObject obj)
    {
        if (obj.GetComponent<Renderer>() != null)
        {
            return obj.GetComponent<Renderer>();
        }
        return null;
    }

}
