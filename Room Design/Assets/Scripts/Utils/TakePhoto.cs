using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakePhoto : MonoBehaviour
{
    public InputActionProperty takeButton;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Update()
    {
        if (takeButton.action.WasPressedThisFrame())
        {
            Debug.Log("Take photo");
            ScreenshotHandler.TakeScreenshot_Static(500, 500);
        }
    }
}