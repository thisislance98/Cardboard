using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {

	Transform _head;

	public float MaxPanelMovment = 200;
	public float RightMaxValue= .7f;
	float _buttonTime;


	float _timeForSelect = 3;

	void Start()
	{
		_head = GameObject.Find("Head").transform;
	}

	void Update()
	{



		Vector3 pos = transform.position;

		float x = _head.transform.forward.x;
		float percent = (x + RightMaxValue) / ( RightMaxValue * 2.0f);
		pos.x = Mathf.Lerp(-MaxPanelMovment,MaxPanelMovment, percent);
		transform.position = pos;

		Ray ray = new Ray(_head.position, _head.forward);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			_buttonTime += Time.deltaTime;

			if (_buttonTime > _timeForSelect)
				Application.LoadLevel("MainScene");

		}
	}

}
