using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToHelp()
    {
        SceneManager.LoadScene("HelpMenu");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Level01");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
