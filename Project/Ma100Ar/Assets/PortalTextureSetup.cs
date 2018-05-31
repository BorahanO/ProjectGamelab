using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {

	public Camera camOtherWorld;

	public Material camMatOtherWorld;


	// Use this for initialization
	void Start () {
		if (camOtherWorld.targetTexture != null){
			camOtherWorld.targetTexture.Release();
		}
		camOtherWorld.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		camMatOtherWorld.mainTexture = camOtherWorld.targetTexture;
	}
}
