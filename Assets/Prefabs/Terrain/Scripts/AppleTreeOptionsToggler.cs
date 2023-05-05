using UnityEngine;
using UnityEngine.EventSystems;

public class AppleTreeOptionsToggler: MonoBehaviour{
	public GameObject optionsCanvas;
	public GameObject gatherButton;
	public GameObject chopButton;

	private bool ignoreClick;

	public void showGatherButton(){
		gatherButton.SetActive(true);
		chopButton.transform.position = optionsCanvas.transform.position + new Vector3(0.5f, 0);
	}

	public void hideGatherButton(){
		gatherButton.SetActive(false);
		chopButton.transform.position = optionsCanvas.transform.position;
	}

	//TODO fix toggling gather button
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
