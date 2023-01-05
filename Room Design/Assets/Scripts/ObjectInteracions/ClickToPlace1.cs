using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToPlace : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public GameObject placeSurface;
    public float POSITION;

    private GameObject spawnedObject;

    private Vector3 hitPosistion;
    private Vector3 mousePosition;

    private bool IsPlaced { get; set; }


    bool IsTriggered() // TODO: change trigger for VR
    {
        return Input.GetMouseButtonDown(0) ? true : false;
    }
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

    void MoveObject()
    {
        spawnedObject.transform.position = FormatPosition(mousePosition);
    }

    bool GetHitPosition() // get position where plane is clicked
    {
        if (IsTriggered())
        {
            if (spawnedObject == null || spawnedObject.GetComponent<DetectCollision>().CanBePlaced)
            {
                hitPosistion = mousePosition;
                IsPlaced = !IsPlaced;
                return true;
            } else return false;
        }
        return false;
    }

    void GetPosition() // get the mouse position on plane
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            var hoveredObject = hit.collider.gameObject.name;
            var found = GameObject.Find(hoveredObject);
            if (GameObject.ReferenceEquals(found, placeSurface))
            {
                mousePosition = hit.point;
                if (IsPlaced == true)
                {
                    MoveObject();
                }
            }
        }
    }

    void PlaceHandler()
    {
        GetPosition(); // always get the mouse position
        if (!GetHitPosition()) return; // plane is not clicked

        Place();
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
        PlaceHandler();
    }
}
