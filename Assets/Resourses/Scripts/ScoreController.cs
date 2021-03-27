using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreController : MonoBehaviour
{
    int player1Score = 0;
    int player2Score = 0;

    public GameObject player1ScoreText;
    public GameObject player2ScoreText;

    public int goalsToWin;


    // Update is called once per frame
    void Update()
    {
        if(this.player1Score >= this.goalsToWin || this.player2Score >= this.goalsToWin)
        {
            Debug.Log("Game Won");
            SceneManager.LoadScene("GameOver");
        }

    }

    private void FixedUpdate()
    {
        Text player1ScoreUI = this.player1ScoreText.GetComponent<Text>();
        player1ScoreUI.text = this.player1Score.ToString();
        
        Text player2ScoreUI = this.player2ScoreText.GetComponent<Text>();
        player2ScoreUI.text = this.player2Score.ToString();
    }

    public void Player1Goal()
    {
        this.player1Score++;
    }

    public void Player2Goal()
    {
        this.player2Score++;
    }
}
