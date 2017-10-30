using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private static string[] levels = new string[]{"Level_01", "Level_02", "Level_03", "Level_04", "Level_05", "Win"};
	private static int currLevel = 0;
	
	// Load a specific level
	public void loadALevel(string name) {
		Debug.Log(name + " level requested");
		checkForFirstLevel(name);
		Application.LoadLevel(name);
	}
	
	// Quit the game
	public void quitRequest() {
		Debug.Log("Quit requested");
		Application.Quit();
	}
	
	public void returnFromLose() {
		Debug.Log("Returning to level " + levels[currLevel]);
		checkForFirstLevel(levels[currLevel]);
		Application.LoadLevel(levels[currLevel]);
	}
	
	public void continueGame() {
		Debug.Log("Continuing to level " + (levels[currLevel + 1]));
		Application.LoadLevel(levels[currLevel++ + 1]);
		//currLevel++;
	}
	
	public int getCurrLevel() {
		return currLevel;
	}
	
	void checkForFirstLevel(string name) {
		if (name == "Level_01") {
			currLevel = 0;
		}
	}
} // Class
