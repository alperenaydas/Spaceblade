using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;

public class LevelManager : MonoBehaviour
{
    public GameObject gameManager;
    public Text levelText;
    private GameObject trailField;
    public GameObject LevelTransUI;
    public Text levelNumberText;
    public int levelNumber = 0;
    bool levelFinished = false;
    public PathCreator path1_1;
    public PathCreator path1_2;
    public PathCreator path2_1;
    public PathCreator path2_2;
    public PathCreator path3_1;
    public PathCreator path3_2;
    public PathCreator path4_1;
    public PathCreator path4_2;
    public PathCreator path5_1;
    public PathCreator path6_1;
    public PathCreator path6_2;
    public GameObject enemy1;
    public GameObject enemy2;
    public Vector2[] LevelOnePositions = new Vector2[16];
    public Vector2[] LevelTwoPositions = new Vector2[16];
    public Vector2[] LevelThreePositions = new Vector2[16];
    public Vector2[] LevelFourPositions = new Vector2[16];
    public Vector2[] LevelFivePositions = new Vector2[16];
    public Vector2[] LevelSixPositions = new Vector2[16];
    private int currentLevel = 0;

    public AudioSource source;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;


    public int currentEnemy = -1;
    public int totalLevel = 6;


    void Start()
    {
        trailField = GameObject.FindGameObjectWithTag("Trailfield");
    }

    void Update()
    {
        CheckLevelFinish();
    }

    void LevelOne()
    {        
        LevelOnePositions[0] = new Vector2(7, 3);
        LevelOnePositions[1] = new Vector2(-7, 3);
        LevelOnePositions[2] = new Vector2(6, 2);
        LevelOnePositions[3] = new Vector2(-6, 2);
        LevelOnePositions[4] = new Vector2(5, 3);
        LevelOnePositions[5] = new Vector2(-5, 3);
        LevelOnePositions[6] = new Vector2(5, 1);
        LevelOnePositions[7] = new Vector2(-5, 1);
        LevelOnePositions[8] = new Vector2(4, 2);
        LevelOnePositions[9] = new Vector2(-4, 2);
        LevelOnePositions[10] = new Vector2(3, 1);
        LevelOnePositions[11] = new Vector2(-3, 1);
        LevelOnePositions[12] = new Vector2(3, 3);
        LevelOnePositions[13] = new Vector2(-3, 3);
        LevelOnePositions[14] = new Vector2(2, 2);
        LevelOnePositions[15] = new Vector2(-2, 2);
        levelFinished = false;
        StartCoroutine(spawnEnemyLevelOne(enemy1));
    }

    void LevelTwo()
    {
        LevelTwoPositions[0] = new Vector2(-7, 3);
        LevelTwoPositions[1] = new Vector2(7, 3);
        LevelTwoPositions[2] = new Vector2(-6, 2);
        LevelTwoPositions[3] = new Vector2(6, 2);
        LevelTwoPositions[4] = new Vector2(-5, 3);
        LevelTwoPositions[5] = new Vector2(5, 3);
        LevelTwoPositions[6] = new Vector2(-5, 1);
        LevelTwoPositions[7] = new Vector2(5, 1);
        LevelTwoPositions[8] = new Vector2(-4, 2);
        LevelTwoPositions[9] = new Vector2(4, 2);
        LevelTwoPositions[10] = new Vector2(-3, 1);
        LevelTwoPositions[11] = new Vector2(3, 1);
        LevelTwoPositions[12] = new Vector2(-3, 3);
        LevelTwoPositions[13] = new Vector2(3, 3);
        LevelTwoPositions[14] = new Vector2(-2, 2);
        LevelTwoPositions[15] = new Vector2(2, 2);
        levelFinished = false;
        StartCoroutine(spawnEnemyLevelTwo(enemy1));
    }
    void LevelThree()
    {
        LevelThreePositions[0] = new Vector2(-7, 3);
        LevelThreePositions[1] = new Vector2(7, 3);
        LevelThreePositions[2] = new Vector2(-6, 2);
        LevelThreePositions[3] = new Vector2(6, 2);
        LevelThreePositions[4] = new Vector2(-5, 3);
        LevelThreePositions[5] = new Vector2(5, 3);
        LevelThreePositions[6] = new Vector2(-5, 1);
        LevelThreePositions[7] = new Vector2(5, 1);
        LevelThreePositions[8] = new Vector2(-4, 2);
        LevelThreePositions[9] = new Vector2(4, 2);
        LevelThreePositions[10] = new Vector2(-3, 1);
        LevelThreePositions[11] = new Vector2(3, 1);
        LevelThreePositions[12] = new Vector2(-3, 3);
        LevelThreePositions[13] = new Vector2(3, 3);
        LevelThreePositions[14] = new Vector2(-2, 2);
        LevelThreePositions[15] = new Vector2(2, 2);
        levelFinished = false;
        StartCoroutine(spawnEnemyLevelThree(enemy1));
    }

    void LevelFour()
    {
        LevelFourPositions[0] = new Vector2(-7, 3);
        LevelFourPositions[1] = new Vector2(7, 3);
        LevelFourPositions[2] = new Vector2(-6, 2);
        LevelFourPositions[3] = new Vector2(6, 2);
        LevelFourPositions[4] = new Vector2(-5, 3);
        LevelFourPositions[5] = new Vector2(5, 3);
        LevelFourPositions[6] = new Vector2(-5, 1);
        LevelFourPositions[7] = new Vector2(5, 1);
        LevelFourPositions[8] = new Vector2(-4, 2);
        LevelFourPositions[9] = new Vector2(4, 2);
        LevelFourPositions[10] = new Vector2(-3, 1);
        LevelFourPositions[11] = new Vector2(3, 1);
        LevelFourPositions[12] = new Vector2(-3, 3);
        LevelFourPositions[13] = new Vector2(3, 3);
        LevelFourPositions[14] = new Vector2(-2, 2);
        LevelFourPositions[15] = new Vector2(2, 2);
        levelFinished = false;
        StartCoroutine(spawnEnemyLevelFour(enemy2));
    }

    void LevelFive()
    {
        LevelFivePositions[0] = new Vector2(-7, 3);
        LevelFivePositions[1] = new Vector2(7, 3);
        LevelFivePositions[2] = new Vector2(-6, 2);
        LevelFivePositions[3] = new Vector2(6, 2);
        LevelFivePositions[4] = new Vector2(-5, 3);
        LevelFivePositions[5] = new Vector2(5, 3);
        LevelFivePositions[6] = new Vector2(-5, 1);
        LevelFivePositions[7] = new Vector2(5, 1);
        LevelFivePositions[8] = new Vector2(-4, 2);
        LevelFivePositions[9] = new Vector2(4, 2);
        LevelFivePositions[10] = new Vector2(-3, 1);
        LevelFivePositions[11] = new Vector2(3, 1);
        LevelFivePositions[12] = new Vector2(-3, 3);
        LevelFivePositions[13] = new Vector2(3, 3);
        LevelFivePositions[14] = new Vector2(-2, 2);
        LevelFivePositions[15] = new Vector2(2, 2);
        levelFinished = false;
        StartCoroutine(spawnEnemyLevelFive(enemy2));
    }

    void LevelSix()
    {
        LevelFivePositions[0] = new Vector2(-7, 3);
        LevelFivePositions[1] = new Vector2(7, 3);
        LevelFivePositions[2] = new Vector2(-6, 2);
        LevelFivePositions[3] = new Vector2(6, 2);
        LevelFivePositions[4] = new Vector2(-5, 3);
        LevelFivePositions[5] = new Vector2(5, 3);
        LevelFivePositions[6] = new Vector2(-5, 1);
        LevelFivePositions[7] = new Vector2(5, 1);
        LevelFivePositions[8] = new Vector2(-4, 2);
        LevelFivePositions[9] = new Vector2(4, 2);
        LevelFivePositions[10] = new Vector2(-3, 1);
        LevelFivePositions[11] = new Vector2(3, 1);
        LevelFivePositions[12] = new Vector2(-3, 3);
        LevelFivePositions[13] = new Vector2(3, 3);
        LevelFivePositions[14] = new Vector2(-2, 2);
        LevelFivePositions[15] = new Vector2(2, 2);
        levelFinished = false;
        StartCoroutine(spawnEnemyLevelSix(enemy2));
    }

    void CheckLevelFinish()
    {
        if (gameManager.GetComponent<GameManager>().spawnedEnemies == 0 && currentLevel == levelNumber)
        {
            if (levelNumber%3==0)
            {
                currentEnemy++;
                if (levelNumber % 6 == 0)
                {
                    currentEnemy = 0;
                }
                levelNumber++;
                StartCoroutine(WaitingWarp());
            }
            else
            {
                levelNumber++;
                StartCoroutine(WaitForLevelWithoutWarp());
            }
        }
        if(levelFinished)
        {
            levelText.text = levelNumber.ToString("0000");
            levelNumberText.text = "LEVEL " + (levelNumber+1).ToString();
            if (levelNumber% totalLevel == 1)
            {
                currentLevel = levelNumber;
                LevelOne();
            }
            else if (levelNumber% totalLevel == 2)
            {
                currentLevel = levelNumber;
                LevelTwo();
            }
            else if (levelNumber% totalLevel == 3)
            {
                currentLevel = levelNumber;
                LevelThree();
            }
            else if (levelNumber% totalLevel == 4)
            {
                currentLevel = levelNumber;
                LevelFour();
            }
            else if (levelNumber% totalLevel == 5)
            {
                currentLevel = levelNumber;
                LevelFive();
            }
            else if (levelNumber% totalLevel == 0 && levelNumber != 0) // son bölümün if statement'ı bu şekilde olmalı.
            {
                currentLevel = levelNumber;
                LevelSix();
            }
        }
    }

    IEnumerator WaitingWarp()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(WaitForWarp());
    }

    IEnumerator WaitForWarp()
    {
        StartCoroutine(trailField.GetComponent<TrailController>().WarpStart());
        yield return new WaitForSeconds(7f);
        StartCoroutine(WaitForLevel());
    }

    IEnumerator WaitForLevelWithoutWarp()
    {
        yield return new WaitForSeconds(3f);
        LevelTransUI.SetActive(true);
        int i = Random.Range(1, 4);
        if(i==1)
        {
            source.PlayOneShot(clip1);
        }
        else if(i==2)
        {
            source.PlayOneShot(clip2);
        }
        else if(i==3)
        {
            source.PlayOneShot(clip3);
        }
        else
        {
            Debug.Log("error occured");
        }
        yield return new WaitForSeconds(2.5f);
        LevelTransUI.SetActive(false);
        levelFinished = true;
    }

    IEnumerator WaitForLevel()
    {
        LevelTransUI.SetActive(true);
        int i = Random.Range(1, 4);
        if (i == 1)
        {
            source.PlayOneShot(clip1);
        }
        else if (i == 2)
        {
            source.PlayOneShot(clip2);
        }
        else if (i == 3)
        {
            source.PlayOneShot(clip3);
        }
        else
        {
            Debug.Log("error occured");
        }
        yield return new WaitForSeconds(2.5f);
        LevelTransUI.SetActive(false);
        levelFinished = true;
    }

    IEnumerator spawnEnemyLevelOne(GameObject enemy)
    {
        for (int i = 1; i < 17; i++)
        {
            enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().afterPath = LevelOnePositions[i-1];
            if (i % 2 == 0)
            {
                enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().pathCreator = path1_1;
                gameManager.GetComponent<GameManager>().spawnedEnemies++;
                Instantiate(enemy);
            }
            else
            {
                enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().pathCreator = path1_2;
                gameManager.GetComponent<GameManager>().spawnedEnemies++;
                Instantiate(enemy);
            }
            if(i%2==0)
            {
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    IEnumerator spawnEnemyLevelTwo(GameObject enemy)
    {
        for (int i = 1; i < 17; i++)
        {
            enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().afterPath = LevelOnePositions[i - 1];
            if (i % 2 == 0)
            {
                enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().pathCreator = path2_1;
                gameManager.GetComponent<GameManager>().spawnedEnemies++;
                Instantiate(enemy);
            }
            else
            {
                enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().pathCreator = path2_2;
                gameManager.GetComponent<GameManager>().spawnedEnemies++;
                Instantiate(enemy);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator spawnEnemyLevelThree(GameObject enemy)
    {
        for (int i = 1; i < 17; i++)
        {
            enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().afterPath = LevelOnePositions[i - 1];
            if (i % 2 == 0)
            {
                enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().pathCreator = path3_1;
                gameManager.GetComponent<GameManager>().spawnedEnemies++;
                Instantiate(enemy);
            }
            else
            {
                enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().pathCreator = path3_2;
                gameManager.GetComponent<GameManager>().spawnedEnemies++;
                Instantiate(enemy);
            }
            yield return new WaitForSeconds(0.15f);
        }
    }

    IEnumerator spawnEnemyLevelFour(GameObject enemy)
    {
        for (int i = 1; i < 17; i++)
        {
            enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().afterPath = LevelOnePositions[i - 1];
            if (i % 2 == 0)
            {
                enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().pathCreator = path4_1;
                gameManager.GetComponent<GameManager>().spawnedEnemies++;
                Instantiate(enemy);
            }
            else
            {
                enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().pathCreator = path4_2;
                gameManager.GetComponent<GameManager>().spawnedEnemies++;
                Instantiate(enemy);
            }
            yield return new WaitForSeconds(0.15f);
        }
    }

    IEnumerator spawnEnemyLevelFive(GameObject enemy)
    {
        for (int i = 1; i < 17; i++)
        {
            enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().afterPath = LevelOnePositions[i - 1];
            enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().pathCreator = path5_1;
            gameManager.GetComponent<GameManager>().spawnedEnemies++;
            Instantiate(enemy);
            yield return new WaitForSeconds(0.15f);
        }
    }

    IEnumerator spawnEnemyLevelSix(GameObject enemy)
    {
        for (int i = 1; i < 17; i++)
        {
            enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().afterPath = LevelOnePositions[i - 1];
            if (i % 2 == 0)
            {
                enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().pathCreator = path6_1;
                gameManager.GetComponent<GameManager>().spawnedEnemies++;
                Instantiate(enemy);
            }
            else
            {
                enemy.transform.GetChild(0).gameObject.GetComponent<EnemyFollowPath>().pathCreator = path6_2;
                gameManager.GetComponent<GameManager>().spawnedEnemies++;
                Instantiate(enemy);
            }
            yield return new WaitForSeconds(0.15f);
        }
    }
}
