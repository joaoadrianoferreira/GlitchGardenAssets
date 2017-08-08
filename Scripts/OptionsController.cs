using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider; 
	public Slider difficultySlider; 
	public LevelManager levelManager; 
	private MusicManager musicManager; 

	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>(); 
		volumeSlider.value = PlayerPrefsManager.getMasterVolume(); 
		difficultySlider.value = PlayerPrefsManager.getDifficulty();  
	}

	void Update () {
		musicManager.changeVolume(volumeSlider.value); 
	}

	public void saveAndExit() {
		PlayerPrefsManager.setMasterVolume(volumeSlider.value); 
		PlayerPrefsManager.setDifficulty(Mathf.RoundToInt(difficultySlider.value)); 
		levelManager.LoadLevel("StartGame"); 
	} 

	public void setDefaults() {
		volumeSlider.value = 0.5f; 
		difficultySlider.value = 2f; 
		PlayerPrefsManager.setMasterVolume(volumeSlider.value); 
		PlayerPrefsManager.setDifficulty(Mathf.RoundToInt(difficultySlider.value)); 
	}
}
