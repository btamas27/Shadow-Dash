using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public static CharController Instance { get; set; }

    [SerializeField]
    Character character;

    public ParticleSystem teleportStart;
    public ParticleSystem teleportFinish;

    public Character Character
    {
        get
        {
            if (character == null)
            {
                character = GetComponentInChildren<Character>(true);
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
        int temp = Random.Range(0, 3);
        SoundManager.Instance.Play(GameManager.Instance.dashSounds[temp].sound, transform.parent.parent, transform.position,GameManager.Instance.dashSounds[temp].volume);
        if (GameManager.Instance.IsTeleportOn)
        {
            StartCoroutine(YTeleport());
        }
        else
        {
            iTween.MoveTo(Character.gameObject, iTween.Hash(
                    "position", Utilities.MousePositionInWorldUnit, 
                    "easetype", Character.movement, 
                    "time", .5f, 
                    "onstart", "Rotate", "onStartTarget", gameObject,
                    "oncomplete", "PutBackIfNeeded", "onCompleteTarget", gameObject, 
                    "onupdate", "PlayTapPaticle", "onUpdateTarget", Character.gameObject)
            );
        }
    }

    private IEnumerator YTeleport()
    {
        Instantiate(teleportStart, Character.transform.position, Quaternion.identity, transform);
        character.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.2f);
        Character.transform.position = Utilities.MousePositionInWorldUnit;
        character.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        Instantiate(teleportFinish, Character.transform.position, Quaternion.identity, transform);
        
    }

    void PutBackIfNeeded()
    {
        int side = Utilities.CheckIfOutOfScreen(Character.Sprite.gameObject, Character.gameObject);
        Debug.Log(side);
        if (side == (int)Utilities.SIDE.LEFT)
        {
            iTween.MoveTo(Character.gameObject, iTween.Hash(
                    "position", new Vector3(Character.MinPositionX - .05f, Character.transform.position.y), 
                    "easetype", Character.putBackMovement, 
                    "time", .4f, 
                    "onupdate", "PlayTapPaticle", "onUpdateTarget", Character.gameObject)
            );
        }
        else if (side == (int)Utilities.SIDE.RIGHT)
        {
            iTween.MoveTo(Character.gameObject, iTween.Hash(
                    "position", new Vector3(Character.MaxPositionX + .05f, Character.transform.position.y),
                    "easetype", Character.putBackMovement,
                    "time", .4f, 
                    "onupdate", "PlayTapPaticle", "onUpdateTarget", Character.gameObject)
            );
        }
    }

    public void Rotate()
    {
        float diffrence = Character.CurrentPosition.x - Utilities.MousePositionInWorldUnit.x;
        iTween.RotateTo(Character.gameObject, iTween.Hash(
                "rotation", diffrence < 0 ? new Vector3(0, 0, -45) : new Vector3(0, 0, 45),
                "easetype", Character.movement, 
                "time", .2f,
                "oncomplete", "Reset", "onCompleteTarget", gameObject
            )
        );
    }

    public void Reset()
    {
        Debug.Log("Reset rotation");
        iTween.RotateTo(Character.gameObject, iTween.Hash(
                "rotation", Vector3.zero,
                "easetype", Character.movement, 
                "time", .3f
            )
        );
    }
}
