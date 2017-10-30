using UnityEngine;
using System.Collections;

public class GateController : MonoBehaviour {

	/*** Comparable Vars: ***/
	public string color;						// The color property of this gate
	public string shape;						// The shape property of this gate
	
	/*** Computational Vars ***/
	private bool isSolved = false;				// A value of false indicates this gate has not found its match
	private LevelManager levelManager;			// Reference to the LevelManager script
	private WinManager winManager;				// Reference to the WinManager script to log solved gates
	private Vector3 distToTarget;				// Distance from gate to its corresponding target
	private TargetController targetController;	// Reference to the target object this gate collides with
	
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		winManager = GameObject.FindObjectOfType<WinManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Collision detection
	void OnTriggerEnter2D(Collider2D trigger) {
		if (!isSolved) {
			if (trigger.gameObject.tag == "Target") { // Only detect collisions with objects of type "target"
				targetController = trigger.gameObject.GetComponent<TargetController>();
				if (targetController != null) {
					if ((targetController.color == this.color) && (targetController.shape == this.shape)) {
						// Record successful goal
						//Debug.Log("Successful match of color " + targetController.color + " and shape " + targetController.shape);
						isSolved = true;
						distToTarget = targetController.transform.position - this.transform.position;
						targetController.GiveGate(this, distToTarget);
						targetController.ChangeStatus();
						winManager.GateCompleted();
					} else {
						// Incorrect target hit gate --> lose condition
						levelManager.loadALevel("Lose");
					} 
				} else {
					Debug.Log("Failed to get a reference to ObjectController script");
				}
			 
			}
		
		}
	}	
} // Class
