using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	[SerializeField]
	Text lifeLabel;
	[SerializeField]
	Text coinLabel;
	[SerializeField]
	public Image continueImage;
	[SerializeField]
	public Image restartImage;
	[SerializeField]
	public Image cloudImage;
	[SerializeField]
	public Image exitImage;
	[SerializeField]
	public Text gameOverLbl;
	[SerializeField]
	public Image pauseImage;
	[SerializeField]
	public GameObject clouds;

	private void initialize(){
		Time.timeScale = 1;

		if (PlayerPrefs.GetInt ("lives") == 0 || SceneManager.GetActiveScene ().buildIndex != 3) {
			Player.Instance.Score = 0;
			Player.Instance.Life = 4;
		} 
		else
			//set life to saved number of lives in PlayerPrefs
			Player.Instance.Life = PlayerPrefs.GetInt ("lives");

		lifeLabel.gameObject.SetActive (true);
		coinLabel.gameObject.SetActive (true);

		//Hide images
		continueImage.gameObject.SetActive(false);
		cloudImage.gameObject.SetActive (false);
		restartImage.gameObject.SetActive (false);
		exitImage.gameObject.SetActive (false);
		gameOverLbl.gameObject.SetActive (false);
	}
		

	public void UpdateUI(){

		coinLabel.text = "x " + Player.Instance.Score;
		lifeLabel.text = "x " + Player.Instance.Life;
	}

	public void GameOver(){
		//Show UI for game over
		cloudImage.gameObject.SetActive (true);
		restartImage.gameObject.SetActive (true);
		exitImage.gameObject.SetActive (true);
		gameOverLbl.gameObject.SetActive (true);
		pauseImage.gameObject.SetActive (false);


		//Pause the game
		Time.timeScale = 0;
	}

	// Use this for initialization
	void Start () {
		Player.Instance.uiCtrl = this;
		initialize ();
	}

	// Update is called once per frame
	void Update () {

	}
		
}