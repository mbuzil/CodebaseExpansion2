using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pauseMenuObject;

    void Start()
    {
        DeactivatePauseMenu();
    }

    // Update is called once per frame
    public void ActivatePauseMenu()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonPress");
        pauseMenuObject.SetActive(true);
    }

    public void DeactivatePauseMenu()
    {
        pauseMenuObject.SetActive(false);
    }

    public void SwitchSceneTo(string sceneName)
    {
        //Switches to new scene and plays the proper BGM
        FindObjectOfType<AudioManager>().PlaySound("ButtonPress"); 
        
        Scene currentScene = SceneManager.GetActiveScene();
        FindObjectOfType<AudioManager>().PlayMusic($"{sceneName}BGM");
        
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonPress"); 
        
        Debug.Log("Application has been quit.");
        Application.Quit();
    }
}
