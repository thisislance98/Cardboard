using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ObjectManager : MonoBehaviour {

	public string ModelsFolderName;
	 List<GameObject> _objectPrefabs = new List<GameObject>();

	GameObject _currentObject;


	int _objectIndex=0;
	float horizontalAngle;
	float verticalAngle;

	// Use this for initialization
	void Start () {

		foreach (Object obj in Resources.LoadAll(ModelsFolderName))
		{
			_objectPrefabs.Add ((GameObject)obj);
		}

		CreateObject();

	}

	
	void Update()
	{

		if (Cardboard.SDK.CardboardTriggered || Input.GetMouseButtonDown(0))// && Input.mousePosition.y > Screen.height * .1f)
		{
			_objectIndex = (_objectIndex + 1) % _objectPrefabs.Count;

			CreateObject();

		}
	}

	
	void CreateObject()
	{
		GameObject obj = (GameObject)Instantiate(_objectPrefabs[_objectIndex]);

		CardboardHead head = obj.AddComponent<CardboardHead>();
		head.trackPosition = false;
		head.trackRotation = true;
		head.invertRotation = true;

//		Camera.main.GetComponent<StereoController>().centerOfInterest = obj;

		if (_currentObject != null)
		{
			Destroy(_currentObject);
			obj.transform.rotation = _currentObject.transform.rotation;
		}

		_currentObject = obj;
		obj.transform.parent = transform;
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localRotation = Quaternion.identity;

	}

	public void OnPositionChange(float x)
	{

	}

	public void OnObjectDistanceChange(float distance)
	{
		_currentObject.transform.localPosition = new Vector3(_currentObject.transform.localPosition.x, _currentObject.transform.localPosition.y, distance);
	}
 

}
