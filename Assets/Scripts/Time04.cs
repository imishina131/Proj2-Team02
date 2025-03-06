using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Time04 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("MainMenu");
    }
}
