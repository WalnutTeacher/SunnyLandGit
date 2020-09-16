using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageLock : MonoBehaviour
{
    Stage stage_manager;
    SaveLoad Save_Load_Manager;

    public int Stage_Button_Number;
    void Start()
    {
        stage_manager = GameObject.Find("Canvas").GetComponent<Stage>();
        Save_Load_Manager = GameObject.Find("SaveLoadManager").GetComponent<SaveLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (stage_manager.chapter)
        {
            case 1:
                GetComponent<Button>().interactable = true;
                break;
            case 2:
                switch (Stage_Button_Number)
                {
                    case 1:
                        SetInteractable("Tutorial");
                        break;
                    case 2:
                        SetInteractable("Stage 1-1");
                        break;
                    case 3:
                        SetInteractable("Stage 1-2");
                        break;
                }
                break;
            case 3:
                switch (Stage_Button_Number)
                {
                    case 1:
                        SetInteractable("Stage 1-3");
                        break;
                    case 2:
                        SetInteractable("Stage 1-4");
                        break;
                    case 3:
                        SetInteractable("Stage 1-5");
                        break;
                }
                break;
            case 4:
                switch (Stage_Button_Number)
                {
                    case 1:
                        SetInteractableByIsCaveLand("Stage 1-6","Stage 1-6");
                        break;
                    case 2:
                        SetInteractableByIsCaveLand("Stage 2-1","Stage 1-6");
                        break;
                    case 3:
                        SetInteractableByIsCaveLand("Stage 2-2","Stage 1-6");
                        break;
                }
                break;
        }
    }
    void SetInteractable(string ConditionFileName)
    {
        Save_Load_Manager.LoadInStageSelect(ConditionFileName);
        if (Save_Load_Manager.Stage_Progress_Instance.is_clear)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
    void SetInteractableByIsCaveLand(string ConditionFileName, string NextStageConditionFileName)
    {
        Save_Load_Manager.LoadInStageSelect(NextStageConditionFileName);
        if (Save_Load_Manager.Stage_Progress_Instance.is_cave_land)
        {
            Save_Load_Manager.LoadInStageSelect(ConditionFileName);
            if (Save_Load_Manager.Stage_Progress_Instance.is_clear)
            {
                GetComponent<Button>().interactable = true;
            }
            else
                GetComponent<Button>().interactable = false;
        }
        else
        {

            GetComponent<Button>().interactable = false;
        }
    }
}
