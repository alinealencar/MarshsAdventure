using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContinueController : MonoBehaviour, IPointerClickHandler {
	[SerializeField]
	public Image continueImage;
	[SerializeField]
	public Image restartImage;
	[SerializeField]
	public Image cloudImage;
	[SerializeField]
	public Image exitImage;
	[SerializeField]
	public Image pauseImage;

	public void OnPointerClick(PointerEventData eventData)
	{
		//Set the timeScale to 1 so everything runs in the normal state
		Time.timeScale = 1;

		//Hide images
		continueImage.gameObject.SetActive(false);
		cloudImage.gameObject.SetActive (false);
		restartImage.gameObject.SetActive (false);
		exitImage.gameObject.SetActive (false);

		//Show pause
		pauseImage.gameObject.SetActive(true);
	}
}
