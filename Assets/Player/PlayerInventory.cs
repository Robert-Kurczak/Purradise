using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour{
	public Dictionary<Item, int> inventory = new Dictionary<Item, int>();

	public void addItem(Item item, int amount = 1){
		if(inventory.ContainsKey(item)) inventory[item] += amount;
		else inventory.Add(item, amount);
	}

	public void removeItem(Item item, int amount = 1){
		if(inventory.ContainsKey(item)){
			inventory[item] -= amount;

			if(inventory[item] <= 0) inventory.Remove(item);
		}
	}

	public int getAmount(Item item){
		if(inventory.ContainsKey(item)) return inventory[item];
		return 0;
	}
}
