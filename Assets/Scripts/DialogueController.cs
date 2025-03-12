using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;
    private bool StartDialogue = true;
    private bool Typing = false;

     void Update()
    {
        if (Typing == false)
        {
            
            if (StartDialogue)
            {
                DialogueAnimator.SetTrigger("Enter");
                StartDialogue = false;
            }
            else
            {
                NextSentence();
            }
            //Typing = true;
        }
        
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        // if (StartDialogue)
        //{
        //  DialogueAnimator.SetTrigger("Enter");
        // StartDialogue = false;
        //  }
        //  else
        //  {
        //     NextSentence();
        // }

        //  }
    }
    private void Awake()
    {
       // if (StartDialogue)
       // {
           // DialogueAnimator.SetTrigger("Enter");
            //StartDialogue = false;
       // }
       // else
       // {
       //     NextSentence();
       // }
        //WriteSentence();
        //NextSentence();
    }
    void NextSentence()
    {
        Typing = true;
        if(Index <= Sentences.Length - 1)
        {
            DialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            //DialogueText.text = "";
            //DialogueAnimator.SetTrigger("Exit");
            //Index = 0;
        }

    }
    IEnumerator WriteSentence()
    {
        foreach (char Character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        //Index++;
    }
}
