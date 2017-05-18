using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3: MonoBehaviour{
	public GameObject wallBoom;
	public GameObject bossTowerL;
	public GameObject bossTowerR;
	public GameObject normalTank;
	public GameObject bossTank;
	public GameObject FlandreTank1;
	public GameObject FlandreTank2;
	public GameObject FlandreTank3;
	public GameObject FlandreTank4;

	private Vector3 wbpos = new Vector3(-2,20,0);
	private Vector3 wbpos2 = new Vector3(-2,0,0);
	private Vector3 wbpos3 = new Vector3(-2,-20,0);
	private Vector3 wbpos4 = new Vector3(21.5f,0,0);
	private Vector3 wbpos5 = new Vector3(30,13.5f,0);
	private Vector3 wbpos6 = new Vector3(30,-13.5f,0);
	private Vector3 btpos = new Vector3 (-30, 10, 0);
	private Vector3 btpos2 = new Vector3 (-30, -7.5f, 0);
	private Vector3 btpos3 = new Vector3 (-30, -25, 0);
	private Vector3 btpos4 = new Vector3 (30, 2.5f, 0);
	private Vector3 btpos5 = new Vector3 (30, -15, 0);
	private Vector3 flpos = new Vector3 (0, 25.5f, 0);
	private Vector3 flpos2 = new Vector3 (0, -25.5f, 0);
	private Vector3 flpos3 = new Vector3 (-31, 0, 0);
	private Vector3 flpos4 = new Vector3 (31, 0, 0);

	public static bool startBoss ;
	public static bool Boss1 ;
	public static bool Boss2 ;
	public static bool win ;
	public static int tower ;

	private bool first3 ;
	private bool second3 ;
	private bool third3 ;

	private bool getT ;
	private bool cT ;

	void Start(){
		startBoss = false;
		Boss1 = false;
		Boss2 = false;
		win = false;
		tower = 0;
		first3 = false;
		second3 = false;
		getT = false;
		cT = false;
	}

	void Update(){
		
		if (startBoss == true && first3 == false) {
			Invoke ("destroyWall", 1);
			Invoke ("getBoss", 3);
			Invoke ("firstBoss", 7);
			first3 = true;
		} else if (tower == 5 && second3 == false) {
			Boss1 = true;
			second3 = true;
		} else if (Boss2 == true && third3 == false ) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Tank");
			foreach (GameObject go in enemies) {
				Destroy (go);
			}
			Invoke ("four_Of_A_Kind", 5);
			third3 = true;
		}

		if (Boss1 == true && Boss2 == false && getT == false) {
			InvokeRepeating ("getTank", 5, 15);
			getT = true;
		}
		if (Boss2 && !cT) {
			CancelInvoke("getTank");
			cT = true;
		}

	}

	void destroyWall(){
		GameObject L1 = GameObject.Find ("FirstLevel");
		GameObject L2 = GameObject.Find ("SecondLevel");
		Instantiate (wallBoom, wbpos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (wallBoom, wbpos2, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (wallBoom, wbpos3, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (wallBoom, wbpos4, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (wallBoom, wbpos5, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (wallBoom, wbpos6, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Destroy (L1);
		Destroy (L2);
	}

	void firstBoss(){
		Instantiate (bossTowerL, btpos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (bossTowerL, btpos2, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (bossTowerL, btpos3, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (bossTowerR, btpos4, Quaternion.Euler (new Vector3 (0, 180, 0)));
		Instantiate (bossTowerR, btpos5, Quaternion.Euler (new Vector3 (0, 180, 0)));
	}

	void getTank(){
		Instantiate (normalTank, new Vector3(Random.Range(-32,32),Random.Range(-26,26),0), Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (normalTank, new Vector3(Random.Range(-32,32),Random.Range(-26,26),0), Quaternion.Euler (new Vector3 (0, 0, 0)));
	}



	void four_Of_A_Kind(){
		Instantiate (FlandreTank1, flpos, Quaternion.Euler (new Vector3 (0, 0, 180)));
		Instantiate (FlandreTank2, flpos2, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (FlandreTank3, flpos3, Quaternion.Euler (new Vector3 (0, 0, 270)));
		Instantiate (FlandreTank4, flpos4, Quaternion.Euler (new Vector3 (0, 0, 90)));
	}

	void getBoss(){
		MusicController.musicIns.playMusic (1);
		Instantiate (bossTank, new Vector3 (0, 25, 0), Quaternion.Euler (new Vector3 (0, 0, 180)));
	}
}

