using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillScreenMenu : MonoBehaviour {
	private bool isShown = false;
	private float transition = 0.0f;
	public Image backgroundimage;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (!isShown)
			return;

		transition += Time.deltaTime;
		backgroundimage.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black, transition);
	
	}




	public void Play(){

		SceneManager.LoadScene ("MainGame");


	}
	public void Menu(){

		SceneManager.LoadScene ("MainMenu");


	}

}
