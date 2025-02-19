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
    public GameObject interaction01;
    public GameObject interaction02;
    public GameObject interaction03;
    public PlayerInteractions player;
    int interactionsCount = 0;
    int dialogueCount = 0;
    bool nextDialogue;

    string[] dialogue01 = new string[] {"yes ma'am", "just gotta get through this workday and get home."};
    string dialogue02 = "dang it, it's out of ink. gotta go and grab some";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCurrentWord();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        Debug.Log("dialogue status: " + nextDialogue);
    }

    void SetCurrentWord()
    {
        lettersTyped = 0;
        nextDialogue = false;
        blackOverlay.text = "";
        //set dialogue
        switch(interactionsCount)
        {
            case 0:
                if(dialogueCount == 0)
                {
                    currentWord = dialogue01[dialogueCount];
                    nextDialogue = true;
                }
                else if(dialogueCount == 1)
                {
                    currentWord = "just gotta get through this workday and get home.";
                    nextDialogue = false;
                }
                break;
            
            case 1:
                currentWord = dialogue02;
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
                    interaction01.SetActive(false);
                    break;

                case 1:
                    interaction02.SetActive(false);
                    break;
                
            }
            interactionsCount ++;
        }
    }
}
