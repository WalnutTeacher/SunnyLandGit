
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject Pause_Image;
    public Text Score_Text;

    public GameObject Guide;
    public Text Guide_Text;

    public bool Tutorial = false;

    public string[] Text_Array;

    int Text_Index = 0;

    //송무현
    public GameObject Result_Image;
    public ResultImageTextUpdate Result_Image_Text_Update;
    //송무현

    // 튜토리얼
    void Start()
    {
        if (Tutorial)
        {
            Guide.SetActive(true);
        }
    }
    //
    void Update()
    {
        Score_Text.text = GameManager._GameManager.score.ToString();
        if (Guide != null)
        {
            if (Text_Index < Text_Array.Length)
            {
                Guide_Text.text = Text_Array[Text_Index];
            }

            if (Text_Index == Text_Array.Length)
            {
                Guide.SetActive(false);
            }
        }
    }

    public void Pause()
    {
        Pause_Image.SetActive(true);

        Time.timeScale = 0.0f;
    }

    public void Continue()
    {
        Pause_Image.SetActive(false);

        Time.timeScale = 1.0f;
    }

    public void ToStage()
    {
        SceneManager.LoadScene("Stage");

        // 게임매니저
        GameManager._GameManager.collectibles_count = 0;
        GameManager._GameManager.monster_count = 0;
        GameManager._GameManager.score_count = 0;
        GameManager._GameManager.score = 0;

        Time.timeScale = 1.0f;

        AudioManager._AudioManager.BGM_Volume(1.0f);
    }

    //송무현
    public void Result()
    {
        Result_Image.SetActive(true);
        Result_Image_Text_Update.TextUpdate();
        Result_Image_Text_Update.ImageUpdate();
    }

    public void Restart()
    {
        // 게임매니저
        GameManager._GameManager.collectibles_count = 0;
        GameManager._GameManager.monster_count = 0;
        GameManager._GameManager.score_count = 0;
        GameManager._GameManager.score = 0;

        Time.timeScale = 1.0f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 현재 씬 다시 불러오기

        AudioManager._AudioManager.BGM_Volume(1.0f);
        AudioManager._AudioManager.BGM_Run();
    }
    //송무현

    // 튜토리얼
    public void NextButton()
    {
        Text_Index++;
    }

    public void SkipButton()
    {
        Guide.SetActive(false);
    }
    //
}
