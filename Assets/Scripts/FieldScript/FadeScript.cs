using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {
	GameObject player;
	public float fadeSpeed = 0.01f;
	float alfa = 0;
	float red,green,blue;
	public int fadeType = 0;
	// Use this for initialization
	void Start () {
		red = GetComponent<Image> ().color.r;
		green = GetComponent<Image> ().color.g;
		blue = GetComponent<Image> ().color.b;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		switch (fadeType) {

		case 1:
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa += fadeSpeed;
			if (alfa >= 255) {
				fadeType = 0;

			}
			break;

		case 2:
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa -= fadeSpeed;
			if (alfa <= 0) {
				fadeType = 0;
			}
			break;

		}
	}


}
