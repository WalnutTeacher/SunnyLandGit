using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUIManage : MonoBehaviour
{
    Player Player;
    GameObject canvas;

    int current_page_number=0;
    int total_page_count;



    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Player>();
        Player.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnPage()
    {
        Player.enabled = true;
        gameObject.SetActive(false);
    }
}
