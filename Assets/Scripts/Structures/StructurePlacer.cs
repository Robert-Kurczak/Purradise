using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class StructurePlacer : MonoBehaviour{
	public GameObject structuresParent;
	public GameObject structure;
	public GameObject optionsCanvas;

	public Color32 allowColor;
	public Color32 disallowColor;

	private bool placingMode = false;
	private CollidersCounter collidersCounter;
	private GameObject instantiatedCanvas;
	private GameObject instantiatedStructure;

	private void changeColor(Color32 color){
		foreach(Transform child in instantiatedStructure.transform){
			if(child.TryGetComponent<TilemapRenderer>(out TilemapRenderer renderer))
				renderer.material.color = color;
		}
	}

	private void placeModeOff(){
		foreach(Transform child in instantiatedStructure.transform){
			if(child.TryGetComponent<BoxCollider2D>(out BoxCollider2D collider))
				collider.isTrigger = false;
		}
		placingMode = false;
	}

	public void placeModeOn(){
		instantiatedStructure = Instantiate(structure, transform.position, transform.rotation, structuresParent.transform);
		collidersCounter = instantiatedStructure.GetComponent<CollidersCounter>();

		//---Setting up options canvas---
		Vector3 optionsPosition = new Vector3(
			instantiatedStructure.transform.position.x,
			instantiatedStructure.transform.position.y + 3.62f,
			instantiatedStructure.transform.position.z
		);

		instantiatedCanvas = Instantiate(optionsCanvas, optionsPosition, transform.rotation, instantiatedStructure.transform);

		GameObject abortButton = instantiatedCanvas.transform.GetChild(0).gameObject;
		GameObject confirmButton = instantiatedCanvas.transform.GetChild(1).gameObject;

		abortButton.GetComponent<Button>().onClick.AddListener(abortPlacing);
		confirmButton.GetComponent<Button>().onClick.AddListener(placeStructure);
		//------

		foreach(Transform child in instantiatedStructure.transform){
			if(child.TryGetComponent<BoxCollider2D>(out BoxCollider2D collider))
				collider.isTrigger = true;
		}
		placingMode = true;
	}

	private void abortPlacing(){
		Debug.Log("aborting placing");
	}

	private void placeStructure(){
		Debug.Log("placed");
	}

	void Update(){
		if(placingMode){
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
				Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				instantiatedStructure.transform.position = new Vector3(newPosition.x, newPosition.y, 0);

				if(collidersCounter.isColliding()) changeColor(disallowColor);
				else changeColor(allowColor);
			}
		}
	}
}
