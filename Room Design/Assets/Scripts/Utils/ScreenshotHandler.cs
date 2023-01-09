using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenshotHandler : MonoBehaviour
{
    private static ScreenshotHandler instance;

    private Camera myCamera;
    private bool takeScreenshotOnNextFrame;

    public InputActionProperty takeButton;

    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if (takeScreenshotOnNextFrame)
        {
            Debug.Log("here");
            takeScreenshotOnNextFrame = false;
            var renderTexture = myCamera.targetTexture;

            var renderResult =
                new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            var rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            var byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenshot.png", byteArray);
            Debug.Log("Saved CameraScreenshot.png");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }

    private void TakeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNextFrame = true;
    }

    public static void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenshot(width, height);
    }

    public void Update()
    {
        // if (takeButton.action.WasPressedThisFrame())
        // {
        //     TakeScreenshot(500, 500);
        //     Debug.Log("Photo taken");
        // }
    }
}