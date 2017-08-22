using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadClickCheck : MonoBehaviour {
	public int padClick;
	// Use this for initialization
	void Start () {
		padClick = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PadClickDown(){
		Debug.Log ("Click1");
		padClick = 1;
	}
	public void PadClickUp(){
		Debug.Log ("Click2");
		padClick = 0;
	}
}
