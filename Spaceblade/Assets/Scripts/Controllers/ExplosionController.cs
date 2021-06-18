using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyObject());
    }

    // Update is called once per frame
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
