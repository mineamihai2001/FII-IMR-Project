using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public Color fail;
    public Color success;

    public bool CanBePlaced { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        CanBePlaced = true;
        ChangeColor(true);
    }

    void ChangeColor(bool status)
    {
        Color col = status ? success : fail;
        gameObject.GetComponent<Renderer>().material.color = col;
    }

    private void OnTriggerEnter(Collider other)
    {
        CanBePlaced = false;
        ChangeColor(false);
    }

    private void OnTriggerExit(Collider other)
    {
        CanBePlaced = true;
        ChangeColor(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
