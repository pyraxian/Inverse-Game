using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CompletedText : MonoBehaviour {

	public Text text;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		text.text = ("Congratulations. You have completed level " + (levelManager.getCurrLevel() + 1) + ".");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
