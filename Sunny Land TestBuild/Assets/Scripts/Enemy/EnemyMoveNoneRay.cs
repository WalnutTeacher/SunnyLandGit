using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveNoneRay : MonoBehaviour
{
    public float moving_speed;

    public float distance;
    float Distance_Traveled = 0;
    void Start()
    {
    }
    
    void Update()
    {

        transform.Translate(-moving_speed * Time.deltaTime , 0, 0);
        Distance_Traveled += Mathf.Abs(moving_speed * Time.deltaTime);
        

        if (distance < Distance_Traveled)
        {
            moving_speed *= -1;
            transform.localScale = new Vector2(transform.localScale.x*(-1),1);
            Distance_Traveled = 0;
        }

    }
}
