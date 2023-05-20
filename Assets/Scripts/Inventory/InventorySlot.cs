using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour{
	public Image imageIcon;
	public TMP_Text itemAmount;

	private Item item;
	public void insertItem(Item newItem, int amount){
		item = newItem;

		imageIcon.sprite = newItem.icon;
		imageIcon.enabled = true;

		itemAmount.text = amount.ToString();
		itemAmount.enabled = true;
	}

	public void clearSlot(){
		item = null;
		imageIcon.enabled = false;
		itemAmount.enabled = false;
	}
}
