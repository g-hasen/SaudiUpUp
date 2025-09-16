using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Level1"); 
    }
    public void QuitGame() { 
        Application.Quit(); 
    }

    //public GameObject howToPlayPanel;
    //public void ShowHowToPlay() { 
    //    howToPlayPanel.SetActive(true); 

    //}
    //public void CloseHowToPlay() { 
    //    howToPlayPanel.SetActive(false);

    //}
}
