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
        var textLine = Instantiate(TextLinePrefab, ContentTransform);
        textLine.text = message;
    }

    private List<GameObject> _entries = new List<GameObject>();
}
