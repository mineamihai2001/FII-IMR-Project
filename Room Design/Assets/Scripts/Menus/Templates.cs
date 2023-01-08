using System.Collections;
using System.Collections.Generic;
using Builder;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Templates : ScenesManager
{
    private const string NextScene = "Main";

    public void GenerateLivingRoom()
    {
        StaticStorage.Template = "livingRoom";
        SetScene(NextScene);
    }

    public void GenerateBathRoom()
    {
        StaticStorage.Template = "bathRoom";
        SetScene(NextScene);
    }

    public void GenerateEmpty()
    {
        StaticStorage.Template = "emptyRoom";
        SetScene(NextScene);
    }
}