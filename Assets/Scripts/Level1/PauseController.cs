using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseController : MonoBehaviour, IPointerClickHandler {
	[SerializeField]
	public Image pauseImage;
	[SerializeField]
	public Image continueImage;
	[SerializeField]
	public Image restartImage;
	[SerializeField]
	public Image cloudImage;
	[SerializeField]
	public Image exitImage;

	public void OnPointerClick(PointerEventData eventData)
	{
		//When click on pause, set the timeScale of the game to 0 
		//(all animations stops and the player cannot move anymore)
		Time.timeScale = 0;

		//Hide pause button
		pauseImage.gameObject.SetActive(false);

		//Show images
		continueImage.gameObject.SetActive(true);
		restartImage.gameObject.SetActive(true);
		cloudImage.gameObject.SetActive(true);
		exitImage.gameObject.SetActive(true);

	}
}
