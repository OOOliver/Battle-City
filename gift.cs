using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gift : MonoBehaviour{
	public GameObject wind;
	public GameObject burn;
	public GameObject shield;
	public GameObject heal;
	public GameObject bomb;
	private int giftRan;

	private Vector3 pos = new Vector3 (-20, 0, 0);
	private Vector3 hpos = new Vector3 (-20, 10, 0);

	private bool stopGift ;

	void Start(){
		stopGift = false;
		InvokeRepeating ("getGift", 12.5f, 25);
	}

	void Update(){
		if (Level3.Boss2 && !stopGift) {
			CancelInvoke ("getGift");
			stopGift = true;
		}
	}

	void getGift(){
		giftRan = Random.Range (0, 4);

		if (giftRan >= 0 && giftRan <= 1) {
			Instantiate (wind, pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		} else if (giftRan >= 1 && giftRan <= 2) {
			Instantiate (burn, pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		} else if (giftRan >= 2 && giftRan <= 3) {
			Instantiate (shield, pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		} else if (giftRan >= 3 && giftRan <= 4) {
			Instantiate (bomb, pos, Quaternion.Euler (new Vector3 (0, 0, 0)));
		} 

		Instantiate (heal, hpos, Quaternion.Euler (new Vector3 (0, 0, 0)));
	}

}

