using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamestart : MonoBehaviour
{
    public static int gamechecktest = 1;
    public void autoclickchangescene()
    {
        gamechecktest = 0;
        SceneManager.LoadScene("mapselectcheck");
    }
    public void manuallickchangescene()
    {
        gamechecktest = 1;
        SceneManager.LoadScene("mapselectcheck");
    }
}
