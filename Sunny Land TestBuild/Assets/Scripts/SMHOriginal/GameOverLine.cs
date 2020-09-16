using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//송무현이 짠 코드입니다
//캐릭터가 GameOver라는 태그가 달린 물체에 닿았을때 동작을 설정합니다.
public class GameOverLine : MonoBehaviour
{
    public CameraManager MainCamera;
    public UiManager UI_Manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GameOver")
        {
        }
    }
}
