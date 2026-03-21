using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("GameManager Setting")]
    [SerializeField] private float timelimit = 15.0f;
    [SerializeField] private int targetScore = 50;
    [SerializeField] private int currentScore = 0;
    [SerializeField] public bool isGameOver ;
    
    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        
        Time.timeScale = 1f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            timelimit  -= Time.deltaTime;
            timeText.text = "Time: " + timelimit.ToString("F2");
            
            if (timelimit <= 0)
            {
                timelimit = 0;
                timeText.text = "Time: 0.00";
                EndGame(false);
            }
        }

        
    }

    public void UpdateScore(int score)
    {
        currentScore =  score;
        if (currentScore >= targetScore && !isGameOver)
        {
            EndGame(true);
        }
    }
    
    void EndGame(bool isWin)
    { 
        isGameOver = true;
        Time.timeScale = 0f;

        if (isWin)
        {
            winPanel.SetActive(true);
        }
        else
        {
            gameOverPanel.SetActive(true);
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
