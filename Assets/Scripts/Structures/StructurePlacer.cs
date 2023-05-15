using UnityEngine;
using UnityEngine.Tilemaps;

public class StructurePlacer : MonoBehaviour{
	public GameObject structuresParent;
	public GameObject structure;
	// public Material placingMaterial;
	// public Material normalMaterial;

	public Color32 allowColor;
	public Color32 disallowColor;

	private bool placingMode = false;
	private CollidersCounter collidersCounter;
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

		foreach(Transform child in instantiatedStructure.transform){
			if(child.TryGetComponent<BoxCollider2D>(out BoxCollider2D collider))
				collider.isTrigger = true;
		}
		placingMode = true;
	}

	void Update(){
		if(placingMode){
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			instantiatedStructure.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);

			if(collidersCounter.isColliding()) changeColor(disallowColor);
			else changeColor(allowColor);
		}
	}
}
