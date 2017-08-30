using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButtonScript : MonoBehaviour {
	public int checkCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Check(){
		if (checkCount == 0) {
			checkCount = 1;
		} else if (checkCount == 1) {
			checkCount = 0;
		}
	}
}
