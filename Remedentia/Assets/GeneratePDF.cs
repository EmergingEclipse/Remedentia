using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Text;

public class GeneratePDF : MonoBehaviour
{
    public TMPro.TextMeshProUGUI PatientText;

    public void GeneratePdfFileAllRepo(){

        string dir = Application.persistentDataPath+"/Resources/Reports/Exports";
        if (!Directory.Exists(dir)){
            Directory.CreateDirectory(dir);
        }
        string time = DateTime.Now.ToString("ddd dd MMM yyy HH':'mm':'ss 'GMT'");
        using (var fileStream = new FileStream(dir+"/AllPatientsReports("+time+").pdf", FileMode.OpenOrCreate, FileAccess.Write)){
            // Create an instance of the document class which represents the PDF document itself.  
            Document document = new Document(PageSize.LETTER, 25, 25, 25, 25);
            // Create an instance to the PDF file by creating an instance of the PDF   
            // Writer class using the document and the filestrem in the constructor.  
            PdfWriter writer = PdfWriter.GetInstance(document, fileStream); 

            // Add meta information to the document  
            document.AddAuthor("Remadentia");
            document.AddTitle("All Reports");
            // Open the document to enable you to write to the document  
            document.Open();  
            // Add a simple and wellknown phrase to the document in a flow layout manner  
            document.Add(new Paragraph(Encoding.UTF8.GetString(CombineReports())));

            // Close the document  
            document.Close();  
            // Close the writer instance  
            writer.Close();  
            // Always close open filehandles explicity  
            fileStream.Close(); 
        }
    }

    
    private string TextToString(){
        return PatientText.text.Trim();
    }

    public void GeneratePdfFilePatient(){
        
        string dir = Application.persistentDataPath+"/Resources/Reports/Exports";
        if (!Directory.Exists(dir)){
            Directory.CreateDirectory(dir);
        }
        string time = DateTime.Now.ToString("ddd dd MMM yyy HH':'mm':'ss 'GMT'");
        using (var fileStream = new FileStream(dir+"/"+TextToString()+"("+time+")"+".pdf", FileMode.OpenOrCreate, FileAccess.Write)){
            // Create an instance of the document class which represents the PDF document itself.  
            Document document = new Document(PageSize.LETTER, 25, 25, 25, 25);
            // Create an instance to the PDF file by creating an instance of the PDF   
            // Writer class using the document and the filestrem in the constructor.  
            PdfWriter writer = PdfWriter.GetInstance(document, fileStream); 

            // Add meta information to the document  
            document.AddAuthor("Remadentia");
            document.AddTitle("Report");

            // Open the document to enable you to write to the document  
            document.Open();  
            // Add a simple and wellknown phrase to the document in a flow layout manner 
            string temp = TextToString().ToUpper()+" REPORT"+"\n\n";
            string dir_file = Application.persistentDataPath+"/Resources/Reports";
            temp += File.ReadAllText(dir_file+"/"+TextToString()+".txt");

            document.Add(new Paragraph(temp));

            // Close the document  
            document.Close();  
            // Close the writer instance  
            writer.Close();  
            // Always close open filehandles explicity  
            fileStream.Close(); 
        }
    }

    private byte[] CombineReports()
    {
        string dir = Application.persistentDataPath+"/Resources/Reports";
        string[] files = Directory.GetFiles(dir);

        string temp = "REPORTS\n\n";
        foreach (string path in files)
        {
            string name = Path.GetFileName(path);
            string extension = Path.GetExtension(path);
            if (!name.Contains("PatientName") && extension.Contains("txt"))
            {
                string header = name.Replace(".txt", "").ToUpper();
                string content = File.ReadAllText(path);
                temp += "<"+header+">"+"\n" + content + "\n\n\n";
            }  
        }
        return Encoding.UTF8.GetBytes(temp);  
    }

    // private void WriteToStorage(byte[] bytes, string fileName){
    //     StreamWriter Writer = new StreamWriter(Application.persistentDataPath + fileName+".pdf");
    //     Writer.Write(bytes);
    //     Writer.Flush();
    //     Writer.Close();
    // }

}
