using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour, IPointerClickHandler {
	public void OnPointerClick(PointerEventData eventData)
	{
		//Go to the start scene
		SceneManager.LoadScene (0);
	}
}
