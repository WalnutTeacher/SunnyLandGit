using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;
public class SaveLoad : MonoBehaviour
{
    GameObject Game_Object_Temp;
    GameManager Game_Manager;

    public static SaveLoad Save_Load_Manager = null;
    public int test = 0;
    [Serializable]
    public class StageProgress
    {
        public bool Score=false;
        public bool CollectibleCount=false;
        public bool MonsterCount=false;
        public bool is_clear = false;
        public bool is_cave_land = false;
        public string Stage_Name=string.Empty;

        public override string ToString()
        {
            return " IsScore: " + Score + " IsCollectibleCount: " + CollectibleCount + " IsMonsterCount: " + MonsterCount + " Name : " + Stage_Name;
        }
    }
  
    public StageProgress Stage_Progress_Instance;
    string Original_File_Path = string.Empty;
    private void Awake()
    {
        if (Save_Load_Manager == null)
        {
            Save_Load_Manager = this;
        }
        else if (Save_Load_Manager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Original_File_Path = Application.dataPath + "/SaveData"; //작업할때 사용하는 보기쉬운 경로
        //Original_File_Path = Application.persistentDataPath;//실제 모바일 환경에서 저장에 사용하는 경로
    }
    private void Start()
    {
        Game_Object_Temp = GameObject.Find("GameManager");
        Game_Manager = Game_Object_Temp.GetComponent<GameManager>();
        Stage_Progress_Instance = new StageProgress();
    }
    private void Update()
    {
        
    }
    public void Save()
    {
        Stage_Progress_Instance.Stage_Name = SceneManager.GetActiveScene().name;
        BinarySerialize<StageProgress>(Stage_Progress_Instance,Original_File_Path+ "/" +Stage_Progress_Instance.Stage_Name);
    }
    public void LoadInGame()
    {
        Stage_Progress_Instance=BinaryDeserialize<StageProgress>(Original_File_Path + "/" + SceneManager.GetActiveScene().name);
        Debug.Log(Stage_Progress_Instance.ToString());
    }
    public void LoadInStageSelect(String FileName)
    {
        try{
            Stage_Progress_Instance = BinaryDeserialize<StageProgress>(Original_File_Path + "/" + FileName);
        }
        catch (FileNotFoundException e)
        {
            Stage_Progress_Instance = new StageProgress();
        }
    }

    public void BinarySerialize<T>(T t, string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(filePath, FileMode.Create);
        formatter.Serialize(stream, t);
        stream.Close();
    }

    public T BinaryDeserialize<T>(string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(filePath, FileMode.Open);
        T t = (T)formatter.Deserialize(stream);
        stream.Close();

        return t;
    }
}
