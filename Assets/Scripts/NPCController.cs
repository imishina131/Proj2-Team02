using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;

    bool isWandering;
    bool isRotatingLeft;
    bool isRotatingRight;
    bool isWalking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isWandering)
        {
            StartCoroutine(Wander());
        }
        if(isRotatingRight)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if(isRotatingLeft)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if(isWalking)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1,3);
        int rotateWait = Random.Range(1,4);
        int rotateLOrR = Random.Range(1,2);
        int walkWait = Random.Range(1,5);
        int walkTime = Random.Range(1,6);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);

        if(rotateLOrR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        else if(rotateLOrR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;
    }
}
