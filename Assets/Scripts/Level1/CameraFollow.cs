using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	[SerializeField]
	Transform target = null;
	[SerializeField]
	float startFollow = -6.5f;
	[SerializeField]
	float endFollow = 101.76f;
	[SerializeField]
	float startCameraX = 0.2f;
	[SerializeField]
	float marshsFallY = -4.26f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		//Make the camera stop at the beginning and at the end of the level
		if(target.position.x > startFollow && target.position.x < endFollow) {
		gameObject.transform.position = 
			new Vector3 (//camera follows only for x direction
				target.position.x, 
				gameObject.transform.position.y,
				gameObject.transform.position.z
			);
		}

		//If Marsh falls, make the camera go to the start of the level
		if(target.position.y < marshsFallY){
			gameObject.transform.position = 
				new Vector3 (
					startCameraX,
					gameObject.transform.position.y,
					gameObject.transform.position.z	
			);
		}
	}
}
