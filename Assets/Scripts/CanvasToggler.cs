using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasToggler: MonoBehaviour{
	public GameObject canvas;
	private bool ignoreClick;

	private void OnMouseDown(){
		canvas.SetActive(true);
		ignoreClick = true;
	}

	void Start(){
		canvas.SetActive(false);
	}

	//TODO optimize it, maybe coroutine?
	void Update(){
		//Check for touch events
		if(canvas.activeSelf && Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			//Touch just started and is outside of the clickable object
			if(touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId)){
				//Ignoring the first detected click, as this is the click
				//that caused to show canvas.
				if(ignoreClick) ignoreClick = false;
				else canvas.SetActive(false);
			}
		}
	}
}
