using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryUI : MonoBehaviour{
	public GameObject inventoryPanel;
	private PlayerInventory playerInventory;
	private InventorySlot[] slots;
	private void updateInventoryUI(){
		IReadOnlyDictionary<Item, int> currentInventory = playerInventory.getInventory();

		for(int i = 0; i < slots.Length; i++){
			if(i < currentInventory.Count){
				KeyValuePair<Item, int> item = currentInventory.ElementAt(i);

				slots[i].insertItem(item.Key, item.Value);
			}
			else{
				slots[i].clearSlot();
			}
		}
	}

	void Start(){
		playerInventory = PlayerSingleton.Instance.GetComponent<PlayerInventory>();
		playerInventory.OnInventoryChange += updateInventoryUI;

		slots = inventoryPanel.GetComponentsInChildren<InventorySlot>();

		updateInventoryUI();
	}
}
