using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int currentScore;
    
    void Start()
    {
        scoreText.text = "Score:0";
    }

    public void Addscore(int score)
    {
        currentScore += score;
        scoreText.text = "Score: " + currentScore.ToString();
        
        GameManager.instance.UpdateScore(currentScore);
    }
}
