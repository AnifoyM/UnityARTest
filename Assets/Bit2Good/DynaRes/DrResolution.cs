using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Camera))]
[AddComponentMenu("Bit2Good/DynaRes/By Resolution")]
public class DrResolution : DynaRes {
	[SerializeField]
	private	int myWidth;
	[SerializeField]
	private	int myHeight;
	[SerializeField]
	private bool myForce16Bit;
	[SerializeField]
	private bool myForceNoDepth;
	[SerializeField]
	private int myAaFactor;

	private int cachedHeight;
	private int cachedWidth;
	private int cachedAa;

	public void FixedUpdate () {
		if ( !cachedHeight.Equals (myHeight) || !cachedWidth.Equals (myWidth)) {
			SetRes (myWidth, myHeight);
		}

		if (!cachedAa.Equals (myAaFactor)) {
			SetAA (myAaFactor);
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