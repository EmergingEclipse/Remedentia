using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Diagnostics;
using TMPro;

public class RecordBehaviors : MonoBehaviour
{
    public TMPro.TextMeshProUGUI CurrentSongDisplay;
    public TMPro.TextMeshProUGUI CurrentSongEffectText;
    public TMPro.TextMeshProUGUI ChosenBehavior;
    private string behavior;


    public string TextToString(){
        return CurrentSongDisplay.text.Trim();
    }
    public void TextChosenBehaviorToString(){
        behavior = ChosenBehavior.text.Trim();
    }

    public void RecordBehavior(){

        TextChosenBehaviorToString();

        //string[] lines = File.ReadAllLines("Assets/Resources/titles_ratings.csv");
        string dir = Application.persistentDataPath+"/Resources/titles_ratings.csv";
        string[] lines = File.ReadAllLines(dir); 
        for (int i=0; i<lines.Length; i++)
        {
            string[] info = lines[i].Split(",");
            
            if (info[0].Contains(TextToString()))
            {
                lines[i] = info[0]+","+info[1]+","+behavior;
                CurrentSongEffectText.text = info[1]+"\n\n"+behavior;
                break;
            }
        }
        UnityEngine.Debug.Log("Upadting File ...");
        File.WriteAllLines(dir,lines);
        UnityEngine.Debug.Log("File Updated ...");
    }
}
