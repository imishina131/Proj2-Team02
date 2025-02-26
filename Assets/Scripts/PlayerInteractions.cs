using UnityEngine;
using TMPro;

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

    bool hasInk;
    bool clickedMouse;

    public GameObject paper;

    public GameObject interaction01;
    public GameObject interaction02;
    public GameObject interaction03;
    public GameObject interaction04;
    public GameObject interaction05;


    public GameObject crosshair;

    public bool text03;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paper.SetActive(false);
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
        }
    }
}
