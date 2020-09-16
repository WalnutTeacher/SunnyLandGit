using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultImageTextUpdate : MonoBehaviour
{
    public Text Collectible_Counter;
    public Text Monster_Counter;

    public GameObject[] star  = new GameObject[3];

    GameObject Game_Object_Temp;
    GameManager Game_Manager;
    Player player;
    SaveLoad Save_Load_Manager;

    public int Score_Total;
    public int Collectible_Total;
    public int Monster_Total;

    int Score_Current = 0;
    int Collectible_Current = 0;
    int Monster_Current = 0;

    int Star_Count=0;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        Score_Total = GameObject.FindGameObjectsWithTag("ScoreItem").Length;
        Collectible_Total = GameObject.FindGameObjectsWithTag("Collectible").Length;
        Monster_Total = GameObject.FindGameObjectsWithTag("Enemy").Length;

        Game_Object_Temp = GameObject.Find("GameManager");
        Game_Manager = Game_Object_Temp.GetComponent<GameManager>();
        Game_Object_Temp = GameObject.Find("SaveLoadManager");
        Save_Load_Manager = Game_Object_Temp.GetComponent<SaveLoad>();
        
        Save_Load_Manager.LoadInGame();
    }
    public void TextUpdate() 
    {
        Score_Current = Game_Manager.score_count;
        Collectible_Current = Game_Manager.collectibles_count;
        Monster_Current = Game_Manager.monster_count;

        Collectible_Counter.text = Collectible_Current + "/" + Collectible_Total;
        Monster_Counter.text = Monster_Current + "/" + Monster_Total;
    }
    public void ImageUpdate()
    {
        if (Score_Current == Score_Total)
        {
            star[0].SetActive(true);
            Star_Count++;
        }
        if (Collectible_Current == Collectible_Total)
        {
            star[1].SetActive(true);
            Star_Count++;
        }
        if (Monster_Current == Monster_Total)
        {
           star[2].SetActive(true);
            Star_Count++;
        }

        for(int i=0; i<Star_Count; i++)
        {
            if (i == 0)
                Save_Load_Manager.Stage_Progress_Instance.Score = true;
            if (i == 1)
                Save_Load_Manager.Stage_Progress_Instance.CollectibleCount = true;
            if (i == 2)
                Save_Load_Manager.Stage_Progress_Instance.MonsterCount = true;
        }

        if (player.is_clear)
            Save_Load_Manager.Stage_Progress_Instance.is_clear = true;
        if (player.is_cave_land)
            Save_Load_Manager.Stage_Progress_Instance.is_cave_land = true;
        Save_Load_Manager.Save();
    }
}
