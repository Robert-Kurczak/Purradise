using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class StructureBuilder : MonoBehaviour{
	public Color32 buildColor;

	public GameObject materialButtonCanvasTemplate;
	public GameObject materialButtonTemplate;

	//---Workaround to have "dictionary" in inspector---
	[System.Serializable]
	public struct BuildMaterial{
		public Item item;
		public int amount;
	}

	public BuildMaterial[] requiredMaterialsArray;
	//------

	private Dictionary<Item, GameObject> materialsButtons = new Dictionary<Item, GameObject>();
	private Dictionary<Item, int> requiredMaterials = new Dictionary<Item, int>();
	private void changeColor(Color32 color){
		foreach(Transform child in transform){
			if(child.TryGetComponent<TilemapRenderer>(out TilemapRenderer renderer))
				renderer.material.color = color;
		}
	}

	private void addMaterial(Item item){
		if(--requiredMaterials[item] == 0){
			Destroy(materialsButtons[item].gameObject);

			//TODO check if fully built
		}
	}

	void Start(){
		changeColor(buildColor);

		materialButtonCanvasTemplate = Instantiate(materialButtonCanvasTemplate, transform);

		//Populating array from inspector into proper dictionary
		//materialsButtons - button corresponding to item
		//requiredMaterials - amount of required materials
		foreach(BuildMaterial buildMaterial in requiredMaterialsArray){
			//Buttons for adding materials
			GameObject button = Instantiate(materialButtonTemplate, transform.position, transform.rotation, materialButtonCanvasTemplate.transform);
			//Setting icon
			button.transform.GetChild(0).GetComponent<Image>().sprite = buildMaterial.item.icon;
			//Setting handler
			button.GetComponent<Button>().onClick.AddListener(() => addMaterial(buildMaterial.item));

			requiredMaterials[buildMaterial.item] = buildMaterial.amount;
			materialsButtons[buildMaterial.item] = button;
		}
	}
}
