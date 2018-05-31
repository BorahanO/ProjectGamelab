using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

	public Transform player;
	public Transform receiver;

	private bool playerOverlap = false;

	// Update is called once per frame
	void Update () {
		if (playerOverlap){
			Vector3 portalToPlayer = player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

			if (dotProduct < 0f){
				float rotationDif = Quaternion.Angle(transform.rotation, receiver.rotation);
				rotationDif += 180;
				player.Rotate(Vector3.up, rotationDif);

				Vector3 positionOffset = Quaternion.Euler(0f, rotationDif, 0f) * portalToPlayer;
				player.position = receiver.position +positionOffset;

				playerOverlap = false;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "MainCamera"){
			playerOverlap = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "MainCamera"){
			playerOverlap = false;
		}
	}
}
