using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1: MonoBehaviour{
	public GameObject enemy;
	public Vector3 enemyValueUp;
	public Vector3 enemyValueDown;
	public static int climber;
	private bool once ;
	private bool twice ;
	public static bool third1;

	void enemySpawnUp(){
		Vector3 enemyPosition = new  Vector3 (enemyValueUp.x, enemyValueUp.y, 0);
		Vector3 enemyPosition2 = new  Vector3 (enemyValueUp.x+12.5f, enemyValueUp.y, 0);
		Vector3 enemyPosition3 = new  Vector3 (enemyValueUp.x+25, enemyValueUp.y, 0);
		Instantiate (enemy,enemyPosition, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (enemy,enemyPosition2, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (enemy,enemyPosition3, Quaternion.Euler (new Vector3 (0, 0, 0)));
	}

	void Start(){
		MusicController.musicIns.playMusic (0);
		climber = 0;
		once = false;
		twice = false;
		third1 = false;
		Invoke("enemySpawnUp",3);
	
	}

	void Update(){
		if (third1 == false) {
			if (climber == 3) {
				if (once == false) {
					Invoke ("enemySpawnDown", 3);
					once = true;
				}
			} else if (climber == 6) {
				if (twice == false) {
					Invoke ("enemySpawnUp", 3);
					Invoke ("enemySpawnDown", 3);
					twice = true;
				}
			} else if (climber == 12) {
				oWall.open = true;
				third1 = true;
			}
		}
	}
		
	void enemySpawnDown(){
		Vector3 enemyPosition = new  Vector3 (enemyValueDown.x, enemyValueDown.y, 0);
		Vector3 enemyPosition2 = new  Vector3 (enemyValueDown.x+12.5f, enemyValueDown.y, 0);
		Vector3 enemyPosition3 = new  Vector3 (enemyValueDown.x+25, enemyValueDown.y, 0);
		Instantiate (enemy,enemyPosition, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (enemy,enemyPosition2, Quaternion.Euler (new Vector3 (0, 0, 0)));
		Instantiate (enemy,enemyPosition3, Quaternion.Euler (new Vector3 (0, 0, 0)));
	}
}

