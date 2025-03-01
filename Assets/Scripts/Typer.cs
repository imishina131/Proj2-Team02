using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    string[] level01Dialogue01 = new string[] {"yes ma'am", "just gotta get through this workday and get home."};
    string level01Dialogue02 = "dang it, it's out of ink. gotta go and grab some.";
    string[] level01Dialogue03 = new string[] {"i'm getting the printer ink now.", "yeah, yeah, i am working on it."};
    string[] level01Dialogue04 = new string[] {"good afternoon.", "you probably have the wrong desk.", "yeah... that's me."};
    string[] level01Dialogue05 = new string[] {"right here, sir.", "sorry i was short on time.", "nothing, it won't happen again sir. i apologize.", "the burger is probably bigger than you."};

    string level02Dialogue01 = "alright 3 items on the list for thanksgiving, in and out";
    string level02Dialogue02 = "a turkey? this is feeling a bit illegal to buy.";
    string[] level02Dialogue03 = new string[] {"oh no, not my neighbor.", "note? i'm sorry i didn't.", "its clay. it comes from the ground.", "sure, won't happen again."};
    string level02Dialogue04 = "a ham? my great aunt was married to a pig, this is so wrong.";
    string[] level02Dialogue05 = new string[] {"aren't you a sloth? you don't eat meat.", "sorry didn't mean to offend you.", "good luck with that."};
    string level02Dialogue06 = "finally a normal item.";
    string[] level02Dialogue07 = new string[] {"i just said that she doesn't eat meat, she is a sloth.", "i know, and i said i am sorry."};
    string[] level02Dialogue08 = new string[] {"does everyone in this store know what i said?", "oh my kibble, what have i done?", "ha ha, good one... here you go.", "***** ***** *****"};

    float setDifficultyTimer;
    public float timer;
    public bool timerOn;
    public TMP_Text timerOutput;

    public PlayerCam cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            initialized = true;
        }

        if(SceneManager.GetActiveScene().name == "Level01")
        {
            if(MenuController.difficulty == 1)
            {
                setDifficultyTimer = 25f;
            }
            else if(MenuController.difficulty == 2)
            {
                setDifficultyTimer = 20f;
            }
            else if(MenuController.difficulty == 3)
            {
                setDifficultyTimer = 15f;
            }
            else 
            {
                setDifficultyTimer = 20f;
            }
        }
        else if(SceneManager.GetActiveScene().name == "Level02")
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
                setDifficultyTimer = 20f;
            }
            else 
            {
                setDifficultyTimer = 20f;
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
                eyes.Lose();
            }
        }
        CheckInput();
        Debug.Log("dialogue status: " + interactionsCount);
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
        //set dialogue
        switch(interactionsCount)
        {
            case 0:
                currentWord = level01Dialogue01[dialogueCount];
                if(dialogueCount == 1)
                {
                    nextDialogue = false;
                }
                break;
            
            case 1:
                currentWord = level01Dialogue02;
                nextDialogue = false;
                break;

            case 2:
                currentWord = level01Dialogue03[dialogueCount];
                if(dialogueCount == 1)
                {
                    nextDialogue = false;
                }
                break;

            case 3:
                currentWord = level01Dialogue04[dialogueCount];
                if(dialogueCount == 2)
                {
                    nextDialogue = false;
                }
                break;

            case 4:
                currentWord = level01Dialogue05[dialogueCount];
                if(dialogueCount == 3)
                {
                    nextDialogue = false;
                }
                break;

            case 5:
                currentWord = level02Dialogue01;
                nextDialogue = false;
                break;

            case 6:
                currentWord = level02Dialogue02;
                nextDialogue = false;
                break;

            case 7:
                currentWord = level02Dialogue03[dialogueCount];
                if(dialogueCount == 3)
                {
                    nextDialogue = false;
                }
                break;

            case 8:
                currentWord = level02Dialogue04;
                nextDialogue = false;
                break;

            case 9:
                currentWord = level02Dialogue05[dialogueCount];
                if(dialogueCount == 2)
                {
                    nextDialogue = false;
                }
                break;

            case 10:
                currentWord = level02Dialogue06;
                nextDialogue = false;
                break;

            case 11:
                currentWord = level02Dialogue07[dialogueCount];
                if(dialogueCount == 1)
                {
                    nextDialogue = false;
                }
                break;

            case 12:
                currentWord = level02Dialogue08[dialogueCount];
                if(dialogueCount == 3)
                {
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
            Invoke("SetCurrentWord", 5.0f);
        }
        else
        {
            timerOn = false;
            switch(interactionsCount)
            {
                case 0:
                    interaction.SetActive(false);
                    interactionsCount ++;
                    break;

                case 1:
                    player.text03 = true;
                    interaction.SetActive(false);
                    interactionsCount ++;
                    break;

                case 2:
                    player.text03 = false;
                    interaction.SetActive(false);
                    interactionsCount ++;
                    break;

                case 3:
                    interaction.SetActive(false);
                    interactionsCount ++;
                    break;

                case 4:
                    interaction.SetActive(false);
                    interactionsCount++;
                    if (SceneManager.GetActiveScene().name == "Level01")
                    {
                        SceneManager.LoadScene("Level02");
                    }
                    break;

                case 5:
                    interaction.SetActive(false);
                    interactionsCount ++;
                    nextDialogue = false;
                break;

                case 6:
                    interaction.SetActive(false);
                    interactionsCount ++;
                    break;

                case 7:
                    interaction.SetActive(false);
                    interactionsCount ++;
                    break;

                case 8:
                    interaction.SetActive(false);
                    interactionsCount ++;
                    break;

                case 9:
                    interaction.SetActive(false);
                    interactionsCount ++;
                    break;

                case 10:
                    interaction.SetActive(false);
                    interactionsCount ++;
                    break;

                case 11:
                    interaction.SetActive(false);
                    interactionsCount ++;
                    break;

                case 12:
                    interaction.SetActive(false);
                    interactionsCount ++;
                    SceneManager.LoadScene("MainMenu");
                    break;
                
            }
            player.typing = false;
        }
    }
}
