using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BulletController : MonoBehaviour
{
    public float lifetime = 5f;

    private VisualEffect vfx;

    float velocity = 5f;
    GameObject player;
    GameObject colliderObject;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        vfx = GetComponent<VisualEffect>();
        colliderObject = gameObject.transform.Find("Collider").gameObject;
    }
    
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        vfx.SetFloat("velocity", velocity);
        StartCoroutine(DestroyThis());
        colliderObject.transform.position += transform.up * velocity * Time.deltaTime;
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(3f);
        DecreaseBullet();
        Destroy(gameObject);
    }

    public void DecreaseBullet()
    {
        player.GetComponent<ShootController>().spawnedBullets--;
    }
}
