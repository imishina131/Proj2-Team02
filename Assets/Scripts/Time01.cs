using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Time01 : MonoBehaviour
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
        yield return new WaitForSeconds(26);
        SceneManager.LoadScene("Level01");
    }
}
