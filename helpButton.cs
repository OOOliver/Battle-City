using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpButton: MonoBehaviour {

	public void Click(){
		Application.LoadLevel("help");
		MusicController.musicIns.playMusic (4);
	}
}

