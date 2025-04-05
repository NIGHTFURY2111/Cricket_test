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
        if (StartSlider)
        {
        slider.value = Mathf.PingPong(Time.time *sliderSpeed, 1);
        }
    }

    public void StartSliderFunction()
    {
        StartSlider = true;
    }

    public float StopGetSliderValue()
    {
        StartSlider = false;
        float returnValue = slider.value;
        slider.value = 0;
        return returnValue;

    }

}
