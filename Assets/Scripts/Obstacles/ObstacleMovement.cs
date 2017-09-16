using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    #region FIELDS

    public float speed;
    float timer = 0;

    #endregion

    #region METHODS

    private void Start()
    {
        EventManager.Instance.OnDeath += HandleDeath;
    }

    void HandleDeath()
    {
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        float tempX;
        if (GameManager.Instance.LastXPos > 0)
        {
            tempX = Random.Range(-2.3f, 0f);
        }
        else
        {
            tempX = Random.Range(0f, 2.3f);
        }
        GameManager.Instance.LastXPos = tempX;
        transform.position = new Vector3(tempX, 5.5f, 0);
        StartCoroutine(YMove());
    }

    private IEnumerator YMove()
    {
        while (transform.position.y > -6f)
        {
            if (ObstaclePool.Instance.data.dbValue > 0)
            {
                transform.GetChild(0).localScale = new Vector3(16.94f, Mathf.Clamp(transform.localScale.y * ObstaclePool.Instance.data.dbValue / 10, 1, 3f), 0);
                transform.GetChild(1).localScale = new Vector3(16.94f, Mathf.Clamp(transform.localScale.y * ObstaclePool.Instance.data.dbValue / 10, 1, 3f), 0);
//                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * ObstaclePool.Instance.data.pitchValue / 100, 0);
//                transform.localScale = new Vector3(transform.localScale.x, Mathf.Clamp(transform.localScale.y * ObstaclePool.Instance.data.dbValue / 10, 1, 3f), 0);
            }
            transform.Translate(new Vector3(0, speed, 0));
            yield return null;
        }
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        transform.position = transform.parent.position;
    }

    #endregion
}
