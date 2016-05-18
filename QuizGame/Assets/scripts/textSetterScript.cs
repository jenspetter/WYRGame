using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class textSetterScript : MonoBehaviour {

    public Text topText; 
    public Text bottomText;

    private textImporterScript _TIS;

    private List<string> topOptions = new List<string>();
    private List<string> bottomOptions = new List<string>();

    void Awake() {
        _TIS = GetComponent<textImporterScript>();
    }
    void Start() {
        StartCoroutine(waitAndAssign());
    }
    IEnumerator waitAndAssign() {
        yield return new WaitForSeconds(0.0001f);
        for (int i = 0; i < _TIS.topOptions.Count; i++) {
            topOptions.Add(_TIS.topOptions[i]);
        }
        for (int i = 0; i < _TIS.bottomOptions.Count; i++) {
            bottomOptions.Add(_TIS.bottomOptions[i]);
        }
        AssignRandom();
    }
    public void AssignRandom() {

        if (topOptions.Count == 0) {
            for (int i = 0; i < _TIS.topOptions.Count; i++) {
                topOptions.Add(_TIS.topOptions[i]);
            }
            for (int i = 0; i < _TIS.bottomOptions.Count; i++) {
                bottomOptions.Add(_TIS.bottomOptions[i]);
            }
        }
        else {
            int r = Random.Range(0, topOptions.Count);

            topText.text = topOptions[r];
            bottomText.text = bottomOptions[r];

            topOptions.Remove(topOptions[r]);
            bottomOptions.Remove(bottomOptions[r]);
        }
    }
}
