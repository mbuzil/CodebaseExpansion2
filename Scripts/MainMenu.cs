using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SwitchSceneTo(string sceneName)
    {
        //Switches to new scene and plays proper BGM
        FindObjectOfType<AudioManager>().PlaySound("ButtonPress");

        Scene currentScene = SceneManager.GetActiveScene();
        FindObjectOfType<AudioManager>().PlayMusic($"{sceneName}BGM");

        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonPress");
        Debug.Log("Game is become quit.");
        Application.Quit();
    }
}
