using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    static public int difficulty = 0;

    public LevelChanger transition;

    public PauseMenu pauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            difficulty = 0;
            PlayerInteractions.objectiveCount = 0;
            Typer.interactionsCount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(difficulty);
    }

    public void GoToMainMenu()
    {
        transition.FadeToLevel("MainMenu");
        //SceneManager.LoadScene("MainMenu");
    }

    public void GoToOptionsMenu()
    {
        transition.FadeToLevel("OptionsMenu");
    }

    public void GoToHelp()
    {
        transition.FadeToLevel("HelpMenu");
        //SceneManager.LoadScene("HelpMenu");
    }

    public void GoToCredits()
    {
        transition.FadeToLevel("CreditsMenu");
        //SceneManager.LoadScene("CreditsMenu");
    }

    public void PlayEasy()
    {
        difficulty = 1;
        transition.FadeToLevel("OpeningCutScene");
        //SceneManager.LoadScene("OpeningCutScene");
    }

    public void PlayMedium()
    {
        difficulty = 2;
        transition.FadeToLevel("OpeningCutScene");
        //SceneManager.LoadScene("OpeningCutScene1");
    }

    public void PlayHard()
    {
        difficulty = 3;
        transition.FadeToLevel("OpeningCutScene");
        //SceneManager.LoadScene("OpeningCutScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChooseDifficulty()
    {
        transition.FadeToLevel("DifficultyMenu");
        //SceneManager.LoadScene("DifficultyMenu");
    }

    public void Restart()
    {
        PlayerInteractions.objectiveCount = 0;
        Typer.initialized = false;
        transition.FadeToLevel(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoMainMenuInPause()
    {
        pauseMenu.Resume();
        transition.FadeToLevel("MainMenu");
    }

}
