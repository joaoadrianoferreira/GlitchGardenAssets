using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume"; 
	const string DIFFICULTY_KEY = "difficulty"; 
	const string LEVEL_KEY = "level_unlocked_"; 

	public static void setMasterVolume (float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume); 
		} else {
			Debug.LogError("Master Volume out of Range"); 
		}
	}

	public static float getMasterVolume() {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);  
	}

	public static void unloackLevel (int level) {
		if (level <= SceneManager.sceneCount - 1) {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); 
		} else {
			Debug.LogError("Level out of Range"); 
		}
	}

	public static bool isLevelUnlocked(int level) {
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()); 
		bool isUnlocked = (levelValue == 1);  
		if (level <= SceneManager.sceneCount - 1) {
			return isUnlocked; 
		} else {
			Debug.LogError("Level out of Range"); 
			return false; 
		}
	}

	public static void setDifficulty (int difficulty) {
		if (difficulty > 0 && difficulty <= 3) {
			PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty); 
		} else {
			Debug.LogError("Difficulty out of Range"); 
		}
	}

	public static int getDifficulty() {
		return PlayerPrefs.GetInt(DIFFICULTY_KEY);  
	}
}
