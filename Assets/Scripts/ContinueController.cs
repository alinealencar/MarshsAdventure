using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContinueController : MonoBehaviour, IPointerClickHandler {
	[SerializeField]
	public Image continueImage;

	public void OnPointerClick(PointerEventData eventData)
	{
		//Set the timeScale to 1 so everything runs in the normal state
		Time.timeScale = 1;

		//Hide images
		continueImage.gameObject.SetActive(false);
	}
}
