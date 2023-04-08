using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsToggler : MonoBehaviour{
	public GameObject OptionsCanvas;

	private bool ignoreClick;
	void Awake(){
		OptionsCanvas.SetActive(false);
	}

	void Update(){
		//Hide canvas if mouse was cliccked anywhere (besides UI elements), while canvas was shown
		if(Input.GetMouseButtonDown(0) && OptionsCanvas.activeSelf && !EventSystem.current.IsPointerOverGameObject()){
			//Ignoring the first detected click, as this is the click
			//that caused to show OptionsCanvas.
			if(ignoreClick) ignoreClick = false;
			else OptionsCanvas.SetActive(false);
		}
	}

	private void OnMouseDown(){
		OptionsCanvas.SetActive(true);
		ignoreClick = true;
	}
}
