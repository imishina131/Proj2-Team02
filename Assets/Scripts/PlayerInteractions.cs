using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    static int objectiveCount = 0;
    public TMP_Text objective;
    public GameObject objectiveDisplay;
    public GameObject fBanner;
    public bool typing;

    bool inMouseZone;
    bool inPaperZone;

    bool hasInk;
    bool clickedMouse;

    public GameObject paper;

    public GameObject interaction01;
    public GameObject interaction02;
    public GameObject interaction03;
    public GameObject interaction04;
    public GameObject interaction05;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateObjective();
        if(!typing)
        {
            objectiveDisplay.SetActive(true);
        }
        else if(typing)
        {
            objectiveDisplay.SetActive(false);
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
                interaction02.SetActive(true);
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
        }
    }
}
