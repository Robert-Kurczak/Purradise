using UnityEngine;

public class DropPickup : MonoBehaviour{
	public float range = 5;
	public float pickupTime = 0.2f;

	public Item item;
	private Vector3 velocity = Vector3.zero;
	private PlayerInventory playerInventory = PlayerSingleton.Instance.GetComponent<PlayerInventory>();

	void Update(){
		Vector3 playerPosition = PlayerSingleton.Instance.transform.position;

		//if player is in range
		if(Vector3.Distance(playerPosition, transform.position) <= range){

			//if player have space for this item
			if(playerInventory.getAmount(item) <= item.maxAmount){
				transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, pickupTime);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject == PlayerSingleton.Instance.gameObject){

			if(playerInventory.getAmount(item) <= item.maxAmount){
				playerInventory.addItem(item, 1);
			}

			Destroy(gameObject);
		}
	}
}
