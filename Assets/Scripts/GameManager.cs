using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;
    
    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        /*Pause();*/
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        ColumnEnemy[] columnEnemy = FindObjectsOfType<ColumnEnemy>();
        for(int i = 0; i < columnEnemy.Length; i++)
        {
            Destroy(columnEnemy[i].gameObject); 
        }
    }

    public void BackHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        UnPause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        player.enabled = true;
    }
}
