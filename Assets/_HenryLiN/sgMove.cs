using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sgMove : MonoBehaviour {

	Animator SGanim;
	sgThirdPcam thcam;
	private CharacterController CC;
	private sgKeyCtrl camstate;
	public float moveFB; 
	public float moveLR;
	public float movespeed=1.5F;
	float turnangle;


	// Use this for initialization
	void Start () {
		CC=GetComponent<CharacterController> ();
		camstate = GetComponent <sgKeyCtrl> ();
		thcam = GetComponent<sgThirdPcam> ();
		SGanim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveFB = Input.GetAxis ("Vertical");
		moveLR = Input.GetAxis ("Horizontal");
		Vector3 moving = new Vector3 (moveLR * Time.deltaTime, 0, 0);

		//CC.Move (transform.up * -0.1f*Time.deltaTime);


		//Debug.Log (transform.eulerAngles.y);


		if (camstate.isMenuOn) 
			CC.Move (Vector3.zero);
		else {
			if (SGanim.GetBool ("isAttacking") == false)
			{
				if (moveFB > 0)
				{
					if(SGanim.GetBool ("isRunning"))
					CC.SimpleMove (gameObject.transform.forward * movespeed*2.5f * moveFB);
					else
						CC.SimpleMove (gameObject.transform.forward * movespeed * moveFB);

					if (Mathf.Abs (moveLR) > 0)
						gameObject.transform.Rotate (0, 5 * moveLR, 0);
				}
				else if (Mathf.Abs (moveLR) > 0)
					CC.SimpleMove (thcam.camlookat.transform.right * movespeed * moveLR);
				else if (moveFB < 0)
					CC.SimpleMove (transform.forward * (movespeed - 0.6f) * moveFB);
			}
			else if (SGanim.GetBool ("isAttacking") == true) {
				transform.rotation = Quaternion.Euler (transform.rotation.x, thcam.camlookat.eulerAngles.y, transform.rotation.z);
				CC.SimpleMove (transform.forward * 0.15f);
				//CC.SimpleMove (Vector3.zero);
			}
			


		}

	}
}
