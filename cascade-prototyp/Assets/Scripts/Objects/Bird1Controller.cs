using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird1Controller : MonoBehaviour
{
    public bool fly = false;

    private void Update()
    {
        if (fly)
        {
            if (playeer_cheker == true && goalPoint != 0)
            {
                MoveToPoint();
            }
            else
            {
                MoveToNextPoint();
            }
        }
    }


    public List<Transform> points;
    public Transform platform;
    int goalPoint = 0;
    public float moveSpeed = 2;
    public bool playeer_cheker = false;



    public void MoveToPoint()
    {
        playeer_cheker = true;
        platform.position = Vector2.MoveTowards(platform.position, points[goalPoint].position, Time.deltaTime * moveSpeed / 2);
    }

    public void MoveToNextPoint()
    {
        fly = true;
        //change the position of the platform (move towards the goal point)
        platform.position = Vector2.MoveTowards(platform.position, points[goalPoint].position, Time.deltaTime * moveSpeed);
        //Check if we are in very close proximity of the next point
        if (Vector2.Distance(platform.position, points[goalPoint].position) < 0.1f)
        {
            //If so change goal point to the next one
            //Check if we reached the last point, reset to first point
            if (goalPoint == points.Count - 1)
            {
                goalPoint = 0;
                platform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
            }

            else
            {
                goalPoint++;
                platform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
        }
    }
}
