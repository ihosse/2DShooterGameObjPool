using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private float timeToAutoDestroy = 2f;

    public void Activate()
    {
        GameObject explosionFX = Instantiate(explosionPrefab.gameObject, transform.position, Quaternion.identity);
        Destroy(explosionFX, timeToAutoDestroy);
    }
}
