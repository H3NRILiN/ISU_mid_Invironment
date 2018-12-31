using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirrdcam : MonoBehaviour {
	public Transform camcenter;
	public Transform camcenterR;
	public Transform camcenterL;

	float moveX;
	float moveY;
	float rotateX=0.0f;
	float rotateY=0.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		moveX = Input.GetAxis ("Mouse X");
		moveY = Input.GetAxis ("Mouse Y");
		rotateX+=moveX;
		rotateY += moveY;





		//camcenter.transform.Rotate (0, moveX * 15, 0);
		//transform.RotateAround(camcenter.transform.position,Vector3.up,moveX*15);

		//transform.RotateAround(camcenter.transform.position,camcenter.transform.right,moveY*15);
		transform.rotation=Quaternion.Euler(rotateY,rotateX , 0) ;
		//transform.LookAt (camcenter.transform);
	}

}
