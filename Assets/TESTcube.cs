using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTcube : MonoBehaviour {
	float speed=0;
	float maxspeed=10;
	float A=10;
	float decrease=10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Debug.Log (Input.mousePosition);

		if (Input.GetKey (KeyCode.Space) && speed < maxspeed)
			speed += A * Time.deltaTime;
		else { 
			if (speed > decrease * Time.deltaTime)
				speed -= decrease * Time.deltaTime;
			else if (speed < -decrease * Time.deltaTime)
				speed += decrease * Time.deltaTime;
			else
				speed = 0;
		}

		transform.Translate (speed*Time.deltaTime, 0, 0);
			
	}
}
