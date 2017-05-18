using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour {
	public Text deathText;
	private bool death;
	public Text reText;
	public Text winText;
	private bool victory ;
	public Text ui;
	public static float Score ;
	public static float Bomb ;

	// Use this for initialization
	void Start () {
		victory = false;
		Score = 0;
		Bomb = 0;
		deathText.text = "";
		reText.text = "";
		winText.text = "";
		ui.text = "        H P\n" + "    Score : " + Score+"\n" +"    Bomb : " + Bomb + "\n";
		death = false;
	}

	// Update is called once per frame
	void Update () {
		ui.text = "        H P\n" + "    Score : " + Score+"\n" +"    Bomb : " + Bomb + "\n";
		if (death || Level3.win) {
			if (Input.GetKeyDown (KeyCode.R)) {

				MusicController.musicIns.playMusic (3);
				Application.LoadLevel ("Start");
			}
		}
		if (Level3.win && !victory) {
			MusicController.musicIns.playMusic (2);
			GameObject [] ebullet = GameObject.FindGameObjectsWithTag("eball");
			GameObject [] bbullet = GameObject.FindGameObjectsWithTag("bball");
			foreach (GameObject eb in ebullet) {
				Destroy (eb);
			}
			foreach (GameObject bb in bbullet) {
				Destroy (bb);
			}
			winText.text = "Congratulations !";
			reText.text = "       Press R to\nback the main meau";
			Time.timeScale = 0;
			victory = true;
		}
	}

	public void playerDie(){
		deathText.text = "    You Died\nMission Failed";
		reText.text = "       Press R to\nback the main meau";
		death = true;
	}
}
