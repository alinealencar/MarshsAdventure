using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class RestartController : MonoBehaviour, IPointerClickHandler {
	private int sceneIndex;

	public UIController uiCtrl;

	void Awake(){
		//get Active scene index
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
	}


	public void OnPointerClick(PointerEventData eventData)
	{
		//Load active scene whenever this button is clicked
		//means back to the begining of the active scene
		if (SceneManager.GetActiveScene ().buildIndex == 3) {
			Player.Instance.Score = 0;
			Player.Instance.Life = 4;
			SceneManager.LoadScene (sceneIndex);
			uiCtrl.UpdateUI ();
		}
		else
			SceneManager.LoadScene (sceneIndex);
	}
}
