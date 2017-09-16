using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private Character character;

    public Character Character
    {
        get
        {
            if (character == null)
            {
                character = GetComponentInChildren<Character>();
            }
            return character;
        }
    }

    private Vector3 MousePosition
    {
        get{ return Input.mousePosition; }
    }

    void Start()
    {
        Character.LastPosition = Character.CurrentPosition;
        EventManager.Instance.OnClickDown += HandleClick;
    }

    void OnDestroy()
    {
        EventManager.Instance.OnClickDown -= HandleClick;
    }

    void HandleClick()
    {
        iTween.MoveTo(Character.gameObject, iTween.Hash("position", Utilities.MousePositionInWorldUnit, "easetype", Character.movement, "time", .7f, "oncomplete", "PutBackIfNeeded", "onCompleteTarget", gameObject));
    }

    void PutBackIfNeeded()
    {
        int side = Utilities.CheckIfOutOfScreen(Character.gameObject);
        if (side == (int)Utilities.SIDE.LEFT)
        {
            iTween.MoveTo(Character.gameObject, iTween.Hash("position", new Vector3(Character.MinPositionX, Character.transform.position.y), "easetype", Character.putBackMovement, "time", .4f));
        }
        else if (side == (int)Utilities.SIDE.RIGHT)
        {
            iTween.MoveTo(Character.gameObject, iTween.Hash("position", new Vector3(Character.MaxPositionX, Character.transform.position.y), "easetype", Character.putBackMovement, "time", .4f));
        }
    }
       
}
