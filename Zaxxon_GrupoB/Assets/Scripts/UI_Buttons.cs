﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    // Start is called before the first frame update
  

    public void CambiarStart()
    {
        SceneManager.LoadScene(1);
    }

    public void CambiarHighScores()
    {
        SceneManager.LoadScene(2);
    }
     
    public void CambiarVolver()
    {
        SceneManager.LoadScene(0);
    }
    public void Salir()
    {
      Application.Quit();
    }
}
