using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    bool isMove = false;

    void Update()
    {
        if (isMove)
        {
            transform.Translate(Vector2.left * 1.0f * Time.deltaTime);
        }

        if (transform.position.x <= -23.5f)
        {
            transform.position = new Vector2(23.5f, 0);
        }
    }

    public void On()
    {
        isMove = true;
    }

    public void Off()
    {
        isMove = false;
    }
}
