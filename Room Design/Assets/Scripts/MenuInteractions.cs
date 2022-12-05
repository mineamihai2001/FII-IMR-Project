using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteractions : MonoBehaviour
{
    private Dictionary<string, int> Scenes { get; set; }

    public void StartFromScratch()
    {
        Debug.Log("Show main scene! " + Scenes["Main"]);
        SceneManager.LoadScene(Scenes["Main"]);
    }

    public void StartFromTemplate()
    {
        Debug.Log("Show template selector! " + Scenes["Template"]);
        SceneManager.LoadScene(Scenes["Template"]);
    }

    public void Gallery()
    {
        Debug.Log("Show Gallery! " + Scenes["Gallery"]);
        SceneManager.LoadScene(Scenes["Gallery"]);
    }

    private void Awake()
    {
        Scenes = new Dictionary<string, int>();
        Scenes.Add("Landing", 0); // landing scene (eg: Start my VR experience)
        Scenes.Add("Menu", 1); // main menu
        Scenes.Add("Main", 2); // main scene (room builder)
        Scenes.Add("Template", 3); // select template
        Scenes.Add("Gallery", 4); // gallery
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
