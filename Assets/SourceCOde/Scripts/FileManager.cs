using System.IO;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FileManager : MonoBehaviour
{

    public TMP_InputField DoctorsNotes; // The report text input field
    public TMPro.TextMeshProUGUI PatientText; // The name of the chosen patient
    private string Textcontain; // The text in text inout field as string

    
    public void convert()
    {
        Textcontain = DoctorsNotes.text;   
    }
    private string getPatientName(){
        return PatientText.text.Trim();
    }
    // Pass the directory of where we want to create a empty report
    public void CreateReport()
    {
        convert();

        string dir = Application.persistentDataPath+"/Resources/Reports/"+getPatientName()+".txt";
        File.Create(dir).Dispose();
        WriteReport(dir, Textcontain);
        DoctorsNotes.text = ""; // Reset the input field
    }
    // This function write a specified report with the text we want
    public void WriteReport(string dir, string Textcontain)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(Textcontain);
        File.WriteAllBytes(dir,bytes);
    }
} 