using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    static int difficulty = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            difficulty = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(difficulty);
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

    public void PlayEasy()
    {
        difficulty = 1;
        SceneManager.LoadScene("Level01");
    }

    public void PlayMedium()
    {
        difficulty = 2;
        SceneManager.LoadScene("Level01");
    }

    public void PlayHard()
    {
        difficulty = 3;
        SceneManager.LoadScene("Level01");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChooseDifficulty()
    {
        SceneManager.LoadScene("DifficultyMenu");
    }

    public void Restart()
    {
        Typer.initialized = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
