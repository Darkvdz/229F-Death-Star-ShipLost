using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int currentScore;
    
    void Start()
    {
        UpdateScoreDisplay();
    }

    public void Addscore(int score)
    {
        currentScore += score;
        UpdateScoreDisplay();
        
        GameManager.instance.UpdateScore(currentScore);
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + currentScore + "/" + GameManager.instance.targetScore;
    }
}
