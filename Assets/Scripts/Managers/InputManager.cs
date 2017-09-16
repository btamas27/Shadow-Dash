using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameManager.Instance.IsPlaying)
                return;

            if (EventManager.Instance.OnClickDown != null)
            {
                EventManager.Instance.OnClickDown();
            }
        }
    }
}
