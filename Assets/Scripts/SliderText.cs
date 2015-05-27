using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderText : MonoBehaviour {


	string startText;

	void Start()
	{
		startText = GetComponent<Text>().text;

	}

	public void OnValueChange(float value)
	{

		GetComponent<Text>().text = startText + ": " + value.ToString("0.00");
	}
}
