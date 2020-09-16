using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    public float moving_speed;

    public float distance;

    public int direction=1;
    float Distance_Traveled = 0;
    void Start()
    {
    }

    void Update()
    {

        transform.Translate(0, direction*moving_speed * Time.deltaTime, 0);
        Distance_Traveled += Mathf.Abs(moving_speed * Time.deltaTime);


        if (distance < Distance_Traveled)
        {
            moving_speed *= -1;
            transform.localScale = new Vector2(1, transform.localScale.y * (-1));
            Distance_Traveled = 0;
        }

    }
}