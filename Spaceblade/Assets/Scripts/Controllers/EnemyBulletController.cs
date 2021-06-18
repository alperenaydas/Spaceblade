using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    float velocity = -4f;


    void Update()
    {
        transform.position += transform.up * velocity * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerCollider")
        {            
            other.transform.parent.gameObject.SetActive(false);
            Destroy(transform.parent.gameObject);
        }
    }
}
