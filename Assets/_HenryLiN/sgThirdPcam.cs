using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sgThirdPcam : MonoBehaviour {
	private CharacterController CC; //動畫控制器

	private sgKeyCtrl KeyCtrl; //按鍵控制腳本

	private sgMove Move; //動畫控制腳本

	public GameObject FollowCam; //攝影機全體
	public Transform camlookat; //第三人稱CAM
	public Transform camRight; //右邊
	public Transform camLeft; //左邊
	public Transform camCenter; //中央

	float rotateX =0;
	float rotateY=0;
	float mX;
	float mY;

	public float Xspeed=100;
	public float Yspeed=120;
	public float limitXmax = 50;
	public float limitXmin = -40;

	public float overrotate = 15;





	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		KeyCtrl = GetComponent<sgKeyCtrl> ();
		Move = GetComponent<sgMove> ();
		CC=GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		FollowCam.transform.position =new Vector3(transform.position.x,transform.position.y+1,transform.position.z);
		camlookat.position = camCenter.position;



		if (KeyCtrl.isMenuOn) {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		} else {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		


	}
	void LateUpdate(){

		if (KeyCtrl.isMenuOn)
			print ("選單開啟");
		else{
			mX = Input.GetAxis ("Mouse X");
			mY = Input.GetAxis ("Mouse Y");
			rotateX += mY * Xspeed * Time.deltaTime;
			rotateY += mX * Yspeed * Time.deltaTime;

			Quaternion ScamPos = Quaternion.Euler (rotateX, rotateY, 0);
			rotateX = Mathf.Clamp (rotateX, limitXmin, limitXmax);


			camlookat.rotation = ScamPos;
			if (Move.moveFB==0&&Mathf.Abs( Move.moveLR)>0) {
				gameObject.transform.rotation=Quaternion.Euler (0,camlookat.transform.eulerAngles.y,0);
			} 
			else if (Move.moveFB == 1 && Move.moveLR == 1)
			{
				
			}
			 else
			{
				
			}

		}
	}
}
