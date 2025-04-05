using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFunctions : MonoBehaviour
{
    [SerializeField] float sliderSpeed = 1f; // Speed of the slider movement
    bool StartSlider = false;

    Slider slider;


    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
        slider.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        slider.value = (StartSlider) ? Mathf.PingPong(Time.time *sliderSpeed, 1):0;
    }

    public void StartSliderFunction()
    {
        StartSlider = true;
    }

    public float StopGetSliderValue()
    {
        float returnValue = slider.value;
        StartSlider = false;
        return returnValue;

    }

}
