using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameTimer : MonoBehaviour {

	private Slider slider; 
	public float levelSeconds; 
	private LevelManager levelManager; 
	private AudioSource audioSource; 
	private bool isEndOfLevel = false; 
	private starDisplay starDisplay; 

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<starDisplay>(); 
		levelManager = GameObject.FindObjectOfType<LevelManager>(); 
		audioSource = GameObject.FindObjectOfType<AudioSource>(); 
		slider = GetComponent<Slider>(); 
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		if (slider.value == 1 && isEndOfLevel == false) {
			audioSource.Play(); 
			isEndOfLevel = true; 
			Invoke ("LoadNextLevel", audioSource.clip.length); 
		}
	}

	void LoadNextLevel () {
		if (isEndOfLevel) {
			starDisplay.totalStars += 100; 
			levelManager.LoadNextLevel();  
		}
	}
}
