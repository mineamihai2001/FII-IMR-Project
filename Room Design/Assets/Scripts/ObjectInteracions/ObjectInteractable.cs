using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectInteractable : XRSimpleInteractable
{
    public static LayerMask floorMask;
    public static XRRayInteractor ray;
    public static InputActionProperty grabButton;

    private bool isGrabbed = false;
    private bool wasForcedGrabbed = false;
    private Collider colliderComponent;

    private void handleGrab()
    {
        Vector3 rayOrigin = ray.transform.position;
        Vector3 rayDirection = ray.transform.forward;
        
        var itHits = Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hitInfo, ray.maxRaycastDistance, floorMask);

        if (itHits)
        {
            var relativeColliderCenter = gameObject.transform.position.y - colliderComponent.bounds.center.y;
            var halfHeight = colliderComponent.bounds.extents.y + relativeColliderCenter;
            transform.position = hitInfo.point + new Vector3(0, halfHeight, 0);
        }
        else
            transform.position = rayOrigin + rayDirection * 2f;

        Vector3 relativePos = rayOrigin - transform.position;
        relativePos.y = 0;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }

    private void GrabHandler(SelectEnterEventArgs args)
    {
        //var obj = args.interactorObject;
        //if (obj != ray)
        //{
        //    Debug.LogError("Wrong hand");
        //    return;
        //}
        //Debug.Log("Grabbed");
        isGrabbed = true;
    }

    private void ReleaseHandler(SelectExitEventArgs args)
    {
        isGrabbed = false;
    }

    public void ForceGrab()
    {
        isGrabbed = true;
        wasForcedGrabbed = true;
    }

    void Start()
    {
        selectEntered.AddListener(GrabHandler);
        selectExited.AddListener(ReleaseHandler);
        colliderComponent = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wasForcedGrabbed && grabButton.action.WasReleasedThisFrame() )
        {
            wasForcedGrabbed = false;
            isGrabbed = false;
        }
        if (isGrabbed)
        {
            handleGrab();
        }
    }
}
