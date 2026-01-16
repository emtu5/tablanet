using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Assets/Scenes/TestScene.unity");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        
    }

    public void Scores()
    {
        
    }

    public void HowToPlay()
    {
        
    }
}
