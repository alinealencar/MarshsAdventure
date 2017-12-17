using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	[SerializeField]
	Transform target = null;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position = 
			new Vector3 (//camera follows only for x direction
				target.position.x, 
				gameObject.transform.position.y,
				gameObject.transform.position.z
			);
	}
}
