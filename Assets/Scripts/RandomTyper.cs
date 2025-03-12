using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class RandomTyper : MonoBehaviour
{
    string[] dialogueLevel01 = new string[] {"Yeah... you're supposed to look at the payroll, income, and amount owed over the last quarter.", "No."};
    string[] dialogueLevel02 = new string[] {"Dude, I don't work here.", "*sigh* Middle of isle 2 and on the top shelf."};
    string[] dialogueLevel03 = new string[] {" Aren't you on probation?", "I would not be surprised at this point."};


    public TMP_Text workOutput = null;
    public TMP_Text blackOverlay = null;
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private string typedWord = string.Empty;
    private int numberOfCharacters;
    private int lettersTyped = 0;
    public GameObject interaction;
    static public bool initialized;
    int dialogueCount = 0;
    bool nextDialogue;
    public PlayerInteractions player;
    public RaycastScript eyes;

    public GameObject[] part01;
    public GameObject[] part02;
    public GameObject[] part03;
    public GameObject[] part04;
    public GameObject[] part05;
    public GameObject[] part06;
    public GameObject[] part07;

    int order;
    int order01 = 0;
    int order02 = 0;
    int order03 = 0;
    int order04 = 0;
    int order05 = 0;
    int order06 = 0;
    int order07 = 0;

    float setDifficultyTimer;
    public float timer;
    public bool timerOn;
    public TMP_Text timerOutput;

    public PlayerCam cam;

    public GameObject dontLookGame;

    public DontLookGame dontlook;

    public GameObject npcTalking;

    public LoseAndExplode lose;

    public GameObject lastSentence;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastSentence.SetActive(false);
        npcTalking.SetActive(true);
        cam.LookAt(npcTalking);
        while(order01 < part01.Length)
        {
            part01[order01].SetActive(false);
            order01++;
        }

        while(order02 < part02.Length)
        {
            part02[order02].SetActive(false);
            order02++;
        }

        while(order03 < part03.Length)
        {
            part03[order03].SetActive(false);
            order03++;
        }

        while(order04 < part04.Length)
        {
            part04[order04].SetActive(false);
            order04++;
        }

        while(order05 < part05.Length)
        {
            part05[order05].SetActive(false);
            order05++;
        }

        while(order06 < part06.Length)
        {
            part06[order06].SetActive(false);
            order06++;
        }

        while(order07 < part07.Length)
        {
            part07[order07].SetActive(false);
            order07++;
        }


        if(SceneManager.GetActiveScene().name == "Level01")
        {
            if(MenuController.difficulty == 1)
            {
                setDifficultyTimer = 35f;
            }
            else if(MenuController.difficulty == 2)
            {
                setDifficultyTimer = 30f;
            }
            else if(MenuController.difficulty == 3)
            {
                setDifficultyTimer = 20f;
            }
            else 
            {
                setDifficultyTimer = 60f;
            }
        }
        else if(SceneManager.GetActiveScene().name == "Level02")
        {
            if(MenuController.difficulty == 1)
            {
                setDifficultyTimer = 50f;
            }
            else if(MenuController.difficulty == 2)
            {
                setDifficultyTimer = 40f;
            }
            else if(MenuController.difficulty == 3)
            {
                setDifficultyTimer = 30f;
            }
            else 
            {
                setDifficultyTimer = 60f;
            }
        }
        else if(SceneManager.GetActiveScene().name == "Level03")
        {
            if(MenuController.difficulty == 1)
            {
                setDifficultyTimer = 30f;
            }
            else if(MenuController.difficulty == 2)
            {
                setDifficultyTimer = 25f;
            }
            else if(MenuController.difficulty == 3)
            {
                setDifficultyTimer = 15f;
            }
            else 
            {
                setDifficultyTimer = 80f;
            }
        }
        player.typing = true;
        SetCurrentWord();
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
                updateTimer(timer);
            }
            else
            {
                timer = 0;
                timerOn = false;
                interaction.SetActive(false);
                lose.Explode();
                Invoke("Destroy", 3.0f);
                cam.Stare(npcTalking);
            }
        }
        CheckInput();
    }

    void Destroy()
    {
        npcTalking.SetActive(false);
    }


    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timerOutput.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    void SetCurrentWord()
    {
        timer = setDifficultyTimer;
        timerOn = true;
        lettersTyped = 0;
        nextDialogue = true;
        blackOverlay.text = "";

        if(SceneManager.GetActiveScene().name == "Level01")
        {
            order = 0;
            if(dialogueCount == 0)
            {
                currentWord = dialogueLevel01[dialogueCount];
                while(order < part01.Length)
                {
                    part01[order].SetActive(true);
                    order++;
                }
            }
            if(dialogueCount == 1)
            {
                currentWord = dialogueLevel01[dialogueCount];
                while(order < part02.Length)
                {
                    part02[order].SetActive(true);
                    order++;
                }
                nextDialogue = false;
            }
        }
        else if(SceneManager.GetActiveScene().name == "Level02")
        {
            order = 0;
            currentWord = dialogueLevel02[dialogueCount];
            if(dialogueCount == 0)
            {
                while(order < part01.Length)
                {
                    part01[order].SetActive(true);
                    order++;
                }
            }
            if(dialogueCount == 1)
            {
                while(order < part02.Length)
                {
                    part02[order].SetActive(true);
                    order++;
                }
                nextDialogue = false;
            }
        }
        else if(SceneManager.GetActiveScene().name == "Level03")
        {
            order = 0;
            currentWord = dialogueLevel03[dialogueCount];
            if(dialogueCount == 0)
            {
                while(order < part01.Length)
                {
                    part01[order].SetActive(true);
                    order++;
                }
            }
            if(dialogueCount == 1)
            {
                while(order < part02.Length)
                {
                    part02[order].SetActive(true);
                    order++;
                }
                nextDialogue = false;
            }
        }

        SetRemainingWord(currentWord);
    }


    void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        workOutput.text = remainingWord;
        numberOfCharacters = remainingWord.Length;
    }


    void CheckInput()
    {
        if(Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;
            if(keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
            Debug.Log(keysPressed);
        }
    }

    void EnterLetter(string typedLetter)
    {
        char typedLetterChar = typedLetter[0];
        if(typedLetterChar == currentWord[lettersTyped])
        {
            AddLetter(typedLetter);
            Debug.Log("entered");

            if(IsPhraseComplete())
            {
                ShowWin();
            }
        }
        else if(typedLetterChar != currentWord[lettersTyped])
        {
            if(player.spamRestricted == false)
            {
                dontLookGame.SetActive(true);
                timerOn = false;
            }
        }
    }

    bool IsCorrectLetter(string letter)
    {
        return currentWord.IndexOf(letter) == lettersTyped;
    }

    void AddLetter(string letter)
    {
        blackOverlay.text += letter;
        numberOfCharacters -= 1;
        lettersTyped += 1;
    }

    bool IsPhraseComplete()
    {
        return numberOfCharacters == 0;
    }

    void ShowWin()
    {
        if(nextDialogue == true)
        {
            timerOn = false;
            dialogueCount++;
            Invoke("SetCurrentWord", 1.0f);
        }
        else if(nextDialogue == false)
        {
            order = 0;
            if(SceneManager.GetActiveScene().name == "Level01")
            {
                while(order < part03.Length)
                {
                    part03[order].SetActive(true);
                    order++;
                }
            }
            timerOn = false;
            StartCoroutine(Deactivate());

        }
    }

    IEnumerator Deactivate()
    {
        lastSentence.SetActive(true);
        yield return new WaitForSeconds(4);
        interaction.SetActive(false);
        cam.LookAway();
        npcTalking.SetActive(false);
        player.typing = false;
    }
}
