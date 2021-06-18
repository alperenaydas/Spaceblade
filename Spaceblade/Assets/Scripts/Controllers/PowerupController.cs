using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject extrabulletText;
    private GameObject extraspeedText;
    private GameObject doubleshotText;


    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        extrabulletText = gameManager.GetComponent<GameManager>().extrabullet;
        extraspeedText = gameManager.GetComponent<GameManager>().extraspeed;
        doubleshotText = gameManager.GetComponent<GameManager>().doubleshot;
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.03f, transform.position.z);
        transform.Rotate(new Vector3(0f, 2f, 0f));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerCollider")
        {
            Destroy(gameObject);
            if(gameObject.name == "powerup-bullet(Clone)")
            {
                extrabulletText.SetActive(true);
                extraspeedText.SetActive(false);
                doubleshotText.SetActive(false);
                other.gameObject.transform.parent.gameObject.GetComponent<ShootController>().totalBullets++;
            }
            if(gameObject.name == "powerup-speed(Clone)")
            {
                extraspeedText.SetActive(true);
                extrabulletText.SetActive(false);
                doubleshotText.SetActive(false);
                other.gameObject.transform.parent.gameObject.GetComponent<MovementController>().moveSpeed++;
            }
            if(gameObject.name == "powerup-doubleshot(Clone)")
            {
                if(other.gameObject.transform.parent.gameObject.GetComponent<ShootController>().currentIndex == 1)
                {
                    extraspeedText.SetActive(false);
                    doubleshotText.SetActive(false);
                    extrabulletText.SetActive(true);
                    other.gameObject.transform.parent.gameObject.GetComponent<ShootController>().totalBullets++;
                }
                else
                {
                    extraspeedText.SetActive(false);
                    extrabulletText.SetActive(false);
                    doubleshotText.SetActive(true);
                    other.gameObject.transform.parent.gameObject.GetComponent<ShootController>().BulletChange(1);
                }
            }
        }
    }

}

