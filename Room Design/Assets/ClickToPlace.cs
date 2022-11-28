using UnityEngine;
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
