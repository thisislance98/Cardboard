using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StereoMultiplier : MonoBehaviour {

	public float Value;
	public float Increment;


	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) || Input.touches.Length > 0)
		{

			if (GetPos().y < Screen.height * .1f)
			{
				if (GetPos().x > Screen.width * 3.0f/4.0) 
				{
					Value += Increment;
				}
				else if (GetPos().x > Screen.width * 1.0f/2.0f  && GetPos().x < Screen.width * 3.0f / 4.0f) 
				{
					Value -= Increment;
				}

			}

			GetComponent<Text>().text = "Stero Multipler: " + Value.ToString("0.0");
			Camera.main.GetComponent<StereoController>().OnSteroMultiplerChange(Value);
		}

	
	}

	Vector3 GetPos()
	{
		Vector3 pos = Vector3.zero;

		if (Application.isEditor)
			pos = Input.mousePosition;
		else if (Input.touches.Length > 0)
			return Input.touches[0].position;

		return pos;

	}
}
