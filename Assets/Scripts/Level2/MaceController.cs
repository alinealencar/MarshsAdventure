using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceController : MonoBehaviour {
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float ceilingY = 2.4f;
	private bool isUp = false;


	private Rigidbody2D _rigidBody;
	private Transform _transform;
//
//	private float _width, _height;

	// Use this for initialization
	void Start () {
		_rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		_transform = gameObject.transform;

//		SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer> ();
//		_width = sprite.bounds.extents.x;
//		_height = sprite.bounds.extents.y;
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		if (gameObject.transform.position.y > ceilingY) {
			Vector3 curRot = _transform.eulerAngles;
			curRot.x += 180;
			_transform.eulerAngles = curRot;
			isUp = false;
		}

		Vector2 vel = _rigidBody.velocity;

		if (isUp)
			vel.y = _transform.up.y * (speed / 3);
		else {
			vel.y = _transform.up.y * speed;
		}
		_rigidBody.velocity = vel;



	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag.Equals ("dirt")) {
			Vector3 curRot = _transform.eulerAngles;
			curRot.x += 180;
			_transform.eulerAngles = curRot;
			isUp = true;
		}

	}
}
