using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Diagnostics;
using TMPro;

public class SongListButtonHandler : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider audioSlider;
    public Sprite pauseButton;
    public Sprite playButton;
    public Image buttonIcon;
    public Button button;
    public TMPro.TextMeshProUGUI TEXT;
    public TMPro.TextMeshProUGUI CurrentSongEffectText;
    public TMPro.TextMeshProUGUI CurrentSongDisplay;
    public string songName;

    private string GetURL(string fileName)
    {
        var dataset = Resources.Load<TextAsset>("titles_links");
        var splitedDataset = dataset.text.Split(new char[] { '\n' });
        string[] lines = splitedDataset;

        //string[] lines = File.ReadAllLines("Assets/Resources/titles_links.csv");
        foreach (string l in lines)
        {
            string[] info = l.Split(",");
            if (info[0].Contains(fileName))
            {
                return info[1];
            }
        }
        return "";
    }
    public void convert()
    {
        songName = TEXT.text.Trim();
    }
    private void SetCurrentSongEffect(string fileName)
    {

        // var dataset = Resources.Load<TextAsset>("titles_ratings");
        // var splitedDataset = dataset.text.Split(new char[] { '\n' });
        // string[] lines = splitedDataset;
        string dir = Application.persistentDataPath + "/Resources/titles_ratings.csv";
        string[] lines = File.ReadAllLines(dir);
        //string[] lines = File.ReadAllLines("Assets/Resources/titles_ratings.csv");
        foreach (string l in lines)
        {
            string[] info = l.Split(",");

            if (info[0].Contains(fileName))
            {

                if (info[1].Contains("NULL"))
                {
                    CurrentSongEffectText.text = "Unknow Effect\n\nUnknow Behavior";
                }
                else
                {
                    if (info[2].Contains("NULL"))
                    {
                        CurrentSongEffectText.text = info[1] + "\n\n" + "Unknow Behavior";
                    }
                    else
                    {
                        CurrentSongEffectText.text = info[1] + "\n\n" + info[2];
                    }

                }
            }
        }
    }


    public void DownloadAndPlay()
    {

        audioSource.Stop();
        audioSource.clip = null;
        buttonIcon.GetComponent<Image>().sprite = playButton;
        convert();
        UnityEngine.Debug.Log(songName);
        string url = GetURL(songName).Trim();
        UnityEngine.Debug.Log(url);

        SetCurrentSongEffect(songName);
        CurrentSongDisplay.text = "Downloading ... ";

        StartCoroutine(SoundRequest(url, (UnityWebRequest req) =>
        {
            // Get the sound out using a helper downloadhandler
            AudioClip clip = DownloadHandlerAudioClip.GetContent(req);
            // Load the clip into our audio source and play
            CurrentSongDisplay.text = songName;
            audioSource.clip = clip;
            audioSource.Play();

            buttonIcon.GetComponent<Image>().sprite = pauseButton;
            audioSlider.minValue = 0;
            audioSlider.maxValue = audioSource.clip.length;

        }));
    }

    IEnumerator SoundRequest(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.OGGVORBIS))
        {
            yield return req.SendWebRequest();
            callback(req);
        }
    }


}
