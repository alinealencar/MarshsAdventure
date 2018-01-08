using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour {

	[SerializeField]
	private float speed = 1f;


	private Rigidbody2D _rigidBody;
	private Transform _transform;

	private float _width, _height;

	// Use this for initialization
	void Start () {

		_rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		_transform = gameObject.transform;

		SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer> ();
		_width = sprite.bounds.extents.x;
		_height = sprite.bounds.extents.y;

	}

	// Update is called once per frame
	void FixedUpdate () {

		Vector2 lineCastPos = 
			(Vector2)_transform.position +
			(Vector2)_transform.right * _width -
			(Vector2)_transform.up * _height;

		Debug.DrawLine (lineCastPos, lineCastPos + Vector2.down);
		bool isGrounded = 
			Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down);

		if (!isGrounded) {

			Vector3 curRot = _transform.eulerAngles;
			curRot.y += 180;
			_transform.eulerAngles = curRot;		
		}

		Vector2 vel = _rigidBody.velocity;
		vel.x = _transform.right.x * speed;
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

