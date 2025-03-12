using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private string levelToLoad;

    public AudioSource ambience;
    public AudioSource sfx;
    public AudioSource music;

    static float maxSFXVolume;
    static float maxMusicVolume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if(SceneManager.GetActiveScene().name == "Level01" || SceneManager.GetActiveScene().name == "Level02" || SceneManager.GetActiveScene().name == "Level03")
        {
            StartCoroutine(MusicFadeIn());
            StartCoroutine(SFXFadeIn());
            StartCoroutine(AmbienceFadeIn());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "OptionsMenu")
        {
            maxSFXVolume = sfx.volume;
            maxMusicVolume = music.volume;
        }
    }


    public void FadeToLevel(string levelName)
    {
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
        Invoke("OnFadeComplete", 1.0f);
        if(SceneManager.GetActiveScene().name == "Level01" || SceneManager.GetActiveScene().name == "Level02" || SceneManager.GetActiveScene().name == "Level03")
        {
            StartCoroutine(MusicFadeOut());
            StartCoroutine(SFXFadeOut());
            StartCoroutine(AmbienceFadeOut());
        }
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    IEnumerator MusicFadeOut()
    {
        while(music.volume > 0)
        {
            music.volume -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator SFXFadeOut()
    {
        while(sfx.volume > 0)
        {
            sfx.volume -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator AmbienceFadeOut()
    {
        while(ambience.volume > 0)
        {
            ambience.volume -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator MusicFadeIn()
    {
        while(music.volume < maxMusicVolume)
        {
            music.volume += 0.005f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator SFXFadeIn()
    {
        while(sfx.volume < maxSFXVolume)
        {
            sfx.volume += 0.005f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator AmbienceFadeIn()
    {
        while(ambience.volume < maxSFXVolume)
        {
            ambience.volume += 0.005f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
