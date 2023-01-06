using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteractable : MonoBehaviour
{
    public GameObject anchor;
    public Transform lookAt;
    public float rotationScale = 256.0f;
    public float traslateScale = 10.0f;

    public InputActionProperty rotateButton; // LeftClick
    public InputActionProperty moveButton; // should be "M"

    private bool RotationToggle { get; set; }
    private bool MoveToogle { get; set; }

    private Vector3 InitialAnchorPosition { get; set; }
    private Vector3 ObjectInitialPosition { get; set; }

    private void RotateHandler()
    {
        RotationToggle = rotateButton.action.WasPressedThisFrame() ? SwitchRotationToggle() : RotationToggle;

        if (RotationToggle)
        {
            Debug.Log("Rotate object activated");
            var anchorRotation = anchor.transform.rotation;
            var rotation = new Vector3(0, anchorRotation.y, 0);
            this.transform.Rotate(rotation);
        }
    }

    private void MoveHandler()
    {
        MoveToogle = moveButton.action.WasPressedThisFrame() ? SwitchMoveToggle() : MoveToogle;

        if (MoveToogle)
        {
            var anchorPosition = anchor.transform.position;

            var move = anchorPosition - InitialAnchorPosition;
            this.transform.Translate(move.x / traslateScale, 0, move.z / traslateScale);
        }
    }

    private bool SwitchMoveToggle()
    {
        Debug.Log("Move is now " + MoveToogle);
        InitialAnchorPosition = anchor.transform.position;
        return !MoveToogle;
    }

    private bool SwitchRotationToggle()
    {
        Debug.Log("Rotate is now " + RotationToggle);
        return !RotationToggle;
    }

    private void Awake()
    {
        RotationToggle = false;
        MoveToogle = false;
        InitialAnchorPosition = anchor.transform.position;
        ObjectInitialPosition = this.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        RotateHandler();
        MoveHandler();
    }
}
