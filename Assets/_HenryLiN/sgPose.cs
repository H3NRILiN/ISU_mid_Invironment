using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sgPose : MonoBehaviour {

	private Animator SGanim;
	private sgKeyCtrl keyctrl;
	public Button dance1;
	public Button dance2;
	public Button dance3;
	public GameObject sword;
	public GameObject shield;
	float timer=0;

	// Use this for initialization
	void Start () {
		SGanim = GetComponent<Animator> ();
		keyctrl = GetComponent<sgKeyCtrl> ();
		dance1.onClick.AddListener (Dance1);
		dance2.onClick.AddListener (Dance2);
		dance3.onClick.AddListener (Dance3);
		SGanim.SetBool ("isRunning", false);
		SGanim.SetBool ("isAttacking", false);
		SGanim.SetBool ("isDancing", false);
		SGanim.SetBool ("isWalking", false);

	}

	// Update is called once per frame
	void Update () {

		float fV = Input.GetAxis ("Vertical");
		float fH = Input.GetAxis ("Horizontal");
		//////////////////////////////////////////跳舞選單開啟
		if (keyctrl.isMenuOn) {
			SGanim.SetFloat ("walkV", 0);
			SGanim.SetFloat ("walkH", 0);
		} else {
			SGanim.SetFloat ("walkV", fV);
			SGanim.SetFloat ("walkH", fH);

		}
		//////////////////////////////////////////正在走
		if (fV > 0 || fH > 0) {
			SGanim.SetBool ("isWalking", true);
			SGanim.SetBool ("isDancing", false);
		} else if (SGanim.GetBool ("isAttacking")==true) {
			SGanim.SetBool ("isWalking", false);
			SGanim.SetBool ("isDancing", false);
		}
		else
			SGanim.SetBool ("isWalking", false);

		//////////////////////////////////////////正在跳舞
		if (SGanim.GetBool("isDancing")==true) {
			sword.SetActive (false);
			shield.SetActive (false);
		} else {
			sword.SetActive (true);
			shield.SetActive (true);
		}
		//////////////////////////////////////////攻擊動作
		if (SGanim.GetBool ("isDancing") == false && keyctrl.isMenuOn == false&&SGanim.GetBool ("isRunning")==false) {
			if (Input.GetMouseButtonDown(0)) {
				SGanim.SetBool ("isAttacking", true);
				timer= Time.time;
			}
			else if(Time.time-timer>=0.5&&SGanim.GetCurrentAnimatorStateInfo(0).IsTag("ATK")==false)
				SGanim.SetBool ("isAttacking", false);
		}
		//////////////////////////////////////////跑步
		if(Input.GetKey(KeyCode.LeftShift)&&SGanim.GetBool ("isDancing") == false&&fV > 0)
			SGanim.SetBool ("isRunning",true);
		else
			SGanim.SetBool ("isRunning",false);
			


		//transform.Translate (fH*Time.deltaTime, 0, fV*Time.deltaTime);
	}
	public void Dance1(){
		SGanim.SetInteger ("dancenum", 1);
		SGanim.SetBool("isDancing",true);
	}
	public void Dance2(){
		SGanim.SetInteger ("dancenum", 2);
		SGanim.SetBool("isDancing",true);
	}
	public void Dance3(){
		SGanim.SetInteger ("dancenum", 3);
		SGanim.SetBool("isDancing",true);
	}
}
