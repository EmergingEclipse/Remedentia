using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Diagnostics;
using TMPro;

public class SortOptionHandler : MonoBehaviour
{
    public TMPro.TextMeshProUGUI TEXT;
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private GameObject sortButtonPrefab;

    //sorting songs based on different options based on rating, artist, or title
    public void ApplySortOption()
    {

        if (TextToString().Contains("Title"))
        {
            SortAndLoad_Title();
        }
        if (TextToString().Contains("Artist"))
        {
            SortAndLoad_Artist();
        }

        //Sorted by all five different effects
        if (TextToString().Equals("Very Positive"))
        {
            SortAndLoadEffect("Very Positive");
        }
        if (TextToString().Equals("Positive"))
        {
            SortAndLoadEffect("Positive");
        }
        if (TextToString().Equals("Nuetral"))
        {
            SortAndLoadEffect("Nuetral");
        }
        if (TextToString().Equals("Negative"))
        {
            SortAndLoadEffect("Negative");
        }
        if (TextToString().Equals("Very Negative"))
        {
            SortAndLoadEffect("Very Negative");
        }

        if (TextToString().Equals("Effect"))
        {
            SortAndLoadEffectAll();
        }

    }


    private string TextToString()
    {
        return TEXT.text.Trim();
    }
    private void DestroyClones()
    {
        var clones = GameObject.FindGameObjectsWithTag("song");
        for (int i = 1; i < clones.Length; i++)
        {
            Destroy(clones[i]);
        }
    }

    private void SortAndLoad_Title()
    {
        DestroyClones();

        var dataset = Resources.Load<TextAsset>("titlesSortedTitle");
        var splitedDataset = dataset.text.Split(new char[] { '\n' });
        string[] titles = splitedDataset;
        UnityEngine.Debug.Log(titles.Length + " objects loaded");

        //string[] titles = File.ReadAllLines("Assets/Resources/SortedSongList/titlesSortedTitle.csv");
        int number = titles.Length;

        for (int i = 0; i < number; i++)
        {
            GameObject newButton = Instantiate(sortButtonPrefab, scrollViewContent);
            newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = titles[i];
        }


    }
    private void SortAndLoad_Artist()
    {
        DestroyClones();

        var dataset = Resources.Load<TextAsset>("titlesSortedArtist");
        var splitedDataset = dataset.text.Split(new char[] { '\n' });
        string[] titles = splitedDataset;
        UnityEngine.Debug.Log(titles.Length + " objects loaded");

        //string[] titles = File.ReadAllLines("Assets/Resources/SortedSongList/titlesSortedArtist.csv");
        int number = titles.Length;

        for (int i = 0; i < number; i++)
        {
            GameObject newButton = Instantiate(sortButtonPrefab, scrollViewContent);
            newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = titles[i];
        }

    }



    private void SortAndLoadEffect(string effect)
    {

        DestroyClones();

        // var dataset = Resources.Load<TextAsset>("titles_ratings");
        // var splitedDataset = dataset.text.Split(new char[] {'\n'});
        // string[] lines = splitedDataset;

        string dir = Application.persistentDataPath + "/Resources/titles_ratings.csv";
        string[] lines = File.ReadAllLines(dir);
        int length = lines.Length;
        //string[] lines = File.ReadAllLines("Assets/Resources/titles_ratings.csv");
        for (int i = 0; i < length; i++)
        {
            string[] list = lines[i].Split(",");
            if (list[1].Trim().Equals(effect))
            {
                GameObject newButton = Instantiate(sortButtonPrefab, scrollViewContent);
                newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = list[0];
            }
        }
        for (int i = 0; i < length; i++)
        {
            string[] list = lines[i].Split(",");
            if (!list[1].Trim().Equals(effect))
            {
                GameObject newButton = Instantiate(sortButtonPrefab, scrollViewContent);
                newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = list[0];
            }
        }

    }


    // Sorting all the effects at the same time
    // A stupid algorithm to avoid debugging
    private void SortAndLoadEffectAll()
    {

        DestroyClones();

        // var dataset = Resources.Load<TextAsset>("titles_ratings");
        // var splitedDataset = dataset.text.Split(new char[] { '\n' });
        // string[] lines = splitedDataset;


        string dir = Application.persistentDataPath + "/Resources/titles_ratings.csv";
        string[] lines = File.ReadAllLines(dir);
        // string[] lines = File.ReadAllLines("Assets/Resources/titles_ratings.csv");
        string[] sortedList = new string[lines.Length];
        int index = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string[] list = lines[i].Split(",");
            if (list[1].Trim().Equals("Very Positive"))
            {
                sortedList[index] = list[0];
                index++;
            }
        }
        for (int i = 0; i < lines.Length; i++)
        {
            string[] list = lines[i].Split(",");
            if (list[1].Trim().Equals("Positive"))
            {
                sortedList[index] = list[0];
                index++;
            }
        }
        for (int i = 0; i < lines.Length; i++)
        {
            string[] list = lines[i].Split(",");
            if (list[1].Trim().Equals("Nuetral"))
            {
                sortedList[index] = list[0];
                index++;
            }
        }
        for (int i = 0; i < lines.Length; i++)
        {
            string[] list = lines[i].Split(",");
            if (list[1].Trim().Equals("Negative"))
            {
                sortedList[index] = list[0];
                index++;
            }
        }
        for (int i = 0; i < lines.Length; i++)
        {
            string[] list = lines[i].Split(",");
            if (list[1].Trim().Equals("Very Negative"))
            {
                sortedList[index] = list[0];
                index++;
            }
        }
        for (int i = 0; i < lines.Length; i++)
        {
            string[] list = lines[i].Split(",");
            if (list[1].Trim().Equals("NULL"))
            {
                sortedList[index] = list[0];
                index++;
            }
        }

        int number = sortedList.Length;

        for (int i = 0; i < number; i++)
        {
            GameObject newButton = Instantiate(sortButtonPrefab, scrollViewContent);
            newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = sortedList[i];
        }
    }
}
