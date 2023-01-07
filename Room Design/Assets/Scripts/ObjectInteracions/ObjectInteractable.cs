using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectInteractable : XRSimpleInteractable
{
    //TODO make it static and make the singleton take care of it
    private LayerMask floorMask;
    public XRRayInteractor ray;

    private bool isGrabbed = false;


    private void handleGrab()
    {
        Vector3 rayOrigin = ray.transform.position;
        Vector3 rayDirection = ray.transform.forward;
        
        var itHits = Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hitInfo, ray.maxRaycastDistance, floorMask);

        if (itHits)
            transform.position = hitInfo.point;
        else
            transform.position = rayOrigin + rayDirection * 2f;

        Vector3 relativePos = rayOrigin - transform.position;
        relativePos.y = 0;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }

    public void grabHandler(SelectEnterEventArgs args)
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

    public void releaseHandler(SelectExitEventArgs args)
    {
        isGrabbed = false;
    }


    void Start()
    {
        selectEntered.AddListener(grabHandler);
        selectExited.AddListener(releaseHandler);
        floorMask = LayerMask.GetMask("Floor");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            handleGrab();
        }
    }
}
