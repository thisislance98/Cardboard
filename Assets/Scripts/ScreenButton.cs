using UnityEngine;
using System.Collections;


public class ScreenButton : MonoBehaviour {

	public float MaxX;
	public float MinX;

	public float LargeScale;
	public float ScaleSpeed;

	bool _isFocused;

	bool _isPressed;

	// Update is called once per frame
	void Update () {


		_isFocused = (transform.position.x > MinX && transform.position.x < MaxX);
		float scale = transform.localScale.x;

		if (_isFocused == true && scale  < LargeScale)
		{
			transform.localScale += Vector3.one * ScaleSpeed * Time.deltaTime;
		}
		else if (scale >= LargeScale)
		{


			if (_isPressed == false)
				LeanTween.rotate(gameObject,Vector3.forward * 180, .2f).setOnComplete(OnHalfRotation);

			_isPressed = true;
		}

		Debug.Log (" is focused: " + _isFocused + " scale: " + scale);

		if (_isFocused == false && scale > 1)
		{

			transform.localScale -= Vector3.one * ScaleSpeed * 2 * Time.deltaTime;
		}


	
	}

	void OnHalfRotation()
	{
		LeanTween.rotate(gameObject,Vector3.forward * 360, .2f).setOnComplete(OnPressed);
	}

	void OnPressed()
	{
		Application.LoadLevel("DemoScene");
	}
}
