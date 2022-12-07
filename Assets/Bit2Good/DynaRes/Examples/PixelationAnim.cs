using UnityEngine;
using System.Collections;

// We need the DynaRes class
[RequireComponent (typeof (DynaRes))]
[AddComponentMenu("Bit2Good/DynaRes/Examples/Pixelation Animation")]
public class PixelationAnim : MonoBehaviour {
	// execAnim will trigger the animation
	[SerializeField]
	private	bool execAnim;

	// execTime will set the complete time
	// it takes to pixelate to 1% and back to 100%
	[SerializeField]
	private float execTime;

	// animActive is used to lock our coroutine to
	// 1 execution at a time
	private	bool animActive;
	private DynaRes drRef;

	// We're using FixedUpdate to look for a change
	// in execAnim; if you're going to call PixelAnim
	// from another script, you can delete this
	public void FixedUpdate () {
		if (execAnim) {
			StartCoroutine (PixelAnim ());
		}
	}

	// This is where the magic happens
	public IEnumerator PixelAnim () {
		// We only want one instance of this
		// method to run at any given time
		if (!animActive) {
			animActive = true;
			execAnim = false;

			// Get the reference to DynaRes if
			// we don't have one
			while (drRef == null) {
				drRef = GetComponent<DynaRes> ();

				yield return null;
			}

			float __timer = 0.0f;
			float __factor = 1.0f;
			float __half = execTime * 0.5f;

			// Scale the resolution here
			while (__timer < execTime) {
				// This will scale __factor from 1.0 to 0.0
				// and then back up
				if (__timer < __half) {
					__factor = 1.0f - (__timer / __half);
				} else {
					__factor = (__timer / __half) - 1.0f;
				}

				// use DynaRes to set the resolution by factor
				drRef.SetFactor (__factor);

				yield return null;

				__timer += Time.deltaTime;
			}

			// Reset everything to the starting point
			drRef.SetFactor (1.0f);
			animActive = false;
			execAnim = false;
		}
	}
}