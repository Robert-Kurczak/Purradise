using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsToggler : MonoBehaviour{
	public GameObject OptionsCanvas;

	private bool ignoreClick;
	void Awake(){
		OptionsCanvas.SetActive(false);
	}

	void Update(){
		//Check for touch events
		if(Input.touchCount > 0 && OptionsCanvas.activeSelf){
			Touch touch = Input.GetTouch(0);
			//Touch just started and is outside of the clickable object
			if(touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId)){
				//Ignoring the first detected click, as this is the click
				//that caused to show OptionsCanvas.
				if(ignoreClick) ignoreClick = false;
				else OptionsCanvas.SetActive(false);
			}
		}
	}

	private void OnMouseDown(){
		OptionsCanvas.SetActive(true);
		ignoreClick = true;
	}
}
