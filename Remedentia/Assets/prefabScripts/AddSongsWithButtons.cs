using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Diagnostics;
using TMPro;
using System.IO;

public class AddSongsWithButtons : MonoBehaviour
{

    public GameObject buttonPrefab;
    public Transform scrollViewContent;

    void Start()
    {
        var dataset = Resources.Load<TextAsset>("titles");
        var splitedDataset = dataset.text.Split(new char[] {'\n'});
        
        // string[] titles = File.ReadAllLines("Assets/Resources/titles.csv");
        string[] titles = splitedDataset;
        int number = titles.Length;

        for (int i=0; i<number; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, scrollViewContent);
            newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = titles[i];
        }


        // On Application start, write all file from assest to internal device internal storage
        string dir_res = Application.persistentDataPath+"/Resources";
        string dir_res_repo = Application.persistentDataPath+"/Resources/Reports";
        string dir_res_repo_expo = Application.persistentDataPath+"/Resources/Reports/Exports";
        // Recources folder
        if(!Directory.Exists(dir_res)){
            Directory.CreateDirectory(dir_res);
            string[] resources = {"titles","titles_links","titles_ratings","titlesSortedArtist","titlesSortedTitle","patientNames"};
            foreach(string fn in resources){
                loadResources(dir_res, fn);
            }
        }
        // Reports folder
        if(!Directory.Exists(dir_res_repo)){
            Directory.CreateDirectory(dir_res_repo);

            var data = Resources.Load<TextAsset>("patientNames");
            var splitedData = data.text.Split(new char[] {'\n'});
            string[] reports = splitedData;
            foreach(string rn in reports){
                loadReports(dir_res_repo, rn);
            }
        }
        // PDF Exports folder
        if(!Directory.Exists(dir_res_repo_expo)){
            Directory.CreateDirectory(dir_res_repo_expo);
        }
      
    }
    private void loadResources(string dir, string filename){
        var dataset = Resources.Load<TextAsset>(filename);
        StreamWriter Writer = new StreamWriter(dir+"/"+filename+".csv");
        Writer.Write(dataset.text);
        Writer.Flush();
        Writer.Close();

    }
    private void loadReports(string dir, string name){
        var dataset = Resources.Load<TextAsset>("Reports/"+name);
        StreamWriter Writer = new StreamWriter(dir+"/"+name+".txt");
        Writer.Write(dataset.text);
        Writer.Flush();
        Writer.Close();
    }
}
