using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ClickToPlace2 : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public GameObject placeSurface;
    public float POSITION;

    private GameObject spawnedObject;

    private Vector3 hitPosistion;
    private Vector3 mousePosition;

    private bool IsPlaced { get; set; }

    static readonly Dictionary<string, InputFeatureUsage<bool>> availableButtons = new Dictionary<string, InputFeatureUsage<bool>>
        {
            {"triggerButton", CommonUsages.triggerButton },
            {"thumbrest", CommonUsages.thumbrest },
            {"primary2DAxisClick", CommonUsages.primary2DAxisClick },
            {"primary2DAxisTouch", CommonUsages.primary2DAxisTouch },
            {"menuButton", CommonUsages.menuButton },
            {"gripButton", CommonUsages.gripButton },
            {"secondaryButton", CommonUsages.secondaryButton },
            {"secondaryTouch", CommonUsages.secondaryTouch },
            {"primaryButton", CommonUsages.primaryButton },
            {"primaryTouch", CommonUsages.primaryTouch },
        };

    public enum ButtonOption
    {
        triggerButton,
        thumbrest,
        primary2DAxisClick,
        primary2DAxisTouch,
        menuButton,
        gripButton,
        secondaryButton,
        secondaryTouch,
        primaryButton,
        primaryTouch
    };
    [Tooltip("Input device role (left or right controller)")]
    public InputDeviceRole deviceRole;

    [Tooltip("Select the button")]
    public ButtonOption button;

    [Tooltip("Event when the button starts being pressed")]
    public UnityEvent OnPress;

    [Tooltip("Event when the button is released")]
    public UnityEvent OnRelease;

    // to check whether it's being pressed
    public bool IsPressed { get; private set; }

    // to obtain input devices
    List<InputDevice> inputDevices;
    bool inputValue;

    InputFeatureUsage<bool> inputFeature;

    void Place()
    {
        if (IsPlaced)
        {
            Debug.Log("Frist time click");
            Vector3 newPosition = FormatPosition(hitPosistion);
            spawnedObject = Instantiate(objectToInstantiate, newPosition, Quaternion.identity); // no rotation
        }
    }

    Vector3 FormatPosition(Vector3 position) // returns a position s.t. the object is placed correctly on the plane
    {
        return new Vector3(position.x, POSITION, position.z);
    }

    bool GetHitPosition() // get position where plane is clicked
    {
        if (spawnedObject.GetComponent<DetectCollision>().CanBePlaced)
        {
            hitPosistion = mousePosition;
            IsPlaced = !IsPlaced;
            return true;
        }
        else return false;
    }

    void PlaceHandler()
    {
        if (!GetHitPosition()) return; // plane is not clicked

        Place();
    }

    private void Awake()
    {
        // get label selected by the user
        string featureLabel = Enum.GetName(typeof(ButtonOption), button);

        // find dictionary entry
        availableButtons.TryGetValue(featureLabel, out inputFeature);

        // init list
        inputDevices = new List<InputDevice>();
    }

    // Start is called before the first frame update
    void Start()
    {
        IsPlaced = false;
        Debug.Log("starting...");
    }

    // Update is called once per frame
    void Update()
    {
        InputDevices.GetDevicesWithRole(deviceRole, inputDevices);

        for (int i = 0; i < inputDevices.Count; i++)
        {
            if (inputDevices[i].TryGetFeatureValue(inputFeature,
                out inputValue) && inputValue)
            {
                // if start pressing, trigger event
                if (!IsPressed)
                {
                    IsPressed = true;
                    OnPress.Invoke();
                }
            }

            // check for button release
            else if (IsPressed)
            {
                IsPressed = false;
                OnRelease.Invoke();
            }
        }
        //PlaceHandler();
    }
}
