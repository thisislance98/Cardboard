// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class BoxButton : MonoBehaviour {
 
	public Transform RayCameraTransform;
	public Slider SliderToUpdate;
	public float IncrementValue = .1f;

	bool _isLookingAtBox;

  void Start() {

    SetGazedAt(false);
  }



  public void SetGazedAt(bool gazedAt) {
    	GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;

		_isLookingAtBox = gazedAt;


  }

	public void Update()
	{

		Ray ray = new Ray(RayCameraTransform.position, RayCameraTransform.forward);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			if (hit.transform == transform)
				SetGazedAt(true);
			else
				SetGazedAt(false);
		}
		else
			SetGazedAt(false);

		Debug.DrawRay(ray.origin,ray.direction,Color.red);


		if (_isLookingAtBox)
		{
			SliderToUpdate.value += IncrementValue * Time.deltaTime;

		}

	}


}
