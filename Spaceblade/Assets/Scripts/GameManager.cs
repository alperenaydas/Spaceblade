using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int spawnedEnemies = 0;

    public TextMeshProUGUI score_text;
    public TextMeshProUGUI highscore_text;

    public GameObject extrabullet;
    public GameObject extraspeed;
    public GameObject doubleshot;


    public AudioSource source;
    public AudioClip extrabulletClip;
    public AudioClip extraspeedClip;
    public AudioClip doubleshotClip;

    private bool audioPlaying = false;

    void Start()
    {
        highscore_text.text = string.Format("{0:n0}", PlayerPrefs.GetInt("Highscore", 0));
        score_text.text = string.Format("{0:n0}", score);
    }

    void Update()
    {
        if(extrabullet.activeSelf)
        {
            StartCoroutine(destroyText(extrabullet, extrabulletClip));
        }
        if (extraspeed.activeSelf)
        {
            StartCoroutine(destroyText(extraspeed, extraspeedClip));
        }
        if (doubleshot.activeSelf)
        {
            StartCoroutine(destroyText(doubleshot, doubleshotClip));
        }
    }

    public void IncreaseScore(int i)
    {
        score += i;
        score_text.text = string.Format("{0:n0}", score);
        if(PlayerPrefs.GetInt("Highscore", 0) < score)
        {
            highscore_text.text = string.Format("{0:n0}", score);
        }
    }

    public IEnumerator destroyText(GameObject obj, AudioClip clip)
    {
        if(!audioPlaying)
        {
            audioPlaying = true;
            source.clip = clip;
            source.Stop();
            source.Play();
        }
        yield return new WaitForSeconds(1f);
        obj.SetActive(false);
        audioPlaying = false;
    }
}
