using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    public BGScroller background;

    public ParticleSystem startStarField1;
    public ParticleSystem startStarField2;
    public ParticleSystem winStarField1;
    public ParticleSystem winStarField2;

    private bool gameOver;
    private bool restart;
    public int score;

    public AudioSource musicSource;
    public AudioClip bgMusic;
    public AudioClip winMusic;
    public AudioClip loseMusic;

    void Start()
    {
        score = 0;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";

        musicSource.clip = bgMusic;
        musicSource.Play();

        winStarField1.Stop();
        winStarField2.Stop();

        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("Main");
            }
        }

        if(score >= 100 && background.scrollSpeed > -10)
        {
            background.scrollSpeed -= 1 * Time.deltaTime;
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                restartText.text = "Press 'F' for Restart";
                restart = true;
                break;
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score;

        if (score >= 100)
        {
            musicSource.Stop();

            musicSource.clip = winMusic;
            musicSource.Play();

            gameOverText.text = "You win! Game created by Jenna Ward";

            startStarField1.Clear();
            startStarField2.Clear();
            winStarField1.Play();
            winStarField2.Play();

            gameOver = true;
 //           restart = true;
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        musicSource.Stop();

        musicSource.clip = loseMusic;
        musicSource.Play();

        gameOverText.text = "You Lose! Game created by Jenna Ward";
        gameOver = true;
    }
}
