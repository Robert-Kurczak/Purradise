using UnityEngine;

public class OptionsToggler : MonoBehaviour{
	public GameObject OptionsCanvas;
	private bool isShowing = false;
	void Awake(){
		OptionsCanvas.SetActive(isShowing);
	}

	private void OnMouseDown(){
		isShowing = !isShowing;
		OptionsCanvas.SetActive(isShowing);
	}
}
