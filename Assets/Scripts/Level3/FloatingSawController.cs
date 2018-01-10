using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingSawController : MonoBehaviour {

	[SerializeField]
	private float speed = 1f;


	private Rigidbody2D _rigidBody;
	private Transform _transform;

	// Use this for initialization
	void Start () {

		_rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		_transform = gameObject.transform;

	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector2 vel = _rigidBody.velocity;
		vel.x = -_transform.right.x * speed;
		_rigidBody.velocity = vel;


	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag.Equals ("dirt")) {
			Vector3 curRot = _transform.eulerAngles;
			curRot.y += 180;
			_transform.eulerAngles = curRot;
		}

	}
}

