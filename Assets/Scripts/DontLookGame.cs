using UnityEngine;
using System.Collections;

public class DontLookGame : MonoBehaviour
{
    public GameObject character;
    public GameObject vision;

    RectTransform rectTransformCharacter;
    RectTransform rectTransformVision;
    Vector2 anchoredPosCharacter;
    Vector2 anchoredPosVision;

    bool pressing;
    bool moving;
    public bool initialized;

    public Typer typer;

    public RaycastScript eyes;

    public LoseAndExplode lose;

    public GameObject interaction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransformCharacter = character.GetComponent<RectTransform>();
        rectTransformVision = vision.GetComponent<RectTransform>();
        anchoredPosCharacter = rectTransformCharacter.anchoredPosition;
        anchoredPosVision = rectTransformVision.anchoredPosition;

    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log("press:" + pressing);
        pressing = false;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            pressing = true;
            anchoredPosCharacter.x += 20;
            anchoredPosVision.x -= 20;
            rectTransformCharacter.anchoredPosition = anchoredPosCharacter;
            rectTransformVision.anchoredPosition = anchoredPosVision;
        }
        else
        {
            if(!moving)
            {
                StartCoroutine(Move());
            }
        }

        CheckPos();
    }

    IEnumerator Move()
    {
        while(!pressing)
        {
            moving = true;
            anchoredPosCharacter.x -= 20;
            anchoredPosVision.x += 20;
            rectTransformCharacter.anchoredPosition = anchoredPosCharacter;
            rectTransformVision.anchoredPosition = anchoredPosVision;
            yield return new WaitForSeconds(0.5f);
        }
    }

    void CheckPos()
    {
        if(anchoredPosCharacter.x <= 0 && anchoredPosVision.x >= 0)
        {
            Debug.Log("Lost");
            gameObject.SetActive(false);
            interaction.SetActive(false);
            lose.Explode();   
        }
        else if(anchoredPosCharacter.x >= 400 && anchoredPosVision.x <= -400)
        {
            anchoredPosCharacter = new Vector3(270, anchoredPosCharacter.y, 0);
            anchoredPosVision = new Vector3(-270, anchoredPosCharacter.y, 0);
            rectTransformCharacter.anchoredPosition = anchoredPosCharacter;
            rectTransformVision.anchoredPosition = anchoredPosVision;
            moving = false;
            typer.timerOn = true;
            gameObject.SetActive(false);
        }
    }
}
