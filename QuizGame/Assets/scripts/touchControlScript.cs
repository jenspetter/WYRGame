using UnityEngine;
using System.Collections;

public class touchControlScript : MonoBehaviour {

    public GameObject movingObject;
	private float movingObjectX;

    public bool moving;

	void Awake() {
		movingObjectX = movingObject.transform.position.x;
	}

    void Update() {
		foreach (Touch touch in Input.touches) {
			if(touch.phase == TouchPhase.Began) {
				moving = true;
			}
			if(touch.phase == TouchPhase.Ended) {
				moving = false;
			}
			if (moving == true) {
				movingObjectX += touch.deltaPosition.x * Time.deltaTime;
				movingObject.transform.position = new Vector2 (movingObjectX, 0f);
			}
		}
    }
}
