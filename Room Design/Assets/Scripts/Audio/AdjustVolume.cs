using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustVolume : MonoBehaviour
{
    public GameObject AudioController;
    public GameObject Slider;
    public GameObject MuteBtn;


    public void ChangeVolume(float value)
    {
        AudioController.GetComponent<AudioSource>().volume = value;
    }

    public void OnValueChanged(float value)
    {
        Debug.Log("Changing the value in here " + value);
        ChangeVolume(value);
    }

    public void Mute()
    {
        ChangeVolume(0);
    }

    // Start is called before the first frame update
    private void Start()
    {
        var initial = AudioController.GetComponent<AudioSource>().volume;
        Debug.Log("here " + initial);
        Slider.GetComponent<Slider>().value = initial;
    }
}