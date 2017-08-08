using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

[RequireComponent (typeof(Text))]
public class starDisplay : MonoBehaviour {

	private Text text; 
	public static int totalStars = 100; 
	public enum Status {SUCESS, FAILURE};  

	void Start () {
		text = GetComponent<Text>();
		text.text = "" + totalStars;  
	}

	public void addStars (int amout) {
		totalStars = totalStars + amout; 
		text.text = "" + totalStars; 
	}

	public Status useStars (int amount) {
		if (totalStars >= amount) {
			totalStars = totalStars - amount; 
			text.text = "" + totalStars; 
			return Status.SUCESS;  
		} else {
			return Status.FAILURE; 
		}
	}
}
