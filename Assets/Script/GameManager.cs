using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    //var,field for the score
    public int score;

    //var,field for the highscore
    public int highscore;

    //var,field for the text of the score
    public Text scoreText;

    //var, field for text highscore
    public Text highscoreText;

    [Header("GameOver")]
    //var,field for the gameover panel
    public GameObject gameOverPanel;

    //var,field for score of gameover panel
    public Text gameOverPanelScoreText;

    //var,field for highscore of gameover panel
    public Text gameOverPanelHighScoreText;

    private void Awake()
    {
        //start ads services
        Advertisement.Initialize("5418579");
        //deactivate panel
        gameOverPanel.SetActive(false);
        GetHighScore();
    }

    //get dat highscore
    private void GetHighScore()
    {
        //retreive highscore from playerprefs
        highscore = PlayerPrefs.GetInt("Highscore");
        //display highscore in the text
        highscoreText.text = "Best: " + highscore;
    }

    //increase score and update the text when it's called
    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

        //check score to determine if worth saving
        if(score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = score.ToString();
        }
    }

    //stop the game when bomb is hit
    public void OnBombHit() 
    {
        //show ads bomb is hit
        Advertisement.Load("5418579");
        Time.timeScale = 0;
        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanelHighScoreText.text = "Best: " + PlayerPrefs.GetInt("Highscore").ToString();
        gameOverPanel.SetActive(true);

        Debug.Log("bomb was hit");
    }

    //restart game
    public void RestartGame()
    {
        //reset scores
        score = 0;
        scoreText.text = score.ToString();

        //desactivate panel
        gameOverPanel.SetActive(false );

        //destroy all interactables
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }
        
        //restart game
        Time.timeScale = 1;
    }

}
