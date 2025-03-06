using UnityEngine;
using UnityEngine.SceneManagement;

public class Time01 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine()
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene()
    {
        yield return new WaitForSeconds(4);

    }
}
