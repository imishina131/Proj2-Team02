using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseAndExplode : MonoBehaviour
{
    public Animator animator;
    public GameObject timerObject;
    public GameObject confetti;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        confetti.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        animator.SetTrigger("Die");
        timerObject.SetActive(false);
        Typer.initialized = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Invoke("Confetti", 2.0f);
    }

    void Confetti()
    {
        confetti.SetActive(true);
        Invoke("Restart", 1.5f); 
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
