using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarshController : MonoBehaviour {
	[SerializeField]
	private float forceMultiplier = 1f;
	[SerializeField]
	private float jumpMultiplier = 30f;


	private Rigidbody2D _rigidbody = null;
	private Animator _animator = null;

	// Use this for initialization
	void Start () {
		_animator = gameObject.GetComponent<Animator> ();
		_rigidbody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Marsh walkiing right and left
		Vector2 forceVect = new Vector2 (Input.GetAxis ("Horizontal"), 0);
		_rigidbody.AddForce (forceVect * forceMultiplier);

		//flip
		if (_rigidbody.velocity.x < 0) {
			gameObject.transform.localScale = new Vector3 (-1, 1, 1);
		} else if(_rigidbody.velocity.x > 0){
			gameObject.transform.localScale = new Vector3 (1, 1, 1);
		}

		//jump
		float jump = Input.GetAxis("Jump");
		if (jump > 0) {
			_rigidbody.AddForce (Vector2.up * jumpMultiplier);
		}
	}

	private bool isGrounded(){
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		Vector2 pos = gameObject.transform.position;

		RaycastHit2D res = Physics2D.Linecast (
			new Vector2 (pos.x, pos.y - (sr.bounds.size.y / 2)),
			new Vector2 (pos.x, pos.y - (sr.bounds.size.y / 2))
		);

		Debug.DrawLine (
			new Vector2 (pos.x, pos.y - (sr.bounds.size.y / 2)),
			new Vector2 (pos.x, pos.y - (sr.bounds.size.y / 2))
		);	

		return res != null && res.collider != null;
	}
}
