using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    public GameObject Left_Button;
    public GameObject Right_Button;
    public GameObject Stage_1_Button;
    public GameObject Stage_2_Button;
    public GameObject Stage_3_Button;

    //송무현 - 이미지를 Resources.Load로 불러보려 했으나, 안되어서 퍼블릭 변수로 넣어서 사용함.
    public Sprite Tutorial_Button;
    public Sprite SunnyLand_Button;
    public Sprite Cave_Button;
    Image Image_Temp;// 스테이지 버튼1,2,3의 이미지를 가지기 위한 변수
    //송무현

    public Text Chapter_Text;
    public Text Stage_1_Text;
    public Text Stage_2_Text;
    public Text Stage_3_Text;
    
    public int chapter = 1;

    void Start()
    {
        AudioManager._AudioManager.BGM_Main();
    }

    void Update()
    {
        switch (chapter)
        {
            case 1:
                Chapter_Text.text = "TUTORIAL";
                Stage_2_Text.text = "튜토리얼";
                Left_Button.SetActive(false);
                Right_Button.SetActive(true);
                Stage_1_Button.SetActive(false);
                Stage_2_Button.SetActive(true); 
                Stage_3_Button.SetActive(false);

                //송무현
                Image_Temp = Stage_2_Button.GetComponent<Image>();
                Image_Temp.sprite = Tutorial_Button;
                //송무현
                break;
            case 2:
                Chapter_Text.text = "SUNNY LAND";
                Stage_1_Text.text = "1-1 단계";
                Stage_2_Text.text = "1-2 단계";
                Stage_3_Text.text = "1-3 단계";
                Left_Button.SetActive(true);
                Right_Button.SetActive(true);
                Stage_1_Button.SetActive(true);
                Stage_2_Button.SetActive(true);
                Stage_3_Button.SetActive(true);
                //송무현
                Image_Temp = Stage_1_Button.GetComponent<Image>();
                Image_Temp.sprite = SunnyLand_Button;
                Image_Temp = Stage_2_Button.GetComponent<Image>();
                Image_Temp.sprite = SunnyLand_Button;
                Image_Temp = Stage_3_Button.GetComponent<Image>();
                Image_Temp.sprite = SunnyLand_Button;
                //송무현
                break;
            case 3:
                Chapter_Text.text = "SUNNY LAND";
                Stage_1_Text.text = "1-4 단계";
                Stage_2_Text.text = "1-5 단계";
                Stage_3_Text.text = "1-6 단계";
                Left_Button.SetActive(true);
                Right_Button.SetActive(true);
                Stage_1_Button.SetActive(true);
                Stage_2_Button.SetActive(true);
                Stage_3_Button.SetActive(true);
                //송무현
                Image_Temp = Stage_1_Button.GetComponent<Image>();
                Image_Temp.sprite = SunnyLand_Button;
                Image_Temp = Stage_2_Button.GetComponent<Image>();
                Image_Temp.sprite = SunnyLand_Button;
                Image_Temp = Stage_3_Button.GetComponent<Image>();
                Image_Temp.sprite = SunnyLand_Button;
                //송무현
                break;
            case 4:
                Chapter_Text.text = "CAVE";
                Stage_1_Text.text = "2-1 단계";
                Stage_2_Text.text = "2-2 단계";
                Stage_3_Text.text = "2-3 단계";
                Left_Button.SetActive(true);
                Right_Button.SetActive(false);
                Stage_1_Button.SetActive(true);
                Stage_2_Button.SetActive(true);
                Stage_3_Button.SetActive(true);
                //송무현
                Image_Temp = Stage_1_Button.GetComponent<Image>();
                Image_Temp.sprite = Cave_Button;
                Image_Temp = Stage_2_Button.GetComponent<Image>();
                Image_Temp.sprite = Cave_Button;
                Image_Temp = Stage_3_Button.GetComponent<Image>();
                Image_Temp.sprite = Cave_Button;
                //송무현
                break;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Main");
    }

    public void Left()
    {
        chapter--;

        AudioManager._AudioManager.SE_Page();
    }

    public void Right()
    {
        chapter++;

        AudioManager._AudioManager.SE_Page();
    }

    public void Stage_1()
    {
        switch (chapter)
        {
            case 2:
                SceneManager.LoadScene("Stage 1-1");
                AudioManager._AudioManager.BGM_Run();
                break;
            case 3:
                SceneManager.LoadScene("Stage 1-4");
                AudioManager._AudioManager.BGM_Run();
                break;
            case 4:
                SceneManager.LoadScene("Stage 2-1");
                AudioManager._AudioManager.BGM_Run();
                break;
        }
    }

    public void Stage_2()
    {
        switch (chapter)
        {
            case 1:
                SceneManager.LoadScene("Tutorial");
                AudioManager._AudioManager.BGM_Run();
                break;
            case 2:
                SceneManager.LoadScene("Stage 1-2");
                AudioManager._AudioManager.BGM_Run();
                break;
            case 3:
                SceneManager.LoadScene("Stage 1-5");
                AudioManager._AudioManager.BGM_Run();
                break;
            case 4:
                SceneManager.LoadScene("Stage 2-2");
                AudioManager._AudioManager.BGM_Run();
                break;
        }
    }

    public void Stage_3()
    {
        switch (chapter)
        {
            case 2:
                SceneManager.LoadScene("Stage 1-3");
                AudioManager._AudioManager.BGM_Run();
                break;
            case 3:
                SceneManager.LoadScene("Stage 1-6");
                AudioManager._AudioManager.BGM_Run();
                break;
            case 4:
                SceneManager.LoadScene("Stage 2-3");
                AudioManager._AudioManager.BGM_Run();
                break;
        }
    }
}
