using UnityEngine;
using System.Collections;

// We need the DynaRes class
[RequireComponent (typeof (DynaRes))]
[AddComponentMenu("Bit2Good/DynaRes/Examples/Frame Watchdog")]
public class FpsWatchdog : MonoBehaviour {
	// What shall our border frames per second be?
	[SerializeField]
	private	int fpsBorder;

	// Subsample factor if the fpsBorder is undercut
	[SerializeField]
	private	float subFactor;

	private	bool watchdogAwake;
	private DynaRes drRef;
	private float targetDelta;

	// Setup our target delta on start and
	// "wake up" the watchdog
	public void Start () {
		targetDelta = 1.0f / ((float) (fpsBorder + 5));

		StartCoroutine (watchdog ());
	}

	// Our fps watchdog method
	private IEnumerator watchdog () {
		// Make sure the method only runs once
		// at any given time
		if (!watchdogAwake) {
			watchdogAwake = true;

			// Get the reference to DynaRes if
			// we don't have one
			while (drRef == null) {
				drRef = GetComponent<DynaRes> ();

				yield return null;
			}

			// Review our frametime 4 times per second
			while (watchdogAwake) {
				// If the frame delta exceeds our
				// target delta this means we're in danger
				// of the frames per second undercutting
				// our target fps and we subsample the image
				if (Time.unscaledDeltaTime > targetDelta) {
					drRef.SetFactor (subFactor);
				} else {
					drRef.SetFactor (1.0f);
				}

				yield return new WaitForSeconds (0.25f);
			}
		}
	}
}