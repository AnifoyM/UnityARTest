using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Camera))]
[AddComponentMenu("Bit2Good/DynaRes/By Factor")]
public class DrFactor : DynaRes {
	[SerializeField]
	private	float myFactor;
	[SerializeField]
	private bool myForce16Bit;
	[SerializeField]
	private bool myForceNoDepth;
	[SerializeField]
	private int myAaFactor;

	private float cachedFactor;
	private int cachedAa;

	public void FixedUpdate () {
		if (!cachedFactor.Equals (myFactor)) {
			SetFactor (myFactor);
			cachedFactor = myFactor;
		}

		if (!cachedAa.Equals (myAaFactor)) {
			SetAA (myAaFactor);
			cachedAa = myAaFactor;
		}

		if (myForceNoDepth) {
			SetDBuffer (0);
		} else if (myForce16Bit) {
			SetDBuffer (16);
		} else {
			SetDBuffer (24);
		}
	}
}