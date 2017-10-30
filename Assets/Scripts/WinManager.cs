using UnityEngine;
using System.Collections;

public class WinManager : MonoBehaviour {

	private LevelManager levelManager;

	public int gatesToWin;
	private int gatesRemaining;
	
	// Use this for initialization
	void Start () {
		gatesRemaining = gatesToWin;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gatesRemaining <= 0) {
			//Debug.Log("All gates in level completed. Moving to next level.");
			levelManager.loadALevel("Completed");
		}
	}
	
	// Decrement gates remaining
	public void GateCompleted() {
		gatesRemaining--;
	}
} // Class
