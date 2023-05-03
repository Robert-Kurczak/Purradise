using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour{
	private Dictionary<Item, int> inventory = new Dictionary<Item, int>();

    public event Action OnInventoryChange;

	public void addItem(Item item, int amount = 1){
		if(inventory.ContainsKey(item)) inventory[item] += amount;
		else inventory.Add(item, amount);

		OnInventoryChange?.Invoke();
	}

	public void removeItem(Item item, int amount = 1){
		if(inventory.ContainsKey(item)){
			inventory[item] -= amount;

			if(inventory[item] <= 0) inventory.Remove(item);

			OnInventoryChange?.Invoke();
		}
	}

	public int getAmount(Item item){
		if(inventory.ContainsKey(item)) return inventory[item];
		return 0;
	}

	//Original dictionary need to be protected,
	//therefore, outside we provide read-only copy
	public IReadOnlyDictionary<Item, int> getInventory(){
		return new Dictionary<Item, int>(inventory);
	}
}
