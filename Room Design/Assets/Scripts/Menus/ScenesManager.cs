using System;
using System.Collections;
using System.Collections.Generic;
using Menus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private Stack<int> history { get; set; }
    private List<AppScene> Scenes { get; set; }
    private int Current { get; set; }

    protected int GetScene(string sceneName)
    {
        return Scenes.FindIndex(s => s.Name == sceneName);
    }

    protected void SetScene(string sceneName)
    {
        Print();
        history.Push(Current);

        Current = GetScene(sceneName);
        SceneManager.LoadScene(Current);
        Print(); // TODO: remove later
    }

    protected void Print()
    {
        Debug.LogFormat("Showing scene {0}.", Current);
    }

    protected void Back()
    {
        Current = history.Pop();
        SceneManager.LoadScene(Current);
        Print();
    }

    private void Instantiate()
    {
        Current = SceneManager.GetActiveScene().buildIndex;
        history = new Stack<int>();
        Scenes =
            new List<AppScene> // if scenes are added to the list they need to respect the index from Project Build
            {
                new AppScene("Menu"),
                new AppScene("Main"),
                new AppScene("Template"),
                new AppScene("Gallery")
            };
    }

    private void Awake()
    {
        Debug.Log("please recompile " + 1 + 2);
        Instantiate();
    }
}