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

	private void initialize(){

		Player.Instance.Score = 0;
		Player.Instance.Life = 4;

		lifeLabel.gameObject.SetActive (true);
		coinLabel.gameObject.SetActive (true);
	}
		

	public void updateUI(){

		coinLabel.text = "Coin: " + Player.Instance.Score;
		lifeLabel.text = "Life: " + Player.Instance.Life;
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