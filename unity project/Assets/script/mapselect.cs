using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mapselect : MonoBehaviour
{
    public static int mapselectcheck;
    public void map1selectnextscene()
    {
        mapselectcheck = 0;
        if(gamestart.gamechecktest == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if(gamestart.gamechecktest == 1)
        {
            SceneManager.LoadScene("scenes_you");
        }
    }
    public void map2selectnextscene()
    {
        mapselectcheck = 1;
        if (gamestart.gamechecktest == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (gamestart.gamechecktest == 1)
        {
            SceneManager.LoadScene("scenes_you");
        }
    }
}
