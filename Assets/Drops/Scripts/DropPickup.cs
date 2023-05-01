using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPickup : MonoBehaviour{
	public float range = 5;
	public float pickupTime = 0.5;
	private Vector3 velocity = Vector3.zero;

	void Update(){
		Vector3 playerPosition = PlayerSingleton.Instance.transform.position;

		if(Vector3.Distance(playerPosition, transform.position) <= range){
			transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, pickupTime);
		}
	}
}
