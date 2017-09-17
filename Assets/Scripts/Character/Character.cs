using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static float positionY = -3.5f;

    [SerializeField]
    bool dontDIE;

    public iTween.EaseType movement = iTween.EaseType.easeOutCubic;
    public iTween.EaseType putBackMovement = iTween.EaseType.easeOutExpo;
    public ParticleController tapParticle;
    public ParticleController trailParticle;
    public AudioSource ingameMusic;

    private Vector3 lastPosition;
    private SpriteRenderer sprite;

    #region PROPERTIES

    public float MinPositionX
    {
        get
        {
            return Utilities.ScreenSize.x - Utilities.GetHalfSizeOfObject(Sprite.gameObject);
        }
    }

    public float MaxPositionX
    {
        get
        {
            return Utilities.GetHalfSizeOfObject(Sprite.gameObject) - Utilities.ScreenSize.x;
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

    public SpriteRenderer Sprite
    {
        get
        {
            if (sprite == null)
            {
                sprite = GetComponentInChildren<SpriteRenderer>();
            }
            return sprite;
        }
    }

    #endregion

    void Start()
    {
        iTween.Init(gameObject);
    }

    private IEnumerator Die()
    {
        MenuMusic.Instance.CallFadeOut(ingameMusic);
        StartCoroutine(Shake(.7f, .05f));
        SoundManager.Instance.Play(GameManager.Instance.deathSound.sound, transform.parent.parent.parent, transform.position, GameManager.Instance.deathSound.volume, 0, false);
        if (EventManager.Instance.OnDeath != null)
        {
            EventManager.Instance.OnDeath();
        }
        GameManager.Instance.IsPlaying = false;
        GameManager.Instance.TriggerChangeScreen(UIScreen.Type.GameOver);

        transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = .5f;
        yield return new WaitForSeconds(.5f);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(.4f);
//        transform.parent.position = new Vector3(0, -15, 0);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Obstacle":
                {
                    if (!dontDIE)
                        StartCoroutine(Die());
                }
                break; 
            case "ScoreTrigger":
                {
                    GetComponentInChildren<Animator>().Play("CharacterBurst");
                    StartCoroutine(Shake(.7f, .08f));
                    GameManager.Instance.Score++;
                    if (EventManager.Instance.OnScoreIncreased != null)
                    {
                        EventManager.Instance.OnScoreIncreased();
                    }
//                    Debug.Log(GameManager.Instance.Score);
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

    private IEnumerator Shake(float duration, float magnitude)
    {

        float elapsed = 0.0f;
        Vector3 originalCamPos = Camera.main.transform.position;


        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;          

            float percentComplete = elapsed / duration;         
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;

            x *= magnitude * damper;
            y *= magnitude * damper;

            Camera.main.transform.position = new Vector3(originalCamPos.x + x, originalCamPos.y + y, originalCamPos.z);

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;
    }
}
