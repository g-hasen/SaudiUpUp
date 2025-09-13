using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 60f;

    public TMP_Text timerText;
    public TMP_Text gemsText;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject pausePanel;

    private int collected = 0;
    private int gemsInLevel;
    private float timeLeft;
    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f;
        gemsInLevel = FindObjectsOfType<Collectible>().Length;
        timeLeft = timeLimit;
        UpdateUI();


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (winPanel.activeSelf || losePanel.activeSelf) 
            return;


        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            LoseGame();
        }


        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            TogglePause();
        }

        UpdateUI();
    }

    public void CollectGem()
    {
        collected++;
        if (collected >= gemsInLevel)
            WinGame();
        UpdateUI();
    }

    void UpdateUI()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
        gemsText.text = "Brooches: " + collected + "/" + gemsInLevel;
    }

    void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
        ShowCursor();
    }

    void LoseGame()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
        ShowCursor();
    }


    public void NextLevel() { 
        Time.timeScale = 1f; SceneManager.LoadScene("Level2"); 
    }

    public void PlayAgain() { 
        Time.timeScale = 1f; SceneManager.LoadScene("Level1"); 
    }

    public void RetryLevel() {
        Time.timeScale = 1f; SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu() { 
        Time.timeScale = 1f; SceneManager.LoadScene("MainMenu");
    }


    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;

        if (isPaused) 
            ShowCursor();
        else HideCursor();
    }

    void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
