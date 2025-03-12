using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    static public int objectiveCount = 0;
    public TMP_Text objective;
    public GameObject objectiveDisplay;
    public GameObject fBanner;
    public GameObject timer;
    public bool typing;

    bool inMouseZone;
    bool inPaperZone;
    bool inInkZone;
    bool hasFailedPrint;
    bool inTurkeyZone;
    bool inHamZone;
    bool inButterZone;
    bool inCashierZone;
    bool inBreadstickZone;
    bool inTableZone;
    bool inSinkZone;

    bool hasInk;
    bool clickedMouse;
    bool hasTurkey;
    bool hasHam;
    bool hasButter;
    bool hasBreadsticks;
    bool leftBreadsticks;
    bool putDish;
    bool end;

    public GameObject ink;
    public GameObject paper;
    public GameObject turkey;
    public GameObject ham;
    public GameObject butter;

    public GameObject inkInHand;
    public GameObject paperInHand;
    public GameObject turkeyInHand;
    public GameObject hamInHand;
    public GameObject butterInHand;

    public GameObject mouseGlow;
    public GameObject printerGlow;
    public GameObject inkGlow;
    public GameObject turkeyGlow;
    public GameObject hamGlow;
    public GameObject butterGlow;
    public GameObject cashierGlow;

    public GameObject interaction01;
    public GameObject interaction02;
    public GameObject interaction03;
    public GameObject interaction04;
    public GameObject interaction05;
    public GameObject interaction06;
    public GameObject interaction07;
    public GameObject interaction08;


    public GameObject crosshair;

    public bool text03;

    public AudioSource sfxSound;
    public AudioClip mouseClick;
    public AudioClip freezerOpen;
    public AudioClip freezerClose;
    public AudioClip interact;
    public AudioClip printerPrint;
    public AudioClip doorClose;
    public AudioClip doorOpen;

    public GameObject miniMap;
    public GameObject miniMapOutline;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level01")
        {
            paper.SetActive(false);
            inkInHand.SetActive(false);
            paperInHand.SetActive(false);
            mouseGlow.SetActive(false);
            printerGlow.SetActive(false);
            inkGlow.SetActive(false);
            objectiveCount = 0;
        }

        if(SceneManager.GetActiveScene().name == "Level02")
        {
            turkeyInHand.SetActive(false);
            hamInHand.SetActive(false);
            butterInHand.SetActive(false);
            turkeyGlow.SetActive(false);
            hamGlow.SetActive(false);
            butterGlow.SetActive(false);
            cashierGlow.SetActive(false);
            objectiveCount = 4;
        }

        if(SceneManager.GetActiveScene().name == "Level03")
        {

            objectiveCount = 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(MenuController.difficulty == 3)
        {
            miniMap.SetActive(false);
            miniMapOutline.SetActive(false);
        }
        UpdateObjective();
        Debug.Log("in ink:" + inInkZone);
        if(text03 == true)
        {
            interaction03.SetActive(true);
        }
        if(!typing)
        {
            Debug.Log("not hidden");
            objectiveDisplay.SetActive(true);
            crosshair.SetActive(true);
            timer.SetActive(false);

        }
        else if(typing)
        {
            Debug.Log("hidden");
            objectiveDisplay.SetActive(false);
            fBanner.SetActive(false);
            crosshair.SetActive(false);
            timer.SetActive(true);
            inMouseZone = false;
            inPaperZone = false;
            inInkZone = false;
            inTurkeyZone = false;
            inHamZone= false;
            inButterZone = false;
            inCashierZone = false;
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(inMouseZone && !typing)
            {
                objectiveCount ++;
                clickedMouse = true;
                sfxSound.clip = mouseClick;
                sfxSound.Play();
            }
            if(inPaperZone && clickedMouse && !hasInk && !typing)
            {
                objectiveCount ++;
                inPaperZone = false;
                hasFailedPrint = true;
                sfxSound.clip = interact;
                sfxSound.Play();
                interaction02.SetActive(true);
            }
            if(inInkZone && !hasInk && !typing)
            {
                objectiveCount ++;
                hasInk = true;
                sfxSound.clip = interact;
                sfxSound.Play();
                interaction04.SetActive(true);
            }
            if(inPaperZone && hasInk && !typing)
            {
                objectiveCount ++;
                sfxSound.clip = printerPrint;
                sfxSound.Play();
                interaction05.SetActive(true);
            }
            if(inTurkeyZone && !typing)
            {
                objectiveCount ++;
                hasTurkey = true;
                sfxSound.clip = interact;
                sfxSound.Play();
                interaction03.SetActive(true);

            }
            if(inHamZone && hasTurkey && !typing)
            {
                objectiveCount ++;
                hasHam = true;
                sfxSound.clip = interact;
                sfxSound.Play();
                interaction05.SetActive(true);
            }
            if(inButterZone && hasHam && !typing)
            {
                objectiveCount ++;
                hasButter = true;
                sfxSound.clip = interact;
                sfxSound.Play();
                interaction07.SetActive(true);
            }
            if(inCashierZone && hasButter && !typing)
            {
                objectiveCount ++;
                sfxSound.clip = interact;
                sfxSound.Play();
                interaction08.SetActive(true);
            }
            if(inBreadstickZone && !typing)
            {
                objectiveCount ++;
                hasBreadsticks = true;
                sfxSound.clip = interact;
                sfxSound.Play();
                interaction02.SetActive(true);
            }
            if(inTableZone && !typing && hasBreadsticks) 
            {
                objectiveCount ++;
                leftBreadsticks = true;
                sfxSound.clip = interact;
                sfxSound.Play();
                interaction03.SetActive(true);
            }
            if(inSinkZone && !typing && leftBreadsticks)
            {
                objectiveCount ++;
                end = true;
                sfxSound.clip = interact;
                sfxSound.Play();
                interaction04.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "mouse" && !typing)
        {
            fBanner.SetActive(true);
            inMouseZone = true;
        }
        if(other.gameObject.tag == "paper" && !typing && clickedMouse)
        {
            fBanner.SetActive(true);
            inPaperZone = true;
        }
        if(other.gameObject.tag == "ink" && !typing && hasFailedPrint)
        {
            fBanner.SetActive(true);
            inInkZone = true;
        }
        if(other.gameObject.tag == "turkey" && !typing)
        {
            fBanner.SetActive(true);
            inTurkeyZone = true;
        }
        if(other.gameObject.tag == "ham" && !typing && hasTurkey)
        {
            fBanner.SetActive(true);
            inHamZone = true;
        }
        if(other.gameObject.tag == "butter" && !typing && hasHam)
        {
            fBanner.SetActive(true);
            inButterZone = true;
        }
        if(other.gameObject.tag == "cashier" && !typing && hasButter)
        {
            fBanner.SetActive(true);
            inCashierZone = true;
        }
        if(other.gameObject.tag == "breadsticks" && !typing)
        {
            fBanner.SetActive(true);
            inBreadstickZone = true;
        }
        if(other.gameObject.tag == "table" && !typing && hasBreadsticks)
        {
            fBanner.SetActive(true);
            inTableZone = true;
        }
        if(other.gameObject.tag == "sink" && !typing && leftBreadsticks)
        {
            fBanner.SetActive(true);
            inSinkZone = true;
        }
        if(other.gameObject.tag == "exit" && !typing && end)
        {
            SceneManager.LoadScene("FinalCutscene");
        }
        if(other.gameObject.tag == "door" && !typing)
        {
            sfxSound.clip = doorOpen;
            sfxSound.Play();
            Animator animator = other.gameObject.GetComponent<Animator>();
            animator.SetBool("Open", true);
        }
        if(other.gameObject.tag == "freezer" && !typing)
        {
            sfxSound.clip = doorOpen;
            sfxSound.Play();
            Animator animator = other.gameObject.GetComponent<Animator>();
            animator.SetBool("Open", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "mouse" && !typing)
        {
            fBanner.SetActive(false);
            inMouseZone = false;
        }
        if(other.gameObject.tag == "paper" && !typing)
        {
            fBanner.SetActive(false);
            inPaperZone = false;
        }
        if(other.gameObject.tag == "ink" && !typing)
        {
            fBanner.SetActive(false);
            inInkZone = false;
        }
        if(other.gameObject.tag == "turkey" && !typing)
        {
            fBanner.SetActive(false);
            inTurkeyZone = false;
        }
        if(other.gameObject.tag == "ham" && !typing)
        {
            fBanner.SetActive(false);
            inHamZone = false;
        }
        if(other.gameObject.tag == "butter" && !typing)
        {
            fBanner.SetActive(false);
            inButterZone = false;
        }
        if(other.gameObject.tag == "cashier" && !typing)
        {
            fBanner.SetActive(false);
            inCashierZone = false;
        }
        if(other.gameObject.tag == "thought01" && !typing)
        {
            interaction02.SetActive(true);
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "thought02" && !typing && hasTurkey)
        {
            interaction04.SetActive(true);
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "thought03" && !typing && hasHam)
        {
            interaction06.SetActive(true);
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "door" && !typing)
        {
            sfxSound.clip = doorClose;
            sfxSound.Play();
            Animator animator = other.gameObject.GetComponent<Animator>();
            animator.SetBool("Open", false);
        }
        if(other.gameObject.tag == "freezer" && !typing)
        {
            sfxSound.clip = doorClose;
            sfxSound.Play();
            Animator animator = other.gameObject.GetComponent<Animator>();
            animator.SetBool("Open", false);
        }
    }

    void UpdateObjective()
    {
        switch(objectiveCount)
        {
            case 0:
                objective.text = "Print the report";
                mouseGlow.SetActive(true);
                break;

            case 1: 
                objective.text = "Grab the paper from the printer";
                mouseGlow.SetActive(false);
                printerGlow.SetActive(true);
                break;

            case 2:
                objective.text = "Grab the printer ink";
                printerGlow.SetActive(false);
                inkGlow.SetActive(true);
                break;

            case 3:
                objective.text = "Bring ink to the printer";
                inkGlow.SetActive(false);
                ink.SetActive(false);
                inkInHand.SetActive(true);
                printerGlow.SetActive(true);
                break;

            case 4:
                if(SceneManager.GetActiveScene().name == "Level01")
                {
                    printerGlow.SetActive(false);
                    paperInHand.SetActive(true);
                    inkInHand.SetActive(false);
                }
                else if(SceneManager.GetActiveScene().name == "Level02")
                {
                    objective.text = "Get a turkey";
                    turkeyGlow.SetActive(true);
                }
                break;

            case 5:
                objective.text = "Get a ham";
                turkeyGlow.SetActive(false);
                hamGlow.SetActive(true);
                turkey.SetActive(false);
                turkeyInHand.SetActive(true);
                break;

            case 6:
                objective.text = "Get peanut butter";
                hamGlow.SetActive(false);
                butterGlow.SetActive(true);
                hamInHand.SetActive(true);
                ham.SetActive(false);
                break;

            case 7:
                objective.text = "Check out your items";
                butterGlow.SetActive(false);
                cashierGlow.SetActive(true);
                butter.SetActive(false);
                butterInHand.SetActive(true);
                break;

            case 8:
                objective.text = "Grab the breadsticks";
                break;

            case 9:
                objective.text = "Place the breadsticks on the table";
                break;

            case 10:
                objective.text = "Put your dish in the sink";
                break;

            case 11:
                objective.text = "LEAVE";
                break;
        }
    }
}
