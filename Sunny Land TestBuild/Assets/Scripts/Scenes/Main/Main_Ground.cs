using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Ground : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x <= -23.0f)
        {
            transform.position = new Vector2(23, 0);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * 3.0f * Time.fixedDeltaTime);
    }
}
