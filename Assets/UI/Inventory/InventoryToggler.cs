using UnityEngine;
using UnityEngine.UI;

public class InventoryToggler : MonoBehaviour{
	public Image buttonImage;
	public Sprite backgroundActiveSprite;
	public Sprite backgroundInactiveSprite;

	public GameObject activeIcon;
	public GameObject inactiveIcon;
	public GameObject inventoryTab;

	void Start(){
		activeIcon.SetActive(false);
		inactiveIcon.SetActive(true);
		inventoryTab.SetActive(false);
	}

	public void toggleInventory(){
		//Toggle on
		if(!inventoryTab.activeSelf){
			buttonImage.sprite = backgroundActiveSprite;

			inactiveIcon.SetActive(false);
			activeIcon.SetActive(true);

			inventoryTab.SetActive(true);
		}
		//Toggle off
		else{
			buttonImage.sprite = backgroundInactiveSprite;

			inactiveIcon.SetActive(true);
			activeIcon.SetActive(false);

			inventoryTab.SetActive(false);
		}
	}
}
