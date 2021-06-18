using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    public int lives = 2;

    public GameObject player;
    public GameObject dieVFX;
    public GameObject gameOverMenu;
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;
    private bool ressurecting = false;
    private bool gameOver = false;

    public AudioSource source;
    public AudioClip newMusic;
    

    void Update()
    {
        if(!player.gameObject.activeSelf && !ressurecting)
        {
            if (lives > 0)
            {
                StartCoroutine(Ressurect());
            }
            else
            {
                if(!gameOver)
                {
                    StartCoroutine(GameOver());
                }
            }
        }
        if(lives == 3)
        {
            live1.SetActive(true);
            live2.SetActive(true);
            live3.SetActive(true);
        }
        else if(lives == 2)
        {
            live1.SetActive(true);
            live2.SetActive(true);
            live3.SetActive(false);
        }
        else if (lives == 1)
        {
            live1.SetActive(true);
            live2.SetActive(false);
            live3.SetActive(false);
        }
        else if (lives == 0)
        {
            live1.SetActive(false);
            live2.SetActive(false);
            live3.SetActive(false);
        }
    }

    IEnumerator Ressurect()
    {
        ressurecting = true;
        GameObject destr = Instantiate(dieVFX, player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        Destroy(destr);
        player.gameObject.SetActive(true);
        lives--;
        Debug.Log(lives);
        Vector3 oldPos = player.transform.position;
        player.transform.position = new Vector3(0f, oldPos.y, oldPos.z);
        ressurecting = false;
    }

    public IEnumerator GameOver()
    {
        for (int i = 0; i < player.transform.childCount; i++)
        {
            GameObject child = player.transform.GetChild(i).gameObject;
            if (child != null)
            {
                child.SetActive(false);
            }
        }
        gameOver = true;
        GameObject destr = Instantiate(dieVFX, player.transform.position, Quaternion.identity);
        Time.timeScale = 0.8f;
        source.pitch = 0.8f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0.5f;
        source.pitch = 0.5f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        yield return new WaitForSeconds(2f);
        int score = GetComponent<GameManager>().score;
        gameOverMenu.SetActive(true);
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            gameOverMenu.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            PlayerPrefs.SetInt("Highscore", score);
        }
        source.Stop();
        source.clip = newMusic;
        source.pitch = 1f;
        source.Play();
        Time.timeScale = 0f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        Destroy(destr);
        yield return new WaitForSeconds(60f);
    }
}
