using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreAniamtion : MonoBehaviour
{
    GameObject Game_Object_Temp;
    GameManager Game_Manager;
    int Graphic_Score = 0;
    Text My_Text;

    void Start()
    {
        Game_Object_Temp = GameObject.Find("GameManager");
        Game_Manager = Game_Object_Temp.GetComponent<GameManager>();
        My_Text = GetComponent<Text>();
    }
    
    void Update()
    {
        StartCoroutine("GraphicScoreRun");
    }
    IEnumerator GraphicScoreRun()
    {
        if (Graphic_Score < Game_Manager.score)
        {
            Graphic_Score += Random.Range(1, Game_Manager.score / 60);
            My_Text.text = "" + Graphic_Score;
        }
        else if (Graphic_Score > Game_Manager.score)
        {
            Graphic_Score = Game_Manager.score;
            My_Text.text = "" + Graphic_Score;
        }
        yield return new WaitForSeconds(.017f);
    }

}
