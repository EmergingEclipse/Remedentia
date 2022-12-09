using System.IO;
using UnityEngine;

public class FileEncryptor : MonoBehaviour
{
    private string filePath;
    private string PIN;

    public FileEncryptor()
    {
        
    }

    // Set the file to encrypt or decrypt 
    public void SetFile(string source)
    {
        filePath = source;
    }

    public void SetPIN(string PIN)
    {
        this.PIN = PIN;
    }

    public void Encrypt()
    {
        byte[] bytes = File.ReadAllBytes(filePath);
        byte[] P = new byte[PIN.Length];
        for(int i=0; i<PIN.Length; i++)
        {
            P[i] = (byte)PIN[i];
        }

        byte[] encrypted = new byte[bytes.Length];
        int count = 0;
        for (int i=0; i<bytes.Length; i++)
        {
            encrypted[i] = (byte)(bytes[i] - P[count]);
            count++;
            if (count == P.Length)
            {
                count = 0;
            }
        }
        File.WriteAllBytes(filePath, encrypted);
    }

    public void Decrypt()
    {
        byte[] bytes = File.ReadAllBytes(filePath);
        byte[] P = new byte[PIN.Length];
        for(int i=0; i<PIN.Length; i++)
        {
            P[i] = (byte)PIN[i];
        }

        byte[] decrypted = new byte[bytes.Length];
        int count = 0;
        for (int i=0; i<bytes.Length; i++)
        {
            decrypted[i] = (byte)(bytes[i] + P[count]);
            count++;
            if (count == P.Length)
            {
                count = 0;
            }
        }
        File.WriteAllBytes(filePath, decrypted);
    }
    
}