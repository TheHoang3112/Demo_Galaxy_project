using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image liveImageDisplay;
    public GameObject titleGamePlay;
    public Text scoreText;
    public int score;
    public Text _gameOverText;

    
    public void UpdateLives(int currentLives)
    {
        liveImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }
  
    //public void ShowTitleGamePlay()
    //{
       //_gameOverText.text = " GAME OVER";
    //}

    public void HideTitleGamePlay()
    {
        titleGamePlay.SetActive(false);
        scoreText.text = "Score: ";
    }
}
