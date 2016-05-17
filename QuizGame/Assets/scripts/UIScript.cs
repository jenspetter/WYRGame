using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UIScript : MonoBehaviour {

    private textSetterScript _TSS;
    private int adCounter;

    void Awake() {
        _TSS = GetComponent<textSetterScript>();
    }
    void Start() {
        adCounter = 0;
    }
    public void TopButton() {
        _TSS.AssignRandom();
        GiveAds();
    }
    public void BottomButton() {
        _TSS.AssignRandom();
        GiveAds();
    }
    public void OpenURL(string URL) {
        Application.OpenURL(URL);
    }
    void GiveAds() {
        adCounter++;

        if (adCounter == 4) {
            Advertisement.Show();
            adCounter = 0;
        }
    }
}
