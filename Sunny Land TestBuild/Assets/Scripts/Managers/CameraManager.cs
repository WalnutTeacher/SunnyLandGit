using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Player;

    Vector3 _Vector3;

    void LateUpdate()
    {
        if (Player)
        {
            _Vector3.x = Player.transform.position.x + 5.0f;
            _Vector3.y = Player.transform.position.y + 1.0f;
            _Vector3.z = -10.0f;

            transform.position = Vector3.Lerp(transform.position, _Vector3, 5.0f * Time.deltaTime);
        }
    }
}
