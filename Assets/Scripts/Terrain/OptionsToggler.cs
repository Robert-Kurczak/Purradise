using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsToggler: MonoBehaviour{
	public GameObject optionsCanvas;

	private bool ignoreClick;

	private void OnMouseDown(){
		optionsCanvas.SetActive(true);
		ignoreClick = true;
	}

	void Start(){
		optionsCanvas.SetActive(false);
	}

	//TODO optimize it, maybe coroutine?
	void Update(){
		//Check for touch events
		if(optionsCanvas.activeSelf && Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			//Touch just started and is outside of the clickable object
			if(touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId)){
				//Ignoring the first detected click, as this is the click
				//that caused to show optionsCanvas.
				if(ignoreClick) ignoreClick = false;
				else optionsCanvas.SetActive(false);
			}
		}
	}
}
