using UnityEngine;

public class TreeDestroyer: MonoBehaviour{
    public GameObject trunk;
    public GameObject dropItem;
    public int dropAmount = 3;

    public void destroy(){
        Instantiate(trunk, transform.position, transform.rotation);

        for(int i = 0 ; i < dropAmount; i++)
            Instantiate(dropItem, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
