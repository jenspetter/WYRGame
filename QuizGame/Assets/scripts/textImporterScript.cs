using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class textImporterScript : MonoBehaviour {

    public TextAsset textFile;

    private string[] optionsLines;

    [HideInInspector]
    public List<string> topOptions = new List<string>();
    [HideInInspector]
    public List<string> bottomOptions = new List<string>();

    void Start () {
	    optionsLines = textFile.text.Split('\n');

        foreach (string line in optionsLines) {
            if (line.StartsWith("TQ.")) {

                string temp = line.Replace("TQ. ", "");

                topOptions.Add(temp);
            }
            else if (line.StartsWith("BQ.")) {

                string temp = line.Replace("BQ. ", "");

                bottomOptions.Add(temp);
            }
        }
    }
}