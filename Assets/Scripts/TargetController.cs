using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {

	public string color;
	public string shape;
	public int position; // Can be either 0, 1, 2, or 3, references cardinal directions starting at top and moving counterclockwise
	
	private bool isSolved = false;
	private float thrust = 4000.0f;
	private GateController gate;
	private Vector3 distToGate;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isSolved) {	// Target has yet to meet gate
			this.ApplyForce();
			
			if (Input.GetKeyDown(KeyCode.Space)) {
				this.Jump();
			}
		} else {			// Target has met its gate, is now locked to gate
			this.transform.position = gate.transform.position + distToGate;
		}
	}
	
	// Records that target has found its gate
	public void ChangeStatus() {
		isSolved = true;
	}
	
	// Gives reference to target's matching gate
	public void GiveGate(GateController gate, Vector3 distToGate) {
		this.gate = gate;
		this.distToGate = distToGate;
	}
	
	// Essentially acts as gravity in a custom direction
	void ApplyForce() {
		if (position == 0) { 		// North
			this.rigidbody2D.velocity = new Vector2 (0f, 2f);
		} else if (position == 1) { // East
			this.rigidbody2D.velocity = new Vector2 (2f, 0f);
		} else if (position == 2) { // South
			this.rigidbody2D.velocity = new Vector2 (0f, -2f);
		} else if (position == 3) {	// West
			this.rigidbody2D.velocity = new Vector2 (-2f, 0f);
		} else {
			Debug.LogError("Invalid position value of " + position);
		}
	} 
	
	// Apply a jump to the target
	void Jump() {
		if (position == 0) { 		// North --> Jump South
			this.rigidbody2D.AddForce(-transform.up * thrust);
		} else if (position == 1) { // East --> Jump West
			this.rigidbody2D.AddForce(-transform.right * thrust);
		} else if (position == 2) { // South --> Jump North
			this.rigidbody2D.AddForce(transform.up * thrust);
		} else if (position == 3) {	// West --> Jump East
			this.rigidbody2D.AddForce(transform.right * thrust);
		}
	}
} // Class
