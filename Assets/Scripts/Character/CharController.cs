using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public static CharController Instance { get; set; }

    [SerializeField]
    Character character;

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

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Character.LastPosition = Character.CurrentPosition;
        EventManager.Instance.OnClickDown += HandleClickDown;
    }

    void OnDestroy()
    {
        EventManager.Instance.OnClickDown -= HandleClickDown;
    }

    void HandleClickDown()
    {
        iTween.MoveTo(Character.gameObject, iTween.Hash(
                "position", Utilities.MousePositionInWorldUnit, 
                "easetype", Character.movement, 
                "time", .7f, 
                "oncomplete", "PutBackIfNeeded", "onCompleteTarget", gameObject, 
                "onupdate", "PlayTapPaticle", "onUpdateTarget", Character.gameObject)
        );
    }

    void PutBackIfNeeded()
    {
        int side = Utilities.CheckIfOutOfScreen(Character.gameObject);
        if (side == (int)Utilities.SIDE.LEFT)
        {
            iTween.MoveTo(Character.gameObject, iTween.Hash(
                    "position", new Vector3(Character.MinPositionX, Character.transform.position.y), 
                    "easetype", Character.putBackMovement, 
                    "time", .4f, 
                    "onupdate", "PlayTapPaticle", "onUpdateTarget", Character.gameObject)
            );
        }
        else if (side == (int)Utilities.SIDE.RIGHT)
        {
            iTween.MoveTo(Character.gameObject, iTween.Hash(
                    "position", new Vector3(Character.MaxPositionX, Character.transform.position.y),
                    "easetype", Character.putBackMovement,
                    "time", .4f, 
                    "onupdate", "PlayTapPaticle", "onUpdateTarget", Character.gameObject)
            );
        }
    }
       
}
