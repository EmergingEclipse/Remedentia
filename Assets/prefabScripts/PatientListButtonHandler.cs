using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Diagnostics;
using TMPro;

public class PatientListButtonHandler : MonoBehaviour
{
    public TMPro.TextMeshProUGUI ChosenPatientText;
    public TMPro.TextMeshProUGUI PatientText;
    private string patientName;


    public void DisplayChosenPatientName()
    {
        convert();
        PatientText.text = patientName;
    }


    public void convert()
    {
        patientName = ChosenPatientText.text.Trim();
    }


}
