using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Manager")]
    #region VARIABLES
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public BallController ballController;

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public int winPoints = 3;
    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;
    #endregion

    #region CODE
    void Start()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        Debug.Log("A new round has been initialized...");
        playerPaddle.position = new Vector3(-7,0,0);
        enemyPaddle.position = new Vector3(7, 0, 0);

        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer()
    {
        ++playerScore;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        ++enemyScore;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if(enemyScore >= winPoints || playerScore >= winPoints)
        {
            if(enemyScore > playerScore)
            {
                Debug.Log("You've been defeated...");
            }
            else
            {
                Debug.Log("Victory!!!");
            }

            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        
        string winner = SaveController.Instance.GetName(playerScore > enemyScore);
        textEndGame.text = winner + " venceu!!!";
        SaveController.Instance.SaveWinner(winner);
        
        Invoke("LoadMenu", 2f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion
}
