using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDied : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject effectToSpawn;
    public int health;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        health = 1;
    }

    void Update()
    {
        if(health<=0)
        {
            Instantiate(effectToSpawn, transform.position, Quaternion.identity);
            gameManager.GetComponent<GameManager>().spawnedEnemies--;
            gameManager.GetComponent<GameManager>().IncreaseScore(50);
            Destroy(gameObject);
        }
    }
    public void CheckDie()
    {
        health -= 1;
    }
}
