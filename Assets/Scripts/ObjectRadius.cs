using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectRadius : MonoBehaviour {

	public float Value;
	public float Increment;


	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) || Input.touches.Length > 0)
		{

			if (Input.mousePosition.y < Screen.height * .1f)
			{
				if (GetPos().x > Screen.width * 1.0f/4.0 && GetPos().x < Screen.width * 2.0f / 4.0f) 
				{
					Value += Increment;
				}
				else if (GetPos().x < Screen.width * 1.0f/4.0f) 
				{
					Value -= Increment;
				}

			}

			GetComponent<Text>().text = "Object Radius: " + Value.ToString("0.0") + " pos: " + GetPos();
			Camera.main.GetComponent<StereoController>().OnObjectRadiusChange(Value);
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
