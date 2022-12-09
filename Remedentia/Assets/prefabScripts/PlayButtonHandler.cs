using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Diagnostics;

public class PlayButtonHandler : MonoBehaviour
{

    public AudioSource audioSource;
    public Sprite pauseButton;
    public Sprite playButton;
    public Image buttonIcon;
    public void PlayOrPause()
    {
        if (audioSource.clip != null){
            if (audioSource.isPlaying){
                audioSource.Pause();
                buttonIcon.GetComponent<Image>().sprite = playButton;
            }
            else{
                audioSource.Play();
                buttonIcon.GetComponent<Image>().sprite = pauseButton;
            }
        }   
    }


}
