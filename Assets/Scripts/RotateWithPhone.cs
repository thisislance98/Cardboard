using UnityEngine;
using System.Collections;

public class RotateWithPhone : MonoBehaviour {

	Quaternion _offsetRotation;

	void Start ()
	{

		Input.gyro.enabled = true;                // enable the gyroscope
		Input.gyro.updateInterval = 0.0167f;    // set the update interval to it's highest value (60 Hz)
			
		_offsetRotation = Quaternion.identity;
		
	}

	void Reset()
	{
		transform.rotation = ReadGyroscopeRotation();
		_offsetRotation = Quaternion.FromToRotation(transform.forward, Vector3.forward);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) || Input.touches.Length > 0)
			Reset();

		Debug.Log ("gryo: " + Input.gyro.attitude);

		transform.rotation = _offsetRotation * ReadGyroscopeRotation();
	}

	private Quaternion ReadGyroscopeRotation() {
		
		return new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
	}
}
