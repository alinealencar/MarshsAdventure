using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarshCollision : MonoBehaviour {

	[SerializeField]
	UIController uiController;

	public AudioClip audioPoints;
	public AudioClip audioEnemy;
	public AudioClip audioLife;
	[SerializeField]
	AudioClip audioCompleted;

	private Transform _transform;
	private Vector2 _currPos;

	public void OnTriggerEnter2D(Collider2D other){

		//if Marsh picks up coins
		if (other.gameObject.tag.Equals ("coin")) {
			Debug.Log ("Collision coin\n");
			other.gameObject.SetActive (false);

			if (audioPoints != null) {
				// points audio
				AudioSource audio = GetComponent<AudioSource>();
				audio.PlayOneShot (audioPoints);
			}

			//add score
			Player.Instance.Score += 1;
		
			//if number of coins is equal to 20, add 1 life
			if (Player.Instance.Score.Equals(20)) {
				if (audioLife != null) {
					// points audio
					AudioSource audio = GetComponent<AudioSource>();
					audio.PlayOneShot (audioLife);
				}

				Player.Instance.Life += 1;
				Player.Instance.Score = 0;
			}
		}
		//if Marsh collides with an enemy (saw or mace)
		 else if (other.gameObject.tag.Equals ("enemy")) {
			Debug.Log ("Collision enemy\n");
			// enemy audio
			if (audioEnemy != null) {
				// points audio
				AudioSource audio = GetComponent<AudioSource>();
				audio.PlayOneShot (audioEnemy);
			}
			//life is decreased
			Player.Instance.Life -= 1;

			StartCoroutine( "Blink");
		}

		//if Marsh picks up a candy
		else if (other.gameObject.tag.Equals ("candy")) {
			Debug.Log ("Collision candy\n");
			other.gameObject.SetActive (false);
			// enemy audio
			if (audioLife != null) {
				// points audio
				AudioSource audio = GetComponent<AudioSource>();
				audio.PlayOneShot (audioLife);
			}
			//life is increased by 1
			Player.Instance.Life += 1;
		}

		//when Marsh reaches the door
		if (other.gameObject.name.Equals ("door")) {
			// game completed audio
			AudioSource audio = GetComponent<AudioSource>();
			audio.PlayOneShot (audioCompleted);
			//pause and go to level 2
			StartCoroutine("Wait");
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

	IEnumerator Wait()
	{
		//delay to move to level 2
		yield return new WaitForSeconds(3);
		//move to level 2
		SceneManager.LoadScene (2);
	}

}