using UnityEngine;
using System.Collections;

public class touchControlScript : MonoBehaviour {

    public GameObject movingObject;
	private float movingObjectX;

    public GameObject otherObject;
    private GameObject parentScreen;
    private GameObject parentCanvas;

    private bool moving;

    [HideInInspector]
    public bool canClick;

    private Vector3 lastMousePosition;

    void Awake() {
        parentScreen = GameObject.FindGameObjectWithTag("Screen");
        parentCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }
    void Start() {
        Mathf.Clamp(otherObject.GetComponent<RectTransform>().position.x, -10, 10);
    }
    void Update() {
		foreach (Touch touch in Input.touches) {
			if(touch.phase == TouchPhase.Moved) {
				moving = true;
			}
			if(touch.phase == TouchPhase.Ended) {
				moving = false;
                //otherObject.transform.SetParent(parentCanvas.transform);
            }
			if (moving == true) {
                canClick = false;
                movingObjectX = movingObject.transform.position.x;
                movingObjectX += touch.deltaPosition.x * Time.deltaTime;
				movingObject.transform.position = new Vector2 (movingObjectX, 0f);


                Debug.Log(otherObject.GetComponent<RectTransform>().position.x);
                //left border
                /*
                if (movingObject.GetComponent<RectTransform>().transform.localPosition.x >= 0 && movingObject.GetComponent<RectTransform>().transform.localPosition.x <= 275) {
                    otherObject.transform.SetParent(parentCanvas.transform);
                }
                else {
                    otherObject.transform.SetParent(parentScreen.transform);
                } 
                */  
			}     
		}
        if (!moving) {
            canClick = true;
            //move to the right;
            if (movingObject.transform.localPosition.x <= -135 && movingObject.transform.localPosition.x > -340) {
                movingObject.GetComponent<RectTransform>().localPosition = Vector2.MoveTowards(movingObject.GetComponent<RectTransform>().localPosition, new Vector2(-275f, 0), 400 * Time.deltaTime);
            }
            //move to the left;
            else if (movingObject.transform.localPosition.x > -135 && movingObject.transform.localPosition.x < 0) {
                movingObject.GetComponent<RectTransform>().localPosition = Vector2.MoveTowards(movingObject.GetComponent<RectTransform>().localPosition, new Vector2(0, 0), 400 * Time.deltaTime);
            }
            else if (movingObject.transform.localPosition.x > 0) {
                movingObject.GetComponent<RectTransform>().localPosition = Vector2.MoveTowards(movingObject.GetComponent<RectTransform>().localPosition, new Vector2(0, 0), 900 * Time.deltaTime);
            }
            else if (movingObject.transform.localPosition.x < -340) {
                movingObject.GetComponent<RectTransform>().localPosition = Vector2.MoveTowards(movingObject.GetComponent<RectTransform>().localPosition, new Vector2(-275f, 0), 900 * Time.deltaTime);
            }
        }
    }
}
