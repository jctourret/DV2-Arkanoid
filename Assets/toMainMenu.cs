﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMainMenu : MonoBehaviour
{
    public void onMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }   
}
