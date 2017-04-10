using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	private bool isShown = false;

	// Use this for initialization
	void Start () {
		
		gameObject.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!isShown)
			return;

	}



	public void TogglePauseMenu(){

		gameObject.SetActive (true);
		isShown = true;
		Time.timeScale = 0;
		gameObject.transform.position = new Vector3(388,218,0);

	}

	public void Resume(){
	
		gameObject.SetActive (false);
		isShown = false;
		Time.timeScale = 1;
	
	}


	public void toMenu(){
		SceneManager.LoadScene ("MainMenu");
	}



}
