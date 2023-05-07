using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject playerShip;
    private PlayerMovement playerMovement;

    public int score;
    public TextMeshProUGUI scoreText;
    public int highScore;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        playerShip = GameObject.Find("Player");
        playerMovement = playerShip.GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        UpdateHighScoreText();

        if (playerMovement.numberOfLifes == 4)
        {
            GameObject life1 = GameObject.Find("Pilot");
            life1.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
            GameObject life2 = GameObject.Find("Pilot (1)");
            life2.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
            GameObject life3 = GameObject.Find("Pilot (2)");
            life3.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
            return;
        }
        else if (playerMovement.numberOfLifes == 3)
        {
            GameObject life1 = GameObject.Find("Pilot");
            life1.GetComponent<Image>().color = new Color32(255, 255, 225, 000);
            GameObject life2 = GameObject.Find("Pilot (1)");
            life2.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
            GameObject life3 = GameObject.Find("Pilot (2)");
            life3.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }
        else if (playerMovement.numberOfLifes == 2)
        {
            GameObject life1 = GameObject.Find("Pilot");
            life1.GetComponent<Image>().color = new Color32(255, 255, 225, 000);
            GameObject life2 = GameObject.Find("Pilot (1)");
            life2.GetComponent<Image>().color = new Color32(255, 255, 225, 000);
            GameObject life3 = GameObject.Find("Pilot (2)");
            life3.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }
        else if (playerMovement.numberOfLifes == 1)
        {
            GameObject life1 = GameObject.Find("Pilot");
            life1.GetComponent<Image>().color = new Color32(255, 255, 225, 000);
            GameObject life2 = GameObject.Find("Pilot (1)");
            life2.GetComponent<Image>().color = new Color32(255, 255, 225, 000);
            GameObject life3 = GameObject.Find("Pilot (2)");
            life3.GetComponent<Image>().color = new Color32(255, 255, 225, 000);
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = $"{PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
