using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour 
{
    public PowerUps teleportPowerup;

    void OnEnable()
    {
        int temp = Random.Range(0, 100);
        if (temp < 5)
        {
            Instantiate(teleportPowerup, transform.position, Quaternion.identity, transform);
        }
    }

    void OnDisable()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
