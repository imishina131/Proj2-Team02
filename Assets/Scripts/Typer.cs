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
    static int interactionsCount;
    int dialogueCount = 0;
    bool nextDialogue;
    public GameObject interaction03;

    string[] level01Dialogue01 = new string[] {"yes ma'am", "just gotta get through this workday and get home."};
    string level01Dialogue02 = "dang it, it's out of ink. gotta go and grab some.";
    string[] level01Dialogue03 = new string[] {"i'm getting the printer ink now.", "yeah, yeah, i am working on it."};
    string[] level01Dialogue04 = new string[] {"good afternoon.", "you probably have the wrong desk.", "yeah... that's me."};
    string[] level01Dialogue05 = new string[] {"right here, sir.", "sorry i was short on time.", "nothing, it won't happen again sir. i apologize.", "the burger is probably bigger than you."};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.typing = true;
        SetCurrentWord();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        Debug.Log("dialogue status: " + interactionsCount);
    }

    void SetCurrentWord()
    {
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
            dialogueCount++;
            Invoke("SetCurrentWord", 2.0f);
            //SetCurrentWord();
        }
        else
        {
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
                    SceneManager.LoadScene("Level02");
                    break;
                
            }
            player.typing = false;
        }
    }
}
