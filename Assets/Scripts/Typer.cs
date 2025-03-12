using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Typer : MonoBehaviour
{

    //word bank

    public TMP_Text workOutput = null;
    public TMP_Text blackOverlay = null;
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private string typedWord = string.Empty;
    private int numberOfCharacters;
    private int lettersTyped = 0;
    public GameObject interaction;
    public PlayerInteractions player;
    public RaycastScript eyes;
    static int interactionsCount;
    static public bool initialized;
    int dialogueCount = 0;
    bool nextDialogue;
    public GameObject interaction03;
    public GameObject thoughtZone;

    string[] level01Dialogue01 = new string[] {"Yes ma'am", "Just gotta get through this workday and get home."};
    string level01Dialogue02 = "Dang it, it's out of ink. Gotta go and grab some.";
    string[] level01Dialogue03 = new string[] {"I'm getting the printer ink now.", "Yeah, yeah, I am working on it."};
    string[] level01Dialogue04 = new string[] {"Good afternoon.", "You probably have the wrong desk.", "Yeah... that's me."};
    string[] level01Dialogue05 = new string[] {"Right here, sir.", "Sorry I was short on time.", "Nothing, it won't happen again sir. I apologize.", "The burger is probably bigger than you."};

    string level02Dialogue01 = "Alright 3 items on the list for thanksgiving, in and out";
    string level02Dialogue02 = "A turkey? This is feeling a bit illegal to buy.";
    string[] level02Dialogue03 = new string[] {"Oh no, not my neighbor.", "Note? I'm sorry I didn't.", "Its clay. It comes from the ground.", "Sure, won't happen again."};
    string level02Dialogue04 = "A ham? My great aunt was married to a pig, this is so wrong.";
    string[] level02Dialogue05 = new string[] {"Aren't you a sloth? You don't eat meat.", "Sorry didn't mean to offend you.", "Good luck with that."};
    string level02Dialogue06 = "Finally a normal item.";
    string[] level02Dialogue07 = new string[] {"I just said that she doesn't eat meat, she is a sloth.", "I know, and I said I am sorry."};
    string[] level02Dialogue08 = new string[] {"Does everyone in this store know what I said?", "Oh my kibble, what have I done?", "ha ha, good one... here you go.", "***** ***** *****"};

    string[] level03Dialogue01 = new string[] {"*Okay, you can do this. Just get through this dinner and I will be golden.*", "*OH GOD MY STEPMOTHER IS RIDICULING ME! What a cliche...*", "Well I was thinking of a new business venture after my trip to the store recently. Elephant meat! Seems like there is a market for animal meats now.", "*I am going to grab the breadsticks from the counter.*"};
    string[] level03Dialogue02 = new string[] {"Hey, little Jimmy. Don't get too close I am feeling a little sick.", "I don't know what you mean. I am just busy grabbing these breadsticks.", "*OH MY GOD HE KNOWS!*", "No... ha ha ha...", "*Silence*", "*Something is wrong with that kid.*"};
    string[] level03Dialogue03 = new string[] {"Sorry, I have been so busy with work. I really want to visit.", "*What the **** is going on right now.*", "Oh Alright", "*I am going to put away my dish*"};
    string[] level03Dialogue04 = new string[] {"Sure, what do you need?", "What?", "I am awake. What do you mean?", "I got to get out of here!"};
    
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

        if(!initialized)
        {
            if(SceneManager.GetActiveScene().name == "Level01")
            {
                interactionsCount = 0;
            }
            else if(SceneManager.GetActiveScene().name == "Level02")
            {
                interactionsCount = 5;
            }
            else if(SceneManager.GetActiveScene().name == "Level03")
            {
                interactionsCount = 13;
            }
            initialized = true;
        }

        if(SceneManager.GetActiveScene().name == "Level01")
        {
            if(MenuController.difficulty == 1)
            {
                setDifficultyTimer = 35f;
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
                setDifficultyTimer = 90f;
            }
            else if(MenuController.difficulty == 2)
            {
                setDifficultyTimer = 70f;
            }
            else if(MenuController.difficulty == 3)
            {
                setDifficultyTimer = 50f;
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
        Debug.Log("dialogue status: " + interactionsCount);
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
        Debug.Log("word count:" + dialogueCount);
        Debug.Log("interaction count:" + interactionsCount);
        timer = setDifficultyTimer;
        timerOn = true;
        lettersTyped = 0;
        nextDialogue = true;
        blackOverlay.text = "";
        //set dialogue
        switch(interactionsCount)
        {
            case 0:
                order = 0;
                currentWord = level01Dialogue01[dialogueCount];
                if(dialogueCount == 0)
                {
                    while(order < part01.Length)
                    {
                        part01[order].SetActive(true);
                        order++;
                    }
                }
                else if(dialogueCount == 1)
                {
                    while(order < part02.Length)
                    {
                        part02[order].SetActive(true);
                        order++;
                    }
                    nextDialogue = false;
                }
                break;
            
            case 1:
                order = 0;
                while(order < part01.Length)
                {
                    part01[order].SetActive(true);
                    order++;
                }
                currentWord = level01Dialogue02;
                nextDialogue = false;
                break;

            case 2:
                order = 0;
                currentWord = level01Dialogue03[dialogueCount];
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
                break;

            case 3:
                order = 0;
                currentWord = level01Dialogue04[dialogueCount];
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
                        part02[order].SetActive(true);;
                        order++;
                    }
                }
                if(dialogueCount == 2)
                {
                    while(order < part03.Length)
                    {
                        part03[order].SetActive(true);
                        order++;
                    }
                    nextDialogue = false;
                }
                break;

            case 4:
                order = 0;
                currentWord = level01Dialogue05[dialogueCount];
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
                }
                if(dialogueCount == 2)
                {
                    while(order < part03.Length)
                    {
                        part03[order].SetActive(true);
                        order++;
                    }
                }
                if(dialogueCount == 3)
                {
                    while(order < part04.Length)
                    {
                        part04[order].SetActive(true);
                        order++;
                    }
                    nextDialogue = false;
                }
                break;

            case 5:
                order = 0;
                while(order < part01.Length)
                {
                    part01[order].SetActive(true);
                    order++;
                }
                currentWord = level02Dialogue01;
                nextDialogue = false;
                break;

            case 6:
                order = 0;
                while(order < part01.Length)
                {
                    part01[order].SetActive(true);
                    order++;
                }
                currentWord = level02Dialogue02;
                nextDialogue = false;
                break;

            case 7:
                order = 0;
                currentWord = level02Dialogue03[dialogueCount];
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
                }
                if(dialogueCount == 2)
                {
                    while(order < part03.Length)
                    {
                        part03[order].SetActive(true);
                        order++;
                    }
                }
                if(dialogueCount == 3)
                {
                    while(order < part04.Length)
                    {
                        part04[order].SetActive(true);
                        order++;
                    }
                    nextDialogue = false;
                }
                break;

            case 8:
                order = 0;
                while(order < part01.Length)
                {
                    part01[order].SetActive(true);
                    order++;
                }
                currentWord = level02Dialogue04;
                nextDialogue = false;
                break;

            case 9:
                order = 0;
                currentWord = level02Dialogue05[dialogueCount];
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
                }
                if(dialogueCount == 2)
                {
                    while(order < part03.Length)
                    {
                        part03[order].SetActive(true);
                        order++;
                    }
                    nextDialogue = false;
                }
                break;

            case 10:
                order = 0;
                while(order < part01.Length)
                {
                    part01[order].SetActive(true);
                    order++;
                }
                currentWord = level02Dialogue06;
                nextDialogue = false;
                break;

            case 11:
                order = 0;
                currentWord = level02Dialogue07[dialogueCount];
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
                break;

            case 12:
                order = 0;
                currentWord = level02Dialogue08[dialogueCount];
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
                }
                if(dialogueCount == 2)
                {
                    while(order < part03.Length)
                    {
                        part03[order].SetActive(true);
                        order++;
                    }
                }
                if(dialogueCount == 3)
                {
                    while(order < part04.Length)
                    {
                        part04[order].SetActive(true);
                        order++;
                    }
                    nextDialogue = false;
                }
                break;

            case 13:
                order = 0;
                currentWord = level03Dialogue01[dialogueCount];
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
                }
                if(dialogueCount == 2)
                {
                    while(order < part03.Length)
                    {
                        part03[order].SetActive(true);
                        order++;
                    }
                }
                if(dialogueCount == 3)
                {
                    while(order < part04.Length)
                    {
                        part04[order].SetActive(true);
                        order++;
                    }
                    nextDialogue = false;
                }
                break;

            case 14:
                order = 0;
                currentWord = level03Dialogue02[dialogueCount];
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
                }
                if(dialogueCount == 2)
                {
                    while(order < part03.Length)
                    {
                        part03[order].SetActive(true);
                        order++;
                    }
                }
                if(dialogueCount == 3)
                {
                    while(order < part04.Length)
                    {
                        part04[order].SetActive(true);
                        order++;
                    }
                }
                if(dialogueCount == 4)
                {
                    while(order < part05.Length)
                    {
                        part05[order].SetActive(true);
                        order++;
                    }
                }
                if(dialogueCount == 5)
                {
                    while(order < part06.Length)
                    {
                        part06[order].SetActive(true);
                        order++;
                    }
                    nextDialogue = false;
                }
                break;

            case 15:
                order = 0;
                currentWord = level03Dialogue03[dialogueCount];
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
                }
                if(dialogueCount == 2)
                {
                    while(order < part03.Length)
                    {
                        part03[order].SetActive(true);
                        order++;
                    }
                }
                if(dialogueCount == 3)
                {
                    while(order < part04.Length)
                    {
                        part04[order].SetActive(true);
                        order++;
                    }
                    nextDialogue = false;
                }
                break;

            case 16:
                order = 0;
                currentWord = level03Dialogue04[dialogueCount];
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
                }
                if(dialogueCount == 2)
                {
                    while(order < part03.Length)
                    {
                        part03[order].SetActive(true);
                        order++;
                    }
                }
                if(dialogueCount == 3)
                {
                    while(order < part04.Length)
                    {
                        part04[order].SetActive(true);
                        order++;
                    }
                    nextDialogue = false;
                }
                break;

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
            dontLookGame.SetActive(true);
            timerOn = false;
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
        else
        {
            timerOn = false;
            switch(interactionsCount)
            {
                case 0:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 1:
                    player.text03 = true;
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 2:
                    player.text03 = false;
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 3:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 4:
                    StartCoroutine(Deactivate());
                    interactionsCount++;
                    if (SceneManager.GetActiveScene().name == "Level01")
                    {
                        SceneManager.LoadScene("LoadingCutscene");
                    }
                    break;

                case 5:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    nextDialogue = false;
                break;

                case 6:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 7:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 8:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 9:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 10:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 11:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 12:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    SceneManager.LoadScene("LoadingCutscene 1");
                    break;

                case 13:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 14:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 15:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;

                case 16:
                    StartCoroutine(Deactivate());
                    interactionsCount ++;
                    break;
            }
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
