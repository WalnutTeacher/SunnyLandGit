using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionController : MonoBehaviour
{
    public static ResolutionController ScreenManager = null;

    public Vector2 standard_resolution;
    public Camera camera = null;
    public Camera Back_Camera = null;
    public bool isLandScape;
    float rate;
    void Start()
    {
        if (ScreenManager == null)
        {
            ScreenManager = this;
        }
        else if (ScreenManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        rate = standard_resolution.y / standard_resolution.x;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("asd");
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Back_Camera = GameObject.Find("Back Camera").GetComponent<Camera>();
        MainSetting();
        //BackSetting();
    }

    void MainSetting()
    {
        float mobile_rate = (float)Screen.height/ (float)Screen.width;//현재 사용중인 스크린의 비율 2960 1440 = 2.05
        Debug.Log(mobile_rate);
        if (mobile_rate > rate)
        {
            float h = rate / mobile_rate;
            camera.rect = new Rect(0, (1 - h) / 2, 1, h);
            Debug.Log("세로");
        }
        else
        {
            float w = mobile_rate / rate;
            camera.rect = new Rect((1 - w) / 2, 0, w, 1);
            Debug.Log("가로");
        }
    }
    void BackSetting()
    {
        if (Back_Camera != null)
        {
            float mobile_rate = (float)Screen.height / (float)Screen.width;//현재 사용중인 스크린의 비율 2960 1440 = 2.05
            Debug.Log(mobile_rate);
            if (mobile_rate > rate)
            {
                float h = rate / mobile_rate;
                Back_Camera.rect = new Rect(0, (1 - h) / 2, 1, h);
                Debug.Log("세로");
            }
            else
            {
                float w = mobile_rate / rate;
                Back_Camera.rect = new Rect((1 - w) / 2, 0, w, 1);
                Debug.Log("가로");
            }
        }

    }
}
