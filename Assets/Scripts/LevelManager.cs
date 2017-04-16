using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void quitLevel(){
		Debug.Log ("Quitting Level");
		Application.Quit ();
	}
}
