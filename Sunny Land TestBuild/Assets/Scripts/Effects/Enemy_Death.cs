﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death : MonoBehaviour
{
    void Destroy()
    {
        Destroy(gameObject);
    }
}