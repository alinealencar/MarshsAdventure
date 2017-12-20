using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick(PointerEventData eventData)
	{
		//Load Level 1 whenever this button is clicked
		SceneManager.LoadScene (1);
	}
}
