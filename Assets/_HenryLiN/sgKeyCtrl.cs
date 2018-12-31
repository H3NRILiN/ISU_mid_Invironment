using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sgKeyCtrl : MonoBehaviour {

	public bool isMenuOn=false;
	public Canvas DanceMenu;

	void Start(){
		DanceMenu.gameObject.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.G)) {
			isMenuOn = true;
			DanceMenu.enabled = true;
		} else {
			isMenuOn = false;
			DanceMenu.enabled = false;
		}

	}

}
