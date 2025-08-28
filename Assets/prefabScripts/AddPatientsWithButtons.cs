using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Diagnostics;
using TMPro;
using System.IO;

public class AddPatientsWithButtons : MonoBehaviour
{

    public GameObject buttonPatientPrefab;
    public Transform scrollViewPatientContent;
    private bool isLoaded = false;
    // preloading all patients in patient lists
    public void LoadPatients()
    {
        if (isLoaded == false){

            var dataset = Resources.Load<TextAsset>("patientNames");
            var splitedDataset = dataset.text.Split(new char[] {'\n'});

            string[] titles = splitedDataset;
            int number = titles.Length;

            for (int i=0; i<number; i++)
            {
                GameObject newPatientButton = Instantiate(buttonPatientPrefab, scrollViewPatientContent);
                newPatientButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = titles[i];
            }
            isLoaded = true;
        }
      
    }
}
