using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2: MonoBehaviour{
	public GameObject tower1;
	public GameObject tower2;
	public GameObject Key1;
	public GameObject Key2;
	public GameObject lightWall1;
	public GameObject lightWall2;
	public GameObject normalTank;
	public GameObject fastTank;
	public GameObject Star;

	private Vector3 t1pos = new Vector3(8,26,0);
	private Vector3 t2pos = new Vector3(12,-28,0);
	private Vector3 k1pos = new Vector3(31,23,0);
	private Vector3 k2pos = new Vector3(31,-23,0);
	private Vector3 w1pos = new Vector3(21.5f,22.9f,0);
	private Vector3 w2pos = new Vector3(21.5f,-23,0);
	private Vector3 spos = new Vector3(30.1f,0.1f,0);
	public Vector3 nTpos;
	public Vector3 fTpos;

	public static bool normalKey ;
	public static bool fastKey ;

	private bool first2 ;

	public static bool third2 ;
	public static int end ;

	void Start(){
		normalKey = false;
		fastKey = false;
		first2 = false;
		third2 = false;
		end = 0;
	}
	void Update(){
		if (third2 == false) {
			if (Level1.third1 == true && first2 == false) {
				Invoke ("setLevel2", 3);
				first2 = true;
			} else if (first2 == true && normalKey == true) {
				summonNormalEnemy ();
				normalKey = false;
			} else if (first2 == true && fastKey == true) {
				summonFastEnemy ();
				fastKey = false;
			} else if (first2 == true && end == 8) {
				o2Wall.open2 = true;
				third2 = true;
			}
		}
	}

	void setLevel2(){
		Instantiate (tower1, t1pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (tower2, t2pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (Key1, k1pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (Key2, k2pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (lightWall1, w1pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (lightWall2, w2pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (Star, spos, Quaternion.Euler (new Vector3 (0, 0, 0)));

	}

	void summonNormalEnemy(){
		Vector3 nTpos2 = new Vector3 (nTpos.x, nTpos.y - 12.5f, nTpos.z);
		Vector3 nTpos3 = new Vector3 (nTpos2.x, nTpos2.y - 12.5f, nTpos2.z);
		Vector3 nTpos4 = new Vector3 (nTpos3.x, nTpos3.y - 12.5f, nTpos3.z);
		Vector3 nTpos5 = new Vector3 (nTpos4.x, nTpos4.y - 12.5f, nTpos4.z);
		Instantiate (normalTank, nTpos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (normalTank, nTpos2, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (normalTank, nTpos3, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (normalTank, nTpos4, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (normalTank, nTpos5, Quaternion.Euler (new Vector3 (0, 0, 0)));
	}

	void summonFastEnemy(){
		Vector3 fTpos2 = new Vector3 (fTpos.x, fTpos.y - 15, fTpos.z);
		Vector3 fTpos3 = new Vector3 (fTpos2.x, fTpos2.y - 15, fTpos2.z);
		Instantiate (fastTank, fTpos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (fastTank, fTpos2, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (fastTank, fTpos3, Quaternion.Euler (new Vector3 (0, 0, 0)));
	}
		
}

