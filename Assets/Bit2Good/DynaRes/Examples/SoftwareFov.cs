using UnityEngine;
using System.Collections;

// If this results in unstable behaviour in Unity, delete it;
// it's only here so you can changes see without the project running
[ExecuteInEditMode]
[AddComponentMenu("Bit2Good/DynaRes/Examples/Software Fov")]

// Derive your new class from DynaRes, so we can use all its methods
public class SoftwareFov : DynaRes {
	// Field of view value
	[SerializeField]
	private float myFov;

	// Additional factor for simultaneous usage
	// of software fov and sub- or supersampling
	[SerializeField]
	private float myFactor;

	private float cachedFov;
	private float cachedFactor;
	private float camFov;
	private int calcH;
	private int calcW;

	// This is not optimal, you'd want to
	// outsource this to a method that you
	// call every time fov gets changed
	public void FixedUpdate () {
		// Initial setup or reset
		if (myFov <= 0.0f) {
			myFov = GetCam ().fieldOfView;
			cachedFov = myFov;
		}

		// This is where the magic happens if the
		// fov gets changed
		if (!myFov.Equals (cachedFov)) {
			// Get Unity's fov and resolution values
			camFov = GetCam ().fieldOfView;
			calcH = Screen.height;
			calcW = Screen.width;

			// This works as follows:
			// If our software fov is set to something that's greater
			// than Unity's value we want to extend our width fov; we're
			// doing this by subsampling on the resolution heigth and
			// vice versa so fov won't add an overhead to performance;
			// if you want the quality to stay you need to swap them
			if (myFov > camFov) {
				calcH = Mathf.RoundToInt((float) calcH * camFov / myFov);
			} else {
				calcW = Mathf.RoundToInt((float) calcW * myFov / camFov);
			}

			// Just call SetRes with true to force the new resolution
			SetRes (calcW, calcH, true);

			cachedFov = myFov;
		}

		// Set the scale factor
		if (!cachedFactor.Equals (myFactor)) {
			SetFactor (myFactor);
			cachedFactor = myFactor;
		}
	}
}