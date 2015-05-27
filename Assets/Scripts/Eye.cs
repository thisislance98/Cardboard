using UnityEngine;
using System.Collections;

public class Eye : MonoBehaviour {

	public float EyeMultiplier;


	// Use this for initialization
	void Start () {
	
	}

	public void OnAngleChange(float angle)
	{
		transform.localRotation = Quaternion.Euler( new Vector3(transform.localRotation.eulerAngles.x, angle * EyeMultiplier, transform.localRotation.eulerAngles.z) );

	}

	public void OnPositionChange(float x)
	{
		transform.localPosition = new Vector3(x * EyeMultiplier,0,0);

	}


}
