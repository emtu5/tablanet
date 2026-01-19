using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject helpMenu;
    public GameObject optionsMenu;
    public GameObject scoreMenu;
    public Button pauseButton;

    public void PlayGame()
    {
        Debug.Log("PlayGame");
        SceneManager.LoadScene("Assets/Scenes/TestScene.unity");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }

    public void QuitToMenu() {
        Debug.Log("QuitMenu");
        GameManager.Instance.GoToMenu();
    }

    public void PauseMenu() {
        Debug.Log("Pause");
        GameManager.Instance.paused = true;
        pauseMenu.SetActive(true);
        // pauseButton.interactable = false;
    }

    public void Resume() {
        Debug.Log("Resume");
        GameManager.Instance.paused = false;
        pauseMenu.SetActive(false);
        // pauseButton.interactable = true;
    }
    
    public void Options()
    {
        // spawn options panel
        Debug.Log("Options");
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }

    public void Scores()
    {
        // spawn scores panel
        Debug.Log("Scores");
    }

    public void HowToPlay()
    {
        // spawn help panel
        Debug.Log("HowToPlay");
        helpMenu.SetActive(!helpMenu.activeSelf);
    }
}
