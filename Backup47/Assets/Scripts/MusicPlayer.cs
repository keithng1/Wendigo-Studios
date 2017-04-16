using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	[SerializeField] private AudioClip menuMusic;
	[SerializeField] private AudioClip gameMusic;
	[SerializeField] private float musicVolume = 0.2f;


	private static MusicPlayer musicPlayer = null;
	private AudioSource music;
	void Awake(){
		if (musicPlayer != null) {
			Destroy (gameObject);
		} 
		else {
			musicPlayer = this;
			GameObject.DontDestroyOnLoad (gameObject);
			music = this.GetComponent<AudioSource> ();
			music.clip = menuMusic;
			music.loop = true;
			music.volume = musicVolume;
			music.Play ();
		}
	}
		

	void OnLevelWasLoaded(int level){
		if (music != null) {
			music.Stop ();

			switch (level) {
			case 0:
				music.clip = menuMusic;
				break;
			case 1:
				music.clip = gameMusic;
				break;
			}
			musicVolume = 1f;
			music.loop = true;
			music.Play ();
		}
	}

	public void muteMusic(){
		if (music != null) {
			Debug.Log ("Mute music");
			music.pitch = -0.9f;
			//music.mute = true;
			//music.volume = 0.3f;
		}
	}

	public void unMuteMusic(){
		if (music != null) {
			Debug.Log ("Unmute Music");
			music.pitch = 1f;
			//music.mute = false;
			//music.volume = 1f;
		}
	}

	public static MusicPlayer getMusicPlayer(){
		return musicPlayer;
	}


}
