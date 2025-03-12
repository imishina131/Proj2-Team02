using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public PlayerInteractions player;

    public bool lookAtNPC;

    Vector3 target;
    Vector3 targetOff;
    Transform targetoff;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        if(SceneManager.GetActiveScene().name == "Level01")
        {
            xRotation += 50;
            yRotation += 90;
        }
        if(SceneManager.GetActiveScene().name == "Level02")
        {
            xRotation += 50;
            yRotation += 90;
        }
        */
        Cursor.visible = false;
        //transform.rotation = Quaternion.Euler(50,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.typing == false)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        else if(player.typing == true)
        {
            transform.rotation = Quaternion.Euler(50,yRotation,0);
            if(SceneManager.GetActiveScene().name == "Level01")
            {
                transform.rotation = Quaternion.Euler(50,yRotation,0);
            }
            if(SceneManager.GetActiveScene().name == "Level02")
            {
                transform.rotation = Quaternion.Euler(50,yRotation,0);
            }
        }

        if(lookAtNPC)
        {
            float distance = Vector3.Distance(target, transform.position);
            Debug.Log("distance" + distance);
            if(distance <= 6)
            {
                targetOff = new Vector3(target.x, target.y - 3, target.z);
            }
            else if(distance > 5 && distance <= 10)
            {
                targetOff = new Vector3(target.x, target.y - 5, target.z);
            }
            else if(distance > 10)
            {
                targetOff = new Vector3(target.x, target.y - 7, target.z);
            }
            transform.LookAt(targetOff);
        }
    }

    public void LookAt(GameObject npc)
    {
        lookAtNPC = true;
        target = npc.transform.position;
    }

    public void LookAway()
    {
        lookAtNPC = false;
        xRotation += 50;
        yRotation += 90;
        transform.rotation = Quaternion.Euler(50,0,0);
    }

}
