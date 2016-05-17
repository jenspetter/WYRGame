using UnityEngine;
using System.Collections;

public class touchControlScript : MonoBehaviour {

    public GameObject movingObject;
    public bool moving;

    void Update() {
        if (Input.touchCount > 1) {
            Touch touch = Input.GetTouch(1);

            if (touch.phase == TouchPhase.Began) {
                moving = true;
            }
            if (touch.phase == TouchPhase.Ended) {
                moving = false;
            }
        }
    }
}
