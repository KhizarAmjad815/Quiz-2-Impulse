using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public TMP_Text scoreText;
    public static int score = 0;
    public static bool isGameOver = false;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore()
    {
        if (isGameOver)
        {
            scoreText.text = "Game\n Over!";
        }
        else
        {
            scoreText.text = "Score: \n" + score.ToString();
        }
    }
}
