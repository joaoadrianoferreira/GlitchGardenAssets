using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevel = 5.0f; 
	public static bool splashLoaded = false; 


	public void Start() {
		if (!splashLoaded && autoLoadNextLevel > 0) {
			Invoke("LoadNextLevel", autoLoadNextLevel); 
		} else if (splashLoaded) {
			Debug.Log ("Splash was already loaded"); 
		} else if (autoLoadNextLevel <= 0) {
			Debug.Log ("Only positive values are accepted"); 
		}
	}

	public void Update() {
	}


	public void LoadLevel(string name){
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		splashLoaded = true; 
		CancelInvoke();
	}

	public float getLoadedLevel() {
		Debug.Log (SceneManager.GetActiveScene().buildIndex); 
		return SceneManager.GetActiveScene().buildIndex;
	}

}
