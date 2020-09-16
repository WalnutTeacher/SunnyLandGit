using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarGradeSetting : MonoBehaviour
{
    int chapter = 1;

    public int Stage_Button_Number;

    GameObject Game_Object_Temp;
    SaveLoad Save_Load_Manager;
    GameObject[] Stars = new GameObject[3];

    private void Awake()
    {
        Game_Object_Temp = GameObject.Find("SaveLoadManager");
        Save_Load_Manager = Game_Object_Temp.GetComponent<SaveLoad>();
        for (int i = 0; i < 3; i++)
        {
            Stars[i] = transform.GetChild(i + 1).gameObject;
            
        }
    }
    private void Update()
    {

        switch (chapter)
        {
            case 1:
                switch (Stage_Button_Number)
                {
                    case 2:
                        ChangeStarGrade("Tutorial");
                        break;
                }
                break;
            case 2:
                switch (Stage_Button_Number)
                {
                    case 1:
                        ChangeStarGrade("Stage 1-1");
                        break;
                    case 2:
                        ChangeStarGrade("Stage 1-2");
                        break;
                    case 3:
                        ChangeStarGrade("Stage 1-3");
                        break;
                }
                break;
            case 3:
                switch (Stage_Button_Number)
                {
                    case 1:
                        ChangeStarGrade("Stage 1-4");
                        break;
                    case 2:
                        ChangeStarGrade("Stage 1-5");
                        break;
                    case 3:
                        ChangeStarGrade("Stage 1-6");
                        break;
                }
                break;
            case 4:
                switch (Stage_Button_Number)
                {
                    case 1:
                        ChangeStarGrade("Stage 2-1");
                        break;
                    case 2:
                        ChangeStarGrade("Stage 2-2");
                        break;
                    case 3:
                        ChangeStarGrade("Stage 2-3");
                        break;
                }
                break;
        }
    }

    public void Left()
    {
        chapter--;
    }

    public void Right()
    {
        chapter++;
    }
    void ChangeStarGrade(string FileName)
    {
        Save_Load_Manager.LoadInStageSelect(FileName);
        Stars[0].SetActive(Save_Load_Manager.Stage_Progress_Instance.Score);
        Stars[1].SetActive(Save_Load_Manager.Stage_Progress_Instance.CollectibleCount);
        Stars[2].SetActive(Save_Load_Manager.Stage_Progress_Instance.MonsterCount);
    }

}
