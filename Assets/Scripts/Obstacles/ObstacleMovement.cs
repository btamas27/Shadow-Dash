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
        transform.position = new Vector3(Random.Range(-2.3f, 2.3f), 5.5f, 0);
        StartCoroutine(YMove());
    }

    private IEnumerator YMove()
    {
        while (transform.position.y > -6f)
        {
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
