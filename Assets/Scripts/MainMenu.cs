using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayPanel;

    public void StartGame() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Level1"); 
    }

    public void ShowHowToPlay() { 
        howToPlayPanel.SetActive(true); 

    }
    public void CloseHowToPlay() { 
        howToPlayPanel.SetActive(false);

    }
    public void QuitGame() { 
        Application.Quit(); 
    }
}
