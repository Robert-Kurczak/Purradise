using UnityEngine;

public class MushroomGatherer : MonoBehaviour{
	public GameObject dropItem;
	public int dropAmount = 1;
	public void gather(){
		for(int i = 0; i < dropAmount; i++)
            Instantiate(dropItem, transform.position, transform.rotation);

		Destroy(gameObject);
	}
}
