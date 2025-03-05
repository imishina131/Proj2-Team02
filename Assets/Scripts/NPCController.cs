using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{


    public Transform[] points;

    int walkingStage = 0;

    public NavMeshAgent npc;

    bool moveBack;
    bool dead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("moveback:" + moveBack);
        Debug.Log("moveNumber:" + walkingStage);
        if(walkingStage == points.Length)
        {
            moveBack = true;
            walkingStage --;
        }
        else if(walkingStage == 0)
        {
            moveBack = false;
        }

        if(!dead)
        {
            Move();
        }
    }

    void Move()
    {
        npc.SetDestination(points[walkingStage].position);

        if(!npc.pathPending)
        {
            if(npc.remainingDistance <= npc.stoppingDistance)
            {
                if(moveBack)
                {
                    walkingStage --;
                }
                else if(!moveBack)
                {
                    walkingStage++;
                }
            }
        }
    }

    public void Explode()
    {
        dead = true;
    }

}
