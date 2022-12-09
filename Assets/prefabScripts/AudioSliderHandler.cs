using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Diagnostics;
using TMPro;

public class AudioSliderHandler : MonoBehaviour
{

    public AudioSource audioSource;
    public Slider audioSlider;

    public void Update(){
        audioSlider.value = audioSource.time;
    }

    public void ChangeAudioTime(){
        audioSource.time = audioSlider.value; 
    }
}
