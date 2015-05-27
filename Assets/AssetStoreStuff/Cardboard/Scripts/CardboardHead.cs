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

public class CardboardHead : MonoBehaviour
{
	// Which types of tracking this instance will use.
	public bool trackRotation = true;
	public bool trackPosition = true;

	// If set, the head transform will be relative to it.
	public Transform target;

	// Determine whether head updates early or late in frame.
	// Defaults to false in order to reduce latency.
	// Set this to true if you see jitter due to other scripts using this
	// object's orientation (or a child's) in their own LateUpdate() functions,
	// e.g. to cast rays.
	public bool updateEarly = false;
	public bool invertRotation;

	// Where is this head looking?
	public Ray Gaze {
		get {
			UpdateHead ();
			return new Ray (transform.position, transform.forward);
		}
	}

	private bool updated;

	void Start ()
	{
		if (Application.isEditor)
		{
			Input.gyro.enabled = true;                // enable the gyroscope
			Input.gyro.updateInterval = 0.0167f;    // set the update interval to it's highest value (60 Hz)

		}

	}

	void Update ()
	{
		updated = false;  // OK to recompute head pose.
		if (updateEarly) {
			UpdateHead ();
		}
	}

	// Normally, update head pose now.
	void LateUpdate ()
	{
		UpdateHead ();
	}

	// Compute new head pose.
	private void UpdateHead ()
	{
		if (updated) {  // Only one update per frame, please.
			return;
		}
		updated = true;
		if (!Cardboard.SDK.UpdateState ()) {
			return;
		}

		if (trackRotation) {

			Quaternion localRotation = Quaternion.identity;



			if (Application.isEditor)
			{
				localRotation = ReadGyroscopeRotation();
			

			}
			else
			{
				var rot = Cardboard.SDK.HeadRotation;
				if (target == null) {
					localRotation = rot;
				} else {
					localRotation = rot * target.localRotation;
				}
			}

			if (invertRotation)
			{
				localRotation = Quaternion.Euler( -localRotation.eulerAngles.x, -localRotation.eulerAngles.y, -localRotation.eulerAngles.z);
			}

			transform.localRotation = localRotation;
			
		}

		if (trackPosition) {
			Vector3 pos = Cardboard.SDK.HeadPosition;
			if (target == null) {
				transform.localPosition = pos;
			} else {
				transform.position = target.position + target.rotation * pos;
			}
		}
	}

	private Quaternion ReadGyroscopeRotation() {

		return new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
	}
}
