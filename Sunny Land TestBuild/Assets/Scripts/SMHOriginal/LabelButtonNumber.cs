using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelButtonNumber : MonoBehaviour
{
    StarGradeSetting Star_Grade_Setting;
    void Awake()
    {
        
        for (int i = 0; i < transform.childCount; i++)
        {
            Star_Grade_Setting =  transform.GetChild(i).GetComponent<StarGradeSetting>();
            Star_Grade_Setting.Stage_Button_Number = i + 1;
        }
    }
}
