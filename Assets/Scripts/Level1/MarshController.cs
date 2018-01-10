using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarshController : MonoBehaviour {
	[SerializeField]
	private float forceMultiplier = 3f;
	[SerializeField]
	private float jumpMultiplier = 30f;
	[SerializeField]
	private float startX; //-6.5
	[SerializeField]
	private float endX; //105


	private Rigidbody2D _rigidbody = null;
	private Animator _animator = null;
	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_animator = gameObject.GetComponent<Animator> ();
		_rigidbody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Marsh walking right and left
		Vector2 forceVect = new Vector2 (Input.GetAxis ("Horizontal"), 0);
		_rigidbody.AddForce (forceVect * forceMultiplier);

		//set boundaries
		_currentPos = _rigidbody.position;
		Checkbounds ();
		_rigidbody.position = _currentPos;
		//Debug.Log (_rigidbody.transform.position.x);


		//flip
		if (_rigidbody.velocity.x < 0) {
			gameObject.transform.localScale = new Vector3 (-1, 1, 1); 
		} else if(_rigidbody.velocity.x > 0){
			gameObject.transform.localScale = new Vector3 (1, 1, 1);
		}
			
		//jump
		float jump = Input.GetAxis("Jump");
		if (jump > 0 && IsGrounded()) {
			_rigidbody.AddForce (Vector2.up * jumpMultiplier);
		}


		//animation control
		//run
		_animator.SetInteger ("velocity",
			(int)(Mathf.Abs(_rigidbody.velocity.x * 10000000))); 
		
		//jump
		_animator.SetBool("jump", !IsGrounded());

		
	}

	private bool IsGrounded(){
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		Vector2 pos = gameObject.transform.position;

		//Marsh's jump boudary
		RaycastHit2D res = Physics2D.Linecast (
			new Vector2 (pos.x, pos.y - (sr.bounds.size.y / 2)), //starting point
			new Vector2 (pos.x, pos.y - (sr.bounds.size.y / 2 + 1.0f)) //ending point(how high he can jump)
		);

		//check the boundary
		Debug.DrawLine (
			new Vector2 (pos.x, pos.y - (sr.bounds.size.y / 2)),
			new Vector2 (pos.x, pos.y - (sr.bounds.size.y / 2 + 1.0f))
		);	

		return res != null && res.collider != null;
	}

	//boundaries of Marsh
	private void Checkbounds(){
		//left boundary
		if (_rigidbody.transform.position.x < startX) {
			_currentPos.x = startX;
		}
		//right boundary
		if (_rigidbody.transform.position.x > endX) {
			_currentPos.x = endX;
		}
	}
}
