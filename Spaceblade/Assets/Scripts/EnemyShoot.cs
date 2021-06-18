using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyShoot : MonoBehaviour
{
    public VisualEffect vfx;

    bool shootCheck = true;
    void Update()
    {
        if(shootCheck)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        shootCheck = false;
        int i = Random.Range(0, 100);
        if(i<10)
        {
            Vector3 pos = transform.position;
            pos.z = 10f;
            Instantiate(vfx, pos, Quaternion.identity);
        }
        yield return new WaitForSeconds(1f);
        shootCheck = true;
    }
}
