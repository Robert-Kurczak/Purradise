using UnityEngine;
using UnityEngine.EventSystems;
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
	private GameObject confirmButton;
	private GameObject abortButton;
	private GameObject instantiatedStructure;

	private void changeColor(Color32 color){
		foreach(Transform child in instantiatedStructure.transform){
			if(child.TryGetComponent<TilemapRenderer>(out TilemapRenderer renderer))
				renderer.material.color = color;
		}
	}

	private void placeModeOff(){
		Destroy(instantiatedStructure.gameObject);
		placingMode = false;
	}

	public void placeModeOn(){
		Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(transform.position);
		spawnPosition.z = 0;

		instantiatedStructure = Instantiate(structure, spawnPosition, transform.rotation, structuresParent.transform);
		collidersCounter = instantiatedStructure.GetComponent<CollidersCounter>();

		//---Setting up options canvas---
		Vector3 optionsPosition = new Vector3(
			instantiatedStructure.transform.position.x,
			instantiatedStructure.transform.position.y + 3.62f,
			instantiatedStructure.transform.position.z
		);

		instantiatedCanvas = Instantiate(optionsCanvas, optionsPosition, transform.rotation, instantiatedStructure.transform);

		abortButton = instantiatedCanvas.transform.GetChild(0).gameObject;
		confirmButton = instantiatedCanvas.transform.GetChild(1).gameObject;

		abortButton.GetComponent<Button>().onClick.AddListener(abortPlacing);
		confirmButton.GetComponent<Button>().onClick.AddListener(placeStructure);
		//------

		instantiatedStructure.GetComponent<BoxCollider2D>().isTrigger = true;
		placingMode = true;
	}

	private void abortPlacing(){
		placeModeOff();
	}

	private void placeStructure(){
		GameObject instance = Instantiate(
			structure,
			instantiatedStructure.transform.position,
			instantiatedStructure.transform.rotation,
			structuresParent.transform
		);

		//If object have StructureBuilder initialize building process
		if(instance.TryGetComponent<StructureBuilder>(out StructureBuilder builder)){
			builder.initialize();
		}

		placeModeOff();
	}

	void Update(){
		if(placingMode){

			if(collidersCounter.isColliding()){
				confirmButton.SetActive(false);
				changeColor(disallowColor);
			}
			else{
				confirmButton.SetActive(true);
				changeColor(allowColor);
			}

			if(Input.touchCount > 0){
				Touch touch = Input.GetTouch(0);

				if(touch.phase != TouchPhase.Ended && !EventSystem.current.IsPointerOverGameObject(touch.fingerId)){
					Vector3 newPosition = Camera.main.ScreenToWorldPoint(touch.position);
					newPosition.z = 0;

					instantiatedStructure.transform.position = newPosition;
				}
			}
		}
	}
}
