using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Diagnostics;
using TMPro;
using System.IO;

public class LoadOptions : MonoBehaviour
{
    [SerializeField] private GameObject buttonSortOptionPrefab;
    [SerializeField] private Transform scrollViewPatientContent;
    private bool isLoaded = false;

    public void LoadOptionsItems(){
        if (isLoaded == false){

            string[] options = {"Very Positive","Positive","Nuetral","Negative","Very Negative","Effect","Artist","Title"};
            int number = options.Length;
            for (int i=0; i<number; i++)
            {
                GameObject newSortOptionButton = Instantiate(buttonSortOptionPrefab, scrollViewPatientContent);
                newSortOptionButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = options[i];
            }
            isLoaded = true;
        }
    }
}
