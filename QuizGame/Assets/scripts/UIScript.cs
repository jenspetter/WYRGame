using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    private textSetterScript _TSS;
    private touchControlScript _TCS;
    private int adCounter;

    void Awake() {
        _TSS = GetComponent<textSetterScript>();
        _TCS = GetComponent<touchControlScript>();
    }
    void Start() {
        adCounter = 0;
    }
    public void TopButton() {
        if (_TCS.canClick) {
            _TSS.AssignRandom();
            GiveAds();
        }
    }
    public void BottomButton() {
        if (_TCS.canClick) {
            _TSS.AssignRandom();
            GiveAds();
        }
    }
    public void OpenURL(string URL) {
        if (_TCS.canClick) {
            Application.OpenURL(URL);
        }
    }
    void GiveAds() {
        if (_TCS.canClick) {
            adCounter++;

            if (adCounter == 8) {
                Advertisement.Show();
                adCounter = 0;
            }
        }
    }
}
