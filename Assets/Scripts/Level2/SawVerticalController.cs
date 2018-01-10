using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawVerticalController : MonoBehaviour {
	[SerializeField]
	private float speed = 2f;
	[SerializeField]
	private float ceilingY = 2.2f;

	private Rigidbody2D _rigidBody;
	private Transform _transform;

	// Use this for initialization
	void Start () {

		_rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		_transform = gameObject.transform;

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (gameObject.transform.position.y > ceilingY) {
			Vector3 curRot = _transform.eulerAngles;
			curRot.x += 180;
			_transform.eulerAngles = curRot;
		}

		Vector2 vel = _rigidBody.velocity;
		vel.y = _transform.up.y * speed;
		_rigidBody.velocity = vel;



	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag.Equals ("water")) {
			Vector3 curRot = _transform.eulerAngles;
			curRot.x += 180;
			_transform.eulerAngles = curRot;
		}

	}
}
