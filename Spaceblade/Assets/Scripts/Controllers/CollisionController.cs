using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject levelManager;
    public GameObject[] explosionVFX;
    public GameObject[] powerups;
    public int effectToSpawn = 0;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        EffectSpawn(levelManager.GetComponent<LevelManager>().currentEnemy);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if (Random.Range(0, 100) < 5)
            {
                int i = Random.Range(0, 3);
                Instantiate(powerups[i], other.transform.position, Quaternion.identity);
            }
            //Instantiate(explosionVFX[effectToSpawn], other.transform.position, Quaternion.identity);
            transform.parent.gameObject.GetComponent<BulletController>().DecreaseBullet();
            Destroy(transform.parent.gameObject);
            if(other.gameObject != null)
            {
                other.gameObject.GetComponent<CheckDied>().CheckDie();
            }
        }
    }

    public void EffectSpawn(int i)
    {
        effectToSpawn = i;
    }
}
