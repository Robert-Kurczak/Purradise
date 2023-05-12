using UnityEngine;

public class HousePlacer : MonoBehaviour{
	public GameObject structuresParent;
	public GameObject house;

	private bool placing = false;
	private GameObject placingHouse;

	public void startPlacing(){
        placingHouse = (GameObject)Instantiate(house, transform.position, transform.rotation, structuresParent.transform);
		placing = true;
	}

	void Update(){
		if(placing){
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			placingHouse.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
		}
	}
}
