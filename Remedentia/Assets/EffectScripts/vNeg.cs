using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Diagnostics;
using TMPro;

public class vNeg : MonoBehaviour {

    public TMPro.TextMeshProUGUI CurrentSongDisplay;
    public TMPro.TextMeshProUGUI CurrentSongEffectText;

    public string TextToString(){
        return CurrentSongDisplay.text.Trim();
    }

    public void RecordEffect(){

        string dir = Application.persistentDataPath+"/Resources/titles_ratings.csv";
        string[] lines = File.ReadAllLines(dir);
        for (int i=0; i<lines.Length; i++)
        {
            string[] info = lines[i].Split(",");
            
            if (info[0].Contains(TextToString()))
            {
                lines[i] = info[0]+",Very Negative,"+info[2];

                if (info[2].Contains("NULL"))
                {
                    CurrentSongEffectText.text = "Very Negative\n\nUnknown Behavior";
                }
                else{
                    CurrentSongEffectText.text = "Very Negative\n\n"+info[2];
                }

                break;
            }
        }
        UnityEngine.Debug.Log("Upadting File ...");
        File.WriteAllLines(dir,lines);
        UnityEngine.Debug.Log("File Updated ...");

    }


}
