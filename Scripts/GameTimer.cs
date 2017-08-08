using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameTimer : MonoBehaviour {

	private Slider slider; 
	private float levelSeconds; 
	private LevelManager levelManager; 
	private AudioSource audioSource; 
	private bool isEndOfLevel = false; 
	private starDisplay starDisplay; 

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>(); 
		levelSeconds = (PlayerPrefsManager.getDifficulty() + (levelManager.getLoadedLevel() / 8)) * 100f; 
		starDisplay = GameObject.FindObjectOfType<starDisplay>(); 
		audioSource = GameObject.FindObjectOfType<AudioSource>(); 
		slider = GetComponent<Slider>(); 
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		if (slider.value == 1) {
			isEndOfLevel = true; 
			LoadNextLevel(); 
		}
	}

	void LoadNextLevel () {
		if (isEndOfLevel) {
			starDisplay.totalStars += 100; 
			levelManager.LoadNextLevel();  
		}
	}
}
