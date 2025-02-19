using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    static int objectiveCount = 0;
    public TMP_Text objective;
    public GameObject fBanner;
    public bool typing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateObjective();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "mouse")
        {
            fBanner.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "mouse")
        {
            fBanner.SetActive(false);
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
        }
    }
}
