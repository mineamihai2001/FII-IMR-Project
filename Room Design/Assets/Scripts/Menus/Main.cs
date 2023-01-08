using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : ScenesManager
{
    public void StartFromScratch()
    {
        SetScene("Main");
    }

    public void StartFromTemplate()
    {
        SetScene("Template");
    }

    public void Gallery()
    {
        SetScene("Gallery");
    }
    
}