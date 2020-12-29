using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void ProgramQuit()
    {
        Application.Quit();
    }
}
