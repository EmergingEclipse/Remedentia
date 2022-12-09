using System.IO;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextArea : MonoBehaviour
{
    public TMP_InputField DoctorsNotes;
    public TMPro.TextMeshProUGUI PatientText;

    // This will return the name of the chosen patient
    private string getPatientName()
    {
        return PatientText.text.Trim();     
    }

    public void ReadReport(){
        
        string dir = Application.persistentDataPath+"/Resources/Reports/"+getPatientName()+".txt";

        if(File.Exists(dir)){
            byte[] bytes = File.ReadAllBytes(dir);
            string textContains = Encoding.UTF8.GetString(bytes);
            DoctorsNotes.text = textContains;

        }
        else{
            File.Create(dir).Dispose();
            byte[] bytes = File.ReadAllBytes(dir);
            string textContains = Encoding.UTF8.GetString(bytes);
            DoctorsNotes.text = textContains;
        }
    

    
    }
}
