using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {
	private Rigidbody2D _rigidbody;

	void Start(){
		_rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		this._rigidbody.gravityScale = 0.0f;
	}
	public void OnCollisionEnter2D(Collision2D other){
		
		if (other.gameObject.tag.Equals ("Player")) {
			StartCoroutine ("Fade");

		}
	}

	//fade when player steps on a cloud
	private IEnumerator Fade(){
		Color c;
		Renderer renderer = 
			gameObject.GetComponent<Renderer> ();
		for (float f = 1f; f >= 0; f -= 0.1f) {
			c = renderer.material.color;
			c.a = f;
			renderer.material.color = c;
			yield return new WaitForSeconds (.3f);
		}

		this.gameObject.SetActive (false);
	}
}
