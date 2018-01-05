using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZoneLevel3 : MonoBehaviour {

	[SerializeField]
	Transform spawnPoint = null;

	private int sceneIndex;

	public UIController uiCtrl;

	void Awake(){
		//get Active scene index
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
	}

	void Update(){
		//get current score and save it to PlayerPrefs
		PlayerPrefs.SetInt ("lives",Player.Instance.Life);
	}

	public void OnCollisionEnter2D(Collision2D other){
		other.transform.position = spawnPoint.position;
		Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D> ();
		if (rb) {
			rb.velocity = Vector2.zero;
		}

		//get current score and save it to PlayerPrefs
		PlayerPrefs.SetInt ("lives",Player.Instance.Life);
		PlayerPrefs.Save ();
		//decrease one life when player falls
		Player.Instance.Life--;

		if (Player.Instance.Life > 0) {
			SceneManager.LoadScene (sceneIndex);
			//uiCtrl.UpdateUI ();
		}
		else
			uiCtrl.GameOver ();

	}

	}
