using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static float positionY = -3.5f;

    public iTween.EaseType movement = iTween.EaseType.easeOutCubic;
    public iTween.EaseType putBackMovement = iTween.EaseType.easeOutExpo;
    public ParticleController tapParticle;
    public ParticleController trailParticle;
    Vector3 lastPosition;

    #region PROPERTIES

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

    #endregion

    void Start()
    {
        iTween.Init(gameObject);
    }

    private IEnumerator Die()
    {
        GameManager.Instance.IsPlaying = false;
        GameManager.Instance.TriggerChangeScreen(UIScreen.Type.GameOver);

        transform.GetChild(0).gameObject.SetActive(false);
        StopTrailParticle();
        StopTapPartice();
        yield return new WaitForSeconds(.4f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Obstacle":
                {
                    StartCoroutine(Die());
                }
                break; 
            case "ScoreTrigger":
                {
                    GameManager.Instance.Score++;
                    Debug.Log(GameManager.Instance.Score);
                }
                break;
        }
    }

    public void PlayTapPaticle()
    {
        tapParticle.transform.position = CurrentPosition;
        tapParticle.Play();
    }

    public void StopTapPartice()
    {
        tapParticle.Stop();
    }

    public void PlayTraiParticle()
    {
        trailParticle.Play();
    }

    public void StopTrailParticle()
    {
        trailParticle.Stop();
    }
}
