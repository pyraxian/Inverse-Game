using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

	public float speed = 50.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate clockwise (left arrow) or counter-clockwise (right arrow)
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Rotate(Vector3.forward * speed * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
		}
	}
} // Class
