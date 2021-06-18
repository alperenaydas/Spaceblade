using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShootController : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public Slider bulletSlider;

    private GameObject effectToSpawn;
    public int currentIndex = 0;

    public int totalBullets = 6;

    public bool paused = false;
    public GameObject pauseMenu;
    public GameObject stats;

    //[HideInInspector]
    public int spawnedBullets = 0;
    private GameObject lvlmng;
    private int levelNumber;

    void Start()
    {
        bulletSlider.value = totalBullets;
        effectToSpawn = vfx[0];
        lvlmng = GameObject.FindGameObjectWithTag("LevelManager");
    }

    void Update()
    {
        if(totalBullets > 14)
        {
            totalBullets = 14;
        }
        bulletSlider.value = totalBullets;
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseState();
        }
        if (paused)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(spawnedBullets >= totalBullets)
            {
                return;
            }
            if(spawnedBullets < 0)
            {
                spawnedBullets = 0;
            }
            SpawnVFX(vfx.IndexOf(effectToSpawn));
        }
    }

    void SpawnVFX(int i)
    {
        levelNumber = lvlmng.GetComponent<LevelManager>().levelNumber - 1;
        int totalLevels = lvlmng.GetComponent<LevelManager>().totalLevel;
        if(levelNumber % totalLevels > 0 && levelNumber % totalLevels<= 3)
        {
            effectToSpawn.transform.GetChild(0).GetComponent<CollisionController>().EffectSpawn(0);
        }
        else
        {
            effectToSpawn.transform.GetChild(0).GetComponent<CollisionController>().EffectSpawn(1);
        }
        if (i == 0)
        {
            spawnedBullets++;
            GameObject vfx;
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
        }
        if(i == 1)
        {
            spawnedBullets++;
            GameObject vfx;
            vfx = Instantiate(effectToSpawn, new Vector3(firePoint.transform.position.x-0.2f, firePoint.transform.position.y, firePoint.transform.position.z), Quaternion.identity);
            spawnedBullets++;
            GameObject vfx2;
            vfx2 = Instantiate(effectToSpawn, new Vector3(firePoint.transform.position.x + 0.2f, firePoint.transform.position.y, firePoint.transform.position.z), Quaternion.identity);
        }
    }

    public void BulletChange(int i)
    {
        effectToSpawn = vfx[i];
        currentIndex = i;
    }

    public void PauseState()
    {
        paused = !paused;
        if(paused)
        {
            pauseMenu.SetActive(true);
            Debug.Log("paused");
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.SetActive(false);
            Debug.Log("continue");
            Time.timeScale = 1;
        }
    }

    public void QuitCurrentGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void RetireFromGame()
    {
        PauseState();
        stats.GetComponent<PlayerStatsController>().lives = 0;
        StartCoroutine(stats.GetComponent<PlayerStatsController>().GameOver());
    }


}
