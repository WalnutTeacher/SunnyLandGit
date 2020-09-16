using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _GameManager = null;
    public int score = 0;
    public int score_count = 0;
    //송무현
    public int collectibles_count = 0;
    public int monster_count = 0;
    //송무현

    void Awake()
    {
        if (_GameManager == null)
        {
            _GameManager = this;
        }
        else if (_GameManager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
