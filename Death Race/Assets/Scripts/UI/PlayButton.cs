using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Image imageToChange;

	public void ShowImage()
	{
		Debug.Log ("Show");
		var color = Color.white;
		color.a = 255;
		imageToChange.color = color;
	}

	public void HideImage()
	{
		Debug.Log ("Hide");
		var color = Color.white;
		color.a = 0;
		imageToChange.color = color;
	}

	public void OnPointerEnter(PointerEventData eventData){
		ShowImage ();
	}

	public void OnPointerExit(PointerEventData eventData){
		HideImage ();
	}

	public void OnClick()
	{
		SceneManager.LoadScene (1);
	}

}
