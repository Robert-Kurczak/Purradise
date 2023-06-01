using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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

	private struct MaterialButton{
		public GameObject gameObject;
		public TMP_Text itemAmountText;

		public MaterialButton(GameObject gameObject, Sprite icon, UnityAction handler){
			this.gameObject = gameObject;
			this.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = icon;
			this.itemAmountText = gameObject.transform.GetChild(1).GetComponent<TMP_Text>();
			this.gameObject.GetComponent<Button>().onClick.AddListener(handler);
		}
	}

	private GameObject builtStructure;

	private PlayerInventory playerInventory;
	private BoxCollider2D boxCollider2D;
	private CanvasToggler buttonsCanvasToggler;
	private Dictionary<Item, MaterialButton> materialsButtons = new Dictionary<Item, MaterialButton>();
	private Dictionary<Item, int> requiredMaterials = new Dictionary<Item, int>();

	private void finishBuilding(){
		builtStructure.SetActive(true);
		Destroy(gameObject);
	}

	private void changeColor(Color32 color){
		foreach(Transform child in transform){
			if(child.TryGetComponent<TilemapRenderer>(out TilemapRenderer renderer))
				renderer.material.color = color;
		}
	}

	private void addMaterial(Item item){
		if(playerInventory.removeItem(item, 1)){
			requiredMaterials[item]--;

			MaterialButton button = materialsButtons[item];
			//Amount text
			button.itemAmountText.text = requiredMaterials[item].ToString();

			if(requiredMaterials[item] == 0){
				Destroy(button.gameObject);
				materialsButtons.Remove(item);

				if(materialsButtons.Count == 0){
					finishBuilding();
				}
			}
		}
	}

	//Structure placer can call this method to initialize building process
	public void initialize(){
		//Initializing original prefab and hiding it
		//before making changes to this gameObject
		builtStructure = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
		builtStructure.SetActive(false);

		playerInventory = PlayerSingleton.Instance.GetComponent<PlayerInventory>();

		changeColor(buildColor);

		boxCollider2D = GetComponent<BoxCollider2D>();
		boxCollider2D.isTrigger = true;

		materialButtonCanvasTemplate = Instantiate(materialButtonCanvasTemplate, transform);

		buttonsCanvasToggler = gameObject.AddComponent<CanvasToggler>();
		buttonsCanvasToggler.canvas = materialButtonCanvasTemplate;
		
		foreach(BuildMaterial buildMaterial in requiredMaterialsArray){
			//Buttons for adding materials
			MaterialButton button = new MaterialButton(
				Instantiate(materialButtonTemplate, transform.position, transform.rotation, materialButtonCanvasTemplate.transform),
				//Setting icon
				buildMaterial.item.icon,
				//Setting handler
				() => addMaterial(buildMaterial.item)
			);

			button.itemAmountText.text = buildMaterial.amount.ToString();

			//Populating array from inspector into proper dictionary
			//materialsButtons - button corresponding to item
			//requiredMaterials - amount of required materials
			requiredMaterials[buildMaterial.item] = buildMaterial.amount;
			materialsButtons[buildMaterial.item] = button;
		}
	}
}
