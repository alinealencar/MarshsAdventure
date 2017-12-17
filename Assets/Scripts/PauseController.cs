using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseController : MonoBehaviour, IPointerClickHandler {
	[SerializeField]
	public Image continueImage;

	public void OnPointerClick(PointerEventData eventData)
	{
		//When click on pause, set the timeScale of the game to 0 
		//(all animations stops and the player cannot move anymore)
		Time.timeScale = 0;

		//Show images
		continueImage.gameObject.SetActive(true);
	}
}
