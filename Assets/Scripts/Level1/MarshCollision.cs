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
	public AudioClip audioWater;
	[SerializeField]
	AudioClip audioCompleted;
	[SerializeField]
	GameObject heart;
	[SerializeField]
	Transform spawnPoint = null;
	private AudioSource[] allAudios;

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
				// plays audio
				AudioSource audio = GetComponent<AudioSource>();
				audio.PlayOneShot (audioEnemy);
			}
			//life is decreased
			Player.Instance.Life -= 1;

			StartCoroutine( "Blink");
		}

		//if Marsh collides with water
		else if(other.gameObject.tag.Equals("water")){
			Debug.Log ("Collision water\n");
	
			//water audio
			if(audioWater != null){
				//plays audio
				AudioSource audio = GetComponent<AudioSource>();
				audio.PlayOneShot(audioWater);
			}

			//life is decreased by 1
			Player.Instance.Life -= 1;
		}

		//if Marsh picks up a candy
		else if (other.gameObject.tag.Equals ("candy")) {
			Debug.Log ("Collision candy\n");
			other.gameObject.SetActive (false);
			// enemy audio
			if (audioLife != null) {
				// plays audio
				AudioSource audio = GetComponent<AudioSource>();
				audio.PlayOneShot (audioLife);
			}
			//life is increased by 1
			Player.Instance.Life += 1;
		}

		//when Marsh reaches the door
		if (other.gameObject.name.Equals ("door")) {
			//stop all audio
			StopAudio ();
			// game completed audio
			AudioSource audio = GetComponent<AudioSource>();
			audio.PlayOneShot (audioCompleted);
			//pause and go to next level
			StartCoroutine("Wait");
		}

		if (other.gameObject.name.Equals ("mallow")) {
			//Stop all audios to play the game completed audio
			StopAudio();

			// game completed audio
			AudioSource audio = GetComponent<AudioSource>();
			audio.PlayOneShot (audioCompleted);
			Instantiate (heart)
				.GetComponent<Transform> ()
				.position = other.gameObject
					.GetComponent<Transform> ()
					.position;
			//pause and go to next level
			StartCoroutine("Wait");
		}

	}

	//Spawn Marsh to the beginning of the level
	public void OnTriggerExit2D(Collider2D other){
		if (other.tag.Equals ("water"))
			transform.position = spawnPoint.position;
		
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D> ();
		if (rb) {
			rb.velocity = Vector2.zero;
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
		//delay to move to next level
		yield return new WaitForSeconds(3);
		//move to next level
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	private void StopAudio(){
		allAudios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		foreach(AudioSource anAudio in allAudios) {
			anAudio.Stop();
		}
	}

}