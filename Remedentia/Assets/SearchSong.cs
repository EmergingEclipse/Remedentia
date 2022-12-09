using System.IO;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchSong : MonoBehaviour
{

    public TMP_InputField input;
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private GameObject buttonPrefab;

    private string TextToString(){
        return input.text.Trim();
    }

    // Destroy button prefabs which is used to display a list of songs
    public void DestroyClones(){
        var clones = GameObject.FindGameObjectsWithTag ("song");
        for (int i=1; i<clones.Length; i++){
            Destroy(clones[i]);
        }
    }

    // Search the song according to the user input
    public void searchSong(){

        var dataset = Resources.Load<TextAsset>("titles");
        var splitedDataset = dataset.text.Split(new char[] { '\n' });
        string[] titles = splitedDataset;
        //string[] titles = File.ReadAllLines("Assets/Resources/titles.csv");
        int number = titles.Length;
        Debug.Log("Serching For: "+TextToString());

        if (TextToString() == null || TextToString() == ""){

            for (int i=0; i<number; i++)
            {
                GameObject newButton = Instantiate(buttonPrefab, scrollViewContent);
                newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = titles[i];
            }

        }
        else{
            for (int i=0; i<number; i++){

                if (titles[i].ToLower().Contains(TextToString().ToLower())){
                    GameObject newButton = Instantiate(buttonPrefab, scrollViewContent);
                    newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = titles[i];
                }
            }
        }

    }
     



}
