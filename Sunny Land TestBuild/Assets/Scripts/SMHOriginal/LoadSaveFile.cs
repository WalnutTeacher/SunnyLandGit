using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveFile : MonoBehaviour
{
    GameObject Temp;
    SaveLoad Save_Load_Manager;
    void Start()
    {
        Temp = GameObject.Find("SaveLoadManager");
        Save_Load_Manager = Temp.GetComponent<SaveLoad>();
    }
}
