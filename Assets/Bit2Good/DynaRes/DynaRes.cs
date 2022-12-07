using UnityEngine;
using System.Collections;

// DynaRes is a camera script, so we require a camera
[RequireComponent (typeof (Camera))]
public class DynaRes : MonoBehaviour {
	private bool force16Bit;
	private bool forceNoDepth;
	private	bool optionSet;
	private Camera drCam;
	private	float factor;
	private float lastFactor;
	private int aaFactor;
	private int aAlias;
	private int dBuffer;
	private	int drHeight;
	private	int drWith;
	private int irH;
	private int irW;
	private	RenderTexture dynFlip;
	private RenderTexture dynSample;
	private RenderTextureFormat drTextureFormat;

	// On start, setup standard values
	public void Start () {
		drCam = GetComponent<Camera> ();

		if (factor <= 0.0f) {
			factor = 1.0f;
		}

		SetTFormat (RenderTextureFormat.DefaultHDR);

		if (force16Bit) {
			SetDBuffer (16);
		} else if (forceNoDepth) {
			SetDBuffer (0);
		} else {
			SetDBuffer (24);
		}

		SetAA (aaFactor);

		irH = Screen.height;
		irW = Screen.width;

		optionSet = true;
	}

	// Sample the buffer according to setup
	public void OnPreCull () {
		if (optionSet) {
			if (!factor.Equals (lastFactor) ) {
				lastFactor = Mathf.Max( factor, 0.01f);
				factor = lastFactor;
				drWith = Mathf.RoundToInt (irW * lastFactor);
				drHeight = Mathf.RoundToInt (irH * lastFactor);
			}

			dynSample = RenderTexture.GetTemporary (drWith, drHeight, dBuffer, drTextureFormat, RenderTextureReadWrite.Default, aAlias);
			dynSample.wrapMode = TextureWrapMode.Clamp;

			drCam.SetTargetBuffers (dynSample.colorBuffer, dynSample.depthBuffer);
		}
	}

	// Scale the buffer content back to screen size
	public void OnPostRender () {
		if (optionSet) {
			dynFlip = RenderTexture.GetTemporary (Screen.width, Screen.height);
			dynFlip.wrapMode = TextureWrapMode.Clamp;

			drCam.SetTargetBuffers (dynFlip.colorBuffer, dynFlip.depthBuffer);
			RenderTexture.ReleaseTemporary (dynFlip);
			RenderTexture.ReleaseTemporary (dynSample);
		}
	}

	// We're using RenderTextures so we need to Blit;
	// this can be safely removed if image effects are used
	// because the need to Blit as well
	public void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit (source, destination);
	}

	// Returns:	reference to the camera this DynaRes instance is attached to
	public Camera GetCam () {
		return drCam;
	}

	// Takes:	int value that specifies the antialiasing Unity should apply
	//			to the RenderTexture; values other than 1, 2, 4 or 8 will be
	//			changed to valid ones
	public void SetAA (int aA) {
		if (aA >= 8) {
			aAlias = 8;
		} else if (aA >= 4) {
			aAlias = 4;
		} else if (aA >= 2) {
			aAlias = 2;
		} else {
			aAlias = 1;
		}

		aaFactor = aAlias;
	}

	// Takes:	int value that specifies the size of the depthbuffer to use;
	//			values other than 24 or 16 will be changed to 0; only 24 bit
	//			depth buffer offer stencil support
	public void SetDBuffer (int bSize) {
		force16Bit = false;
		forceNoDepth = false;

		if (24.Equals (bSize)) {
			dBuffer = 24;
		} else if (16.Equals (bSize)) {
			dBuffer = 16;
			force16Bit = true;
		} else {
			dBuffer = 0;
			forceNoDepth = true;
		}
	}

	// Takes:	float value that specifies the factor of the sampling;
	//			1.0 equals 100% and the value will be clamped between
	//			0.01 (1%) and 4.0 (400%)
	public void SetFactor (float sFactor) {
		factor = Mathf.Clamp (sFactor, 0.01f, 4.0f);
	}

	// Takes:	two int values specifying pixel with and height values
	//			to sample to; they will always be changed to meet the
	//			real screen width to height ratio
	public void SetRes (int sWidth, int sHeight) {
		SetRes (sWidth, sHeight, false);
	}

	// Takes:	two int values specifying pixel with and height values
	//			to sample to as well as a boolean value; use a boolean
	//			value of true to force exact sampling even if its width
	//			to height ratio differs from the screen width to height
	//			ratio; consider using the SetRes method above if your're
	//			not using a boolean value of true ;-)
	public void SetRes (int sWidth, int sHeight, bool forceRes) {
		if (forceRes) {
			irW = sWidth;
			irH = sHeight;
			drWith = Mathf.RoundToInt (irW * lastFactor);
			drHeight = Mathf.RoundToInt (irH * lastFactor);
		} else {
			float __wFactor = sWidth / (1.0f * Screen.width);
			float __hFactor = sHeight / (1.0f * Screen.height);

			if (__wFactor < __hFactor) {
				SetFactor (__wFactor);
			} else {
				SetFactor (__hFactor);
			}
		}
	}

	// Takes:	RenderTextureFormat to use internally; use
	//			Unity's documentation for a complete list
	//			of formats
	public void SetTFormat (RenderTextureFormat tFormat) {
		if (SystemInfo.SupportsRenderTextureFormat (tFormat)) {
			drTextureFormat = tFormat;
		} else {
			drTextureFormat = RenderTextureFormat.Default;
		}
	}
}