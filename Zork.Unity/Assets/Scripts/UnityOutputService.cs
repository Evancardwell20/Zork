using Zork.Common;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class UnityOutputService : MonoBehaviour, IOutputService
{
    [SerializeField]
    private TextMeshProUGUI TextLinePrefab;

    [SerializeField]
    private Image NewLinePrefab;
    
    [SerializeField]
    private Transform ContentTransform;
    
    [SerializeField]
    [Range(0,100)]
    private int maxEntries;
    //Queue

    public void Write(object obj)
    {
        ParseWriteLine(obj.ToString());
    }

    public void Write(string message)
    {
        ParseWriteLine(message);
    }

    public void WriteLine(object obj)
    {
        ParseWriteLine(obj.ToString());
    }

    public void WriteLine(string message)
    {
        ParseWriteLine(message);
    }

    private void ParseWriteLine(string message)
    {
        //if entries.count >= maxEntries 
        //look for \n to convert to new line in Unity
        var textLine = Instantiate(TextLinePrefab, ContentTransform);
        textLine.text = message;
    }

    private List<GameObject> _entries = new List<GameObject>();
}
