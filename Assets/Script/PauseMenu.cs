using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool isPaused = false;

    
    void Start()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Update()
    {
        if (GameManager.instance.IsGameOver()) 
        {
            return; 
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))        
        {
            if (isPaused)
            {
                Resume(); 
            }
            else
            {
                Pause(); 
            }
        }
    }

    
    public void Resume()
    {
        if (GameManager.instance.IsGameOver()) return;
        pausePanel.SetActive(false); 
        Time.timeScale = 1f;         
        isPaused = false;
    }
    
    public void Pause()
    {
        pausePanel.SetActive(true);  
        Time.timeScale = 0f;        
        isPaused = true;
    }
    
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu"); 
    }
}