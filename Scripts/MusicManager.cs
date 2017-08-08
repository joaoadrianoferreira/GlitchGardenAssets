using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MusicManager : MonoBehaviour {

	public AudioClip[] leverMusicChangeArray; 
	private AudioSource audioSource; 

	void Awake () {
		DontDestroyOnLoad(gameObject); 
	}

	void Start() {
		audioSource = GetComponent<AudioSource>(); 
		changeVolume(PlayerPrefsManager.getMasterVolume()); 
	}

	void OnLevelWasLoaded (int level) {
		AudioClip music = leverMusicChangeArray[level]; 
		if (music) {
			audioSource.clip = music; 
			audioSource.loop = true; 
			audioSource.Play(); 
		}
	}

	public void changeVolume (float volume) {
		audioSource.volume = volume; 
	}
}
