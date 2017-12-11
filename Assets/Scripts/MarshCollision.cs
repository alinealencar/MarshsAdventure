using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarshCollision : MonoBehaviour {


// Use this for initialization
void Start () {


}

// Update is called once per frame
void Update () {

}

public void OnTriggerEnter2D(Collider2D other){

	//if Marsh picks up coins
	if (other.gameObject.tag.Equals ("coin")) {
		Debug.Log ("Collision coin\n");
		other.gameObject.SetActive (false);
		//add score
		Player.Instance.Score += 1;
		
		//if number of coins is equal to 20, add 1 life
		if (Player.Instance.Score.Equals(20)) {
				Player.Instance.Life += 1;
		}
	}

	//if Marsh collides with an enemy (saw or mace)
	 else if (other.gameObject.tag.Equals ("enemy")) {
		Debug.Log ("Collision enemy\n");
		//life is decreased
		Player.Instance.Life -= 1;
		
		StartCoroutine( "Blink");
	}

	//if Marsh picks up a candy
	else if (other.gameObject.tag.Equals ("candy")) {
		Debug.Log ("Collision candy\n");
		other.gameObject.SetActive (false);
		//life is increased by 1
		Player.Instance.Life += 1;
		}

}

	//blink when player collides with an enemy
	private IEnumerator Blink(){
		Color c;
		Renderer renderer = 
			gameObject.GetComponent<Renderer> ();
		for (int i = 0; i < 1; i++) {
			for (float f = 1f; f >= 0; f -= 0.1f) {
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return new WaitForSeconds (.1f);
			}
			for (float f = 0f; f <= 1; f += 0.1f) {
				c = renderer.material.color;
				c.a = f;
				renderer.material.color = c;
				yield return new WaitForSeconds (.1f);
			}
		}
	}
}