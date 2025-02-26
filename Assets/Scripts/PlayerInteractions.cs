using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    static int objectiveCount = 0;
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

    bool hasInk;
    bool clickedMouse;
    bool hasTurkey;
    bool hasHam;
    bool hasButter;

    public GameObject paper;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level01")
        {
            paper.SetActive(false);
            objectiveCount = 0;
        }

        if(SceneManager.GetActiveScene().name == "Level02")
        {
            objectiveCount = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateObjective();

        if(text03 == true)
        {
            interaction03.SetActive(true);
        }
        if(!typing)
        {
            objectiveDisplay.SetActive(true);
            crosshair.SetActive(true);
            timer.SetActive(false);
        }
        else if(typing)
        {
            objectiveDisplay.SetActive(false);
            fBanner.SetActive(false);
            crosshair.SetActive(false);
            timer.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(inMouseZone)
            {
                objectiveCount ++;
                clickedMouse = true;
            }
            if(inPaperZone && clickedMouse && !hasInk)
            {
                objectiveCount ++;
                inPaperZone = false;
                hasFailedPrint = true;
                interaction02.SetActive(true);
            }
            if(inInkZone && hasFailedPrint && !hasInk)
            {
                objectiveCount ++;
                hasInk = true;
                interaction04.SetActive(true);
            }
            if(inPaperZone && hasInk)
            {
                objectiveCount ++;
                interaction05.SetActive(true);
            }
            if(inTurkeyZone)
            {
                objectiveCount ++;
                hasTurkey = true;
                interaction03.SetActive(true);

            }
            if(inHamZone && hasTurkey)
            {
                objectiveCount ++;
                hasHam = true;
                interaction05.SetActive(true);
            }
            if(inButterZone && hasHam)
            {
                objectiveCount ++;
                hasButter = true;
                interaction07.SetActive(true);
            }
            if(inCashierZone && hasButter)
            {
                objectiveCount ++;
                interaction08.SetActive(true);
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
        }
        if(other.gameObject.tag == "thought02" && !typing)
        {
            interaction04.SetActive(true);
        }
        if(other.gameObject.tag == "thought03" && !typing)
        {
            interaction06.SetActive(true);
        }
    }

    void UpdateObjective()
    {
        switch(objectiveCount)
        {
            case 0:
                objective.text = "Print the report";
                break;

            case 1: 
                objective.text = "Grab the paper from the printer";
                break;

            case 2:
                objective.text = "Grab the printer ink";
                break;

            case 3:
                objective.text = "Bring ink to the printer";
                break;

            case 4:
                objective.text = "Get a turkey";
                break;

            case 5:
                objective.text = "Get a ham";
                break;

            case 6:
                objective.text = "Get peanut butter";
                break;

            case 7:
                objective.text = "Check out your items";
                break;
        }
    }
}
